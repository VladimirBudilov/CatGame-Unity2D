using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visibility : MonoBehaviour
{
    [Header("Inventory pref")] 
    [SerializeField] private GameObject _inventory;
    
    [Header("Visibility")]
    [SerializeField] private bool _inventoryVisible;

    private void Awake()
    {
        _inventoryVisible = false;
        _inventory.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SwitchVisible();
        }
    }
    void SwitchVisible()
    { 
        _inventoryVisible = !_inventoryVisible;
        _inventory.gameObject.SetActive(_inventoryVisible);
    }
}
