using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour, IPointerClickHandler,
    IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
{
     [SerializeField] private Image _itemImage;
     [SerializeField] private TMP_Text _text;
     
     private bool _isEmpty;

     public event Action<UIInventoryItem> OnItemClickedAction, 
         OnItemDroppedOnAction, OnItemBeginDragAction, OnItemEndDragAction, OnRightMouseBtnClickEvent;
     private void Awake()
     {
         ResetData();
     }

     public void ResetData()
     {
         _itemImage.gameObject.SetActive(false);
         _isEmpty = true;
     }

     public void SetData(Sprite sprite, int amount)
     {
         _itemImage.gameObject.SetActive(true);
         _itemImage.sprite = sprite;
         _text.text = amount + "";
         _isEmpty = false;
     }
     public void OnPointerClick(PointerEventData pointerData)
     {
         if (pointerData.button == PointerEventData.InputButton.Right)
         {
             OnRightMouseBtnClickEvent?.Invoke(this);
         }
         else
         {
             OnItemClickedAction?.Invoke(this);
         }
     }

     public void OnBeginDrag(PointerEventData eventData)
     {
         if (_isEmpty)
         {
             return;
         }
         OnItemBeginDragAction?.Invoke(this);
     }

     public void OnEndDrag(PointerEventData eventData)
     {
         OnItemEndDragAction?.Invoke(this);
     }

     public void OnDrop(PointerEventData eventData)
     {
         OnItemDroppedOnAction?.Invoke(this);
     }

     public void OnDrag(PointerEventData eventData)
     {
     }
}
