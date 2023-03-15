using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class InventoryWithSlots : IInventory
{

    public event Action<object, IInventoryItem, int> OnInventoryItemAddedEvent;
    public event Action<object, Type, int> OnInventoryItemRemovedEvent;
    
    public int capacity { get; set; }
    public bool isFull => _slots.All(slot => slot.isFull);

    private List<IInventorySlot> _slots;

    public InventoryWithSlots(int capacity)
    {
        this.capacity = capacity;

        _slots = new List<IInventorySlot>(capacity);
        for (int i = 0; i < capacity; i++)
        {
            _slots.Add(new InventorySlot());
        }
    }
    
    public IInventoryItem GetItem(Type itemType)
    {
        return _slots.Find(slot => slot.itemType == itemType).item;
    }

    public IInventoryItem[] GetAllItems()
    {
        var allItems = new List<IInventoryItem>();
        foreach (var slot in _slots)
        {
            if (!slot.isEmpty)
            {
                allItems.Add(slot.item);
            }
        }

        return allItems.ToArray();
    }

    public IInventoryItem[] getAllItems(Type itemType)
    {
        var allItemsOfType = new List<IInventoryItem>();
        var slotsOfType = _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType);
        foreach (var slot in slotsOfType)
        {
            allItemsOfType.Add(slot.item);
        }

        return allItemsOfType.ToArray();
    }

    public IInventoryItem[] GetEquippedItems()
    {
        var requiredSlots = _slots.FindAll(slot => !slot.isEmpty && slot.item.isEquipped);
        var equippedItems = new List<IInventoryItem>();

        foreach (var slot in requiredSlots)
        {
            equippedItems.Add(slot.item);
        }

        return equippedItems.ToArray();
    }

    public int GetItemAmount(Type itemTYpe)
    {
        var amount = 0;
        var allItemSlots = _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemTYpe);
        foreach (var itemSlot in allItemSlots)
        {
            amount += itemSlot.amount;
        }

        return amount;
    }

    public bool TryToAdd(object sender, IInventoryItem item)
    {
        var slotWithSameItemButNotEmpty =
            _slots.Find(slot => !slot.isEmpty && slot.itemType == item.type && !slot.isFull);
        if (slotWithSameItemButNotEmpty != null)
        {
            return TryToAddToSlot(sender, slotWithSameItemButNotEmpty, item);
        }

        var emptySlot = _slots.Find(slot => slot.isEmpty);
        if (emptySlot!=null)
        {
            return TryToAddToSlot(sender, emptySlot, item);
        }
        Debug.Log($"Cannot add item {item.type}, amount {item.amount}");
        return false;
    }

    bool TryToAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
    {
        var fits = slot.amount + item.amount <= item.maxItemsInInventorySlot;
        var amountToAdd = fits
            ? item.amount
            : item.maxItemsInInventorySlot - slot.amount;
        var amountLeft = item.amount - amountToAdd;
        var clonedItem = item.Clone();
        clonedItem.amount = amountToAdd;

        if (slot.isEmpty)
        {
            slot.SetItem(clonedItem);
        }
        else
        {
            slot.item.amount += amountToAdd;
        }
        
        OnInventoryItemAddedEvent?.Invoke(sender,item,amountToAdd);

        if (amountLeft <= 0)
        {
            return true;
        }

        item.amount = amountLeft;
        return TryToAdd(sender, item);
    }

    public void Remove(object sender, Type itemType, int amount = 1)
    {
        var slotsWithItem = GetAllSlots(itemType);
        if (slotsWithItem.Length == 0)  
        {
            return;
        }

        var amountToRemove = amount;
        var count = slotsWithItem.Length;

        for (int i = count - 1; i >= 0; i--)
        {
            var slot = slotsWithItem[i];
            if (slot.amount >= amountToRemove)
            {
                slot.item.amount -= amountToRemove;

                if (slot.amount <= 0)
                {
                    slot.Clear();
                }
                
                OnInventoryItemRemovedEvent?.Invoke(sender, itemType,amountToRemove);
                break;
            }

            var amountRemoved = slot.amount;
            amountToRemove -= slot.amount;
            slot.Clear();
            OnInventoryItemRemovedEvent?.Invoke(sender, itemType,amountRemoved);
        }
    }

    public bool HasItem(Type type, out IInventoryItem item)
    {
        item = GetItem(type);
        return item != null;
    }
    
    public IInventorySlot[] GetAllSlots(Type itemType)
    {
        return _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType).ToArray();
    }

    public IInventorySlot[] GetAllSlots()
    {
        return _slots.ToArray();
    }
}
