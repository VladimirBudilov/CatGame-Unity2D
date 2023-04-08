   using System;
   using System.Collections;
using System.Collections.Generic;
using UnityEngine;
   using UnityEngine.UI;

   public class UIInventory : MonoBehaviour
{
    [SerializeField] private UIInventoryItem _item;
    [SerializeField] private RectTransform _contentPanel;
    [SerializeField] private MouseFollower _mouse;
    [SerializeField] private UIItemActionPanel _panel;
    
    private UIInventoryDescription _itemDescription;
    public List<UIInventoryItem> listUIItems = new List<UIInventoryItem>();
    private int _curentlyDraggedItemIndex = -1;
    
    public event Action<int> OnDescriptionRequestedAction,
        OnItemActionRequestedAction,
        OnStartDraggingAction;

    public event Action<int, int> OnSwapItemsAction; 
    private void Awake()
    {
        _itemDescription = GetComponentInChildren<UIInventoryDescription>();
        
        _mouse.Toggle(false);
        _itemDescription.ResetDescription();
    }
    public void InitializedInventoryUI(int size)
    {
        for (int i = 0; i < size; i++)
        {
            UIInventoryItem uiItem = Instantiate(_item, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(_contentPanel);
            listUIItems.Add(uiItem);

            uiItem.OnItemClickedAction += ItemClicked;
            uiItem.OnItemBeginDragAction += ItemBeginDrag;
            uiItem.OnItemDroppedOnAction += ItemDroppedOn;
            uiItem.OnItemEndDragAction += ItemEndDrag;
            uiItem.OnRightMouseBtnClickEvent += RightMouseBtnClick;
        }
    }
    public void UpdateData(int itemIndex, Sprite itemImage, int itemAmount)
    {
        if (listUIItems.Count > itemIndex) listUIItems[itemIndex].SetData(itemImage, itemAmount);
    }
    private void RightMouseBtnClick(UIInventoryItem uiInventoryItem)
    {
        int index = listUIItems.IndexOf(uiInventoryItem);
        if (index == -1)
        {
            return;
        }
        OnItemActionRequestedAction?.Invoke(index);
    }
    private void ItemBeginDrag(UIInventoryItem uiInventoryItem)
    {
        int index = listUIItems.IndexOf(uiInventoryItem);
        if (index == -1)
        {
            return;
        }
        _curentlyDraggedItemIndex = index;
        ItemClicked(uiInventoryItem);
        OnStartDraggingAction?.Invoke(index);
    }
    public void CreateDraggedItem(Sprite sprite, int amount)
    {
        _mouse.Toggle(true);
        _mouse.SetData(sprite, amount);
    }
    private void ItemEndDrag(UIInventoryItem uiInventoryItem)
    {
        ResetDraggedItem(); 
    }
    private void ItemDroppedOn(UIInventoryItem uiInventoryItem)
    {
        int index = listUIItems.IndexOf(uiInventoryItem);
        if (index == -1)
        { 
            return;
        }
        OnSwapItemsAction?.Invoke(_curentlyDraggedItemIndex, index);
        ItemClicked(uiInventoryItem);
    }
    public void ResetDraggedItem()
    {
        _mouse.Toggle(false);
        _curentlyDraggedItemIndex = -1;
    }
    private void ItemClicked(UIInventoryItem uiInventoryItem)
    {
        int index = listUIItems.IndexOf(uiInventoryItem);
        if (index == 1)
        {
            return;
        }
        OnDescriptionRequestedAction?.Invoke(index);
    }
    public void UpdateDescription(Sprite itemImage, string itemName, string itemDescription)
    {
        _itemDescription.SetDescription(itemImage, itemName, itemDescription);
    }
    public void ResetAllItems()
    {
        foreach (var item in listUIItems)
        {
            item.ResetData();
        }
    }
    public void DeselectAllItems()
    {
        _panel.Toggle(false);
    }
    public void AddAction(string actionName, Action performAction)
    {
        _panel.AddButton(actionName, performAction);
    }
    public void ShowItemAction(int itemIndex)
    {
        _panel.Toggle(true);
        _panel.transform.position = listUIItems[itemIndex].transform.position;
    }
}
