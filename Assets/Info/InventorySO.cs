using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Items/New Inventory")]
public class InventorySO : ScriptableObject
{
    [SerializeField] private List<InventoryItem> _items;
    [field: SerializeField] public int Size { get; private set; } = 10;

    public event Action<Dictionary<int, InventoryItem>> OnInventoryUpdateAction;
    public void Initialize()
    {
        _items = new List<InventoryItem>();
        for (int i = 0; i < Size; i++)
        {
            _items.Add(InventoryItem.GetEmptyItem());
        }
    }
    public int AddItem(ItemSO item, int amount)
    {
        if(item.IsStackable == false)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                while (amount > 0 && IsInventoryFull() == false)
                {
                    amount -= AddItemToFirstFreeSlot(item, 1);
                    amount--;
                }
                InformAboutChange();
                return amount;
            }
        }
        amount = AddStackableItem(item, amount);
        InformAboutChange();
        return amount;
    }
    private int AddItemToFirstFreeSlot(ItemSO item, int amount)
    {
        InventoryItem newItem = new InventoryItem
        {
            Item = item,
            Amount = amount,
        };

        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].IsEmpty)
            {
                _items[i] = newItem;
                return amount;
            }
        }
        return 0;
    }
    private bool IsInventoryFull() => _items.Any(item => item.IsEmpty) == false;

    private int AddStackableItem(ItemSO item, int amount)
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].IsEmpty)
                continue;
            if(_items[i].Item.ID == item.ID)
            {
                int amountPossibleToTake =
                    _items[i].Item.MaxStackSize - _items[i].Amount;

                if (amount > amountPossibleToTake)
                {
                    _items[i] = _items[i]
                        .ChangeAmount(_items[i].Item.MaxStackSize);
                    amount -= amountPossibleToTake;
                }
                else
                {
                    _items[i] = _items[i]
                        .ChangeAmount(_items[i].Amount + amount);
                    InformAboutChange();
                    return 0;
                }
            }
        }
        while(amount > 0 && IsInventoryFull() == false)
        {
            int newQuantity = Mathf.Clamp(amount, 0, item.MaxStackSize);
            amount -= newQuantity;
            AddItemToFirstFreeSlot(item, newQuantity);
        }
        return amount;
    }
    public Dictionary<int, InventoryItem> GetCurrentInventoryState() 
    {
        Dictionary<int, InventoryItem> returnValue =
            new Dictionary<int, InventoryItem>();

        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i].IsEmpty)
                continue;
            returnValue[i] = _items[i];
        }
        return returnValue;
    }
    public InventoryItem GetItemAt(int itemIndex)
    {
        return _items[itemIndex];
    }
    public void AddItem(InventoryItem item)
    {
        AddItem(item.Item, item.Amount);
    }
    public void SwapItems(int itemIndex_1, int itemIndex_2)
    {
        (_items[itemIndex_1], _items[itemIndex_2]) = (_items[itemIndex_2], _items[itemIndex_1]);
        InformAboutChange();
    }
    private void InformAboutChange()
    {
        OnInventoryUpdateAction?.Invoke(GetCurrentInventoryState());
    }
    public void RemoveItem(int itemIndex, int amount)
    {
        if (_items.Count > itemIndex)
        {
            if (_items[itemIndex].IsEmpty)
                return;
            int reminder = _items[itemIndex].Amount - amount;
            if (reminder <= 0)
                _items[itemIndex] = InventoryItem.GetEmptyItem();
            else
                _items[itemIndex] = _items[itemIndex]
                    .ChangeAmount(reminder);

            InformAboutChange();
        }
    }
}

[Serializable]
public struct InventoryItem
{
    public int Amount;
    public ItemSO Item;
    public bool IsEmpty => Item == null;

    public InventoryItem ChangeAmount(int newAmount)
    {
        return new InventoryItem
        {
            Item = this.Item,
            Amount = newAmount,
        };
    }
    public static InventoryItem GetEmptyItem()
        => new InventoryItem
        {
            Item = null,
            Amount = 0,
        };
}
