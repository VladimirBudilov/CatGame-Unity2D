using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PIckUpSystem : MonoBehaviour
{
    [SerializeField] private InventorySO _inventoryData;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Item item = collision.GetComponent<Item>();
        if (item != null)
        {
            int reminder = _inventoryData.AddItem(item.InventoryItem, item.Amount);
            if (reminder == 0)
                item.DestroyItem();
            else
                item.Amount = reminder;
        }
    }

    public void AddItem(Quest.Reward item)
    {
        _inventoryData.AddItem(item.item, item.number);
    }
}
