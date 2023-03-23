using System;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private InventoryItemInfo _appleInfo;
    [SerializeField] private InventoryItemInfo _pepperInfo;
    public InventoryWithSlots inventory => tester.inventory;

    private UIInventoryTester tester;

    private void Awake()
    {
        var uiSlots = GetComponentsInChildren<UIInventorySlot>();
        tester = new UIInventoryTester(_appleInfo, _pepperInfo, uiSlots);
        tester.FillSlots();
    }
}