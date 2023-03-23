using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testerr : MonoBehaviour
{
    [SerializeField] private InventoryItemInfo _item;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GlobalEventManager.SayGetItemInInventory( _item);
        }
    }
}
