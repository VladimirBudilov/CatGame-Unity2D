
using System.Collections.Generic;
using _Scripts;
using UnityEngine;

public class UIInventoryTester
{
    private InventoryItemInfo _appleInfo;
    private InventoryItemInfo _paperInfo;
    private UIInventorySlot[] _uiSlots;
    
    public InventoryWithSlots inventory { get; }

    public UIInventoryTester(InventoryItemInfo appleInfo, InventoryItemInfo paperInfo, UIInventorySlot[] uiSlots)
    {
        _appleInfo = appleInfo;
        _paperInfo = paperInfo;
        _uiSlots = uiSlots;

        inventory = new InventoryWithSlots(15);
        inventory.OnInventoryStateChangedEvent += OnInventoryStateChanged;
    }

    public void FillSlots()
    {
        var allSlots = inventory.GetAllSlots();
        var availableSlots = new List<IInventorySlot>(allSlots);

        var filledSlots = 5;

        for (int i = 0; i < filledSlots; i++)
        {
            var filledSlot = AddRandomApplesIntoRandomSlot(availableSlots);
            availableSlots.Remove(filledSlot);
            
            filledSlot = AddRandomPepperIntoRandomSlot(availableSlots);
            availableSlots.Remove(filledSlot);
        }
        
        SetupInventoryUI(inventory);
    }

    IInventorySlot AddRandomApplesIntoRandomSlot(List<IInventorySlot> slots)
    {
        var rSlotIndex = Random.Range(0, slots.Count);
        var rSlot = slots[rSlotIndex];
        var rCount = Random.Range(1, 4);
        var apple = new Apple(_appleInfo);
        apple.state.amount = rCount;
        inventory.TryToAddToSlot(this, rSlot, apple);
        return rSlot;
    }
    
    IInventorySlot AddRandomPepperIntoRandomSlot(List<IInventorySlot> slots)
    {
        var rSlotIndex = Random.Range(0, slots.Count);
        var rSlot = slots[rSlotIndex];
        var rCount = Random.Range(1, 4);
        var pepper = new Paper(_paperInfo);
        pepper.state.amount = rCount;
        inventory.TryToAddToSlot(this, rSlot, pepper);
        return rSlot;
    }

    void SetupInventoryUI(InventoryWithSlots inventory)
    {
        var allSlots = inventory.GetAllSlots();
        var allSlotsCount = allSlots.Length;
        for (int i = 0; i < allSlotsCount; i++)
        {
            var slot = allSlots[i];
            var uiSlot = _uiSlots[i];
            uiSlot.SetSlot(slot);
            uiSlot.Refresh();
        }
    }
    void OnInventoryStateChanged(object sender)
    {
        foreach (var uiSlot in _uiSlots)
        {
            uiSlot.Refresh();
        }
    }
    
}
