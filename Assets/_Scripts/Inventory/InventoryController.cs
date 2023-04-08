using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private UIInventoryDescription _itemDescription;
    [SerializeField] private UIInventory _inventory;
    [SerializeField] private InventorySO _inventoryData;
    [SerializeField] private UIItemActionPanel _panel;

    public List<InventoryItem> InitialItems = new List<InventoryItem>();
    private void Awake()
    {
        PrepareUI();
        PrepareInventoryData();
    }
    private void PrepareInventoryData()
    {
        _inventoryData.Initialize();
        _inventoryData.OnInventoryUpdateAction += UpdateInventoryUI;
        foreach (InventoryItem item in InitialItems)
        {
            if (item.IsEmpty)
            {
                continue;
            }
            _inventoryData.AddItem(item);
        }
    }
    private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
    {
        _inventory.ResetAllItems();
        foreach (var item in inventoryState)
        {
            _inventory.UpdateData(item.Key, item.Value.Item.ItemImage, item.Value.Amount);
        }
    }
    void PrepareUI()
    {
        _inventory.InitializedInventoryUI(_inventoryData.Size);
        _inventory.OnDescriptionRequestedAction += HandleDescriptionRequest;
        _inventory.OnSwapItemsAction += HandleSwapItems;
        _inventory.OnStartDraggingAction += HandleDragging;
        _inventory.OnItemActionRequestedAction += HandleItemActionRequest;
    }
    private void HandleItemActionRequest(int itemIndex)
    {
        InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.IsEmpty)
            return;

        IItemAction itemAction = inventoryItem.Item as IItemAction;
        if(itemAction != null)
        {
            _inventory.ShowItemAction(itemIndex);
            _inventory.AddAction(itemAction.ActionName, () => PerformAction(itemIndex));
        }

        IDestroyableItem destroyableItem = inventoryItem.Item as IDestroyableItem;
        if (destroyableItem != null)
        {
            _inventory.AddAction("Drop", () => DropItem(itemIndex, inventoryItem.Amount));
        }
    }
    private void DropItem(int itemIndex, int amount)
    {
        _inventoryData.RemoveItem(itemIndex, amount);
        ResetSelection();
    }
    private void PerformAction(int itemIndex)
    {
        InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);
        if (inventoryItem.IsEmpty)
            return;

        IDestroyableItem destroyableItem = inventoryItem.Item as IDestroyableItem;
        if (destroyableItem != null)
        {
            _inventoryData.RemoveItem(itemIndex, 1);
        }

        IItemAction itemAction = inventoryItem.Item as IItemAction;
        if (itemAction != null)
        {
            itemAction.PerformAction(gameObject);
            if (_inventoryData.GetItemAt(itemIndex).IsEmpty) ResetSelection();
        }
    }
    private void HandleDragging(int itemIndex)
    {
        InventoryItem item = _inventoryData.GetItemAt(itemIndex);

        if (item.IsEmpty)
        {
            return;
        }
        
        _inventory.CreateDraggedItem(item.Item.ItemImage, item.Amount);
    }
    private void HandleSwapItems(int itemIndex_1, int itemIndex_2)
    {
        _inventoryData.SwapItems(itemIndex_1, itemIndex_2);
    }
    private void HandleDescriptionRequest(int itemIndex)
    {
        InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);
        
        if (inventoryItem.IsEmpty)
        {
            ResetSelection();
            return;
        }

        ItemSO item = inventoryItem.Item;
        _inventory.UpdateDescription(item.ItemImage, item.name, item.Description);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_inventory.isActiveAndEnabled == false)
            {
                Show(_inventory.gameObject);
                foreach (var item in _inventoryData.GetCurrentInventoryState())
                {
                    _inventory.UpdateData(item.Key, item.Value.Item.ItemImage, item.Value.Amount);
                }
            }
            else
            {
                Hide(_inventory.gameObject);
            }
        }
    }
    void Show(GameObject gameObject)
    {
        gameObject.SetActive(true);
        _itemDescription.ResetDescription();

        ResetSelection();
    }
    void ResetSelection()
    {
        _itemDescription.ResetDescription();
        _inventory.DeselectAllItems();
    }
    void Hide(GameObject gameObject)
    {
        _panel.Toggle(false);
        gameObject.SetActive(false);
        _inventory.ResetDraggedItem();
        
    }
}
