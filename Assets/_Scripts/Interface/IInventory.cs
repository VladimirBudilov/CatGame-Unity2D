using System;

public interface IInventory
{
    int capacity { get; set; }
    bool isFull { get; }

    IInventoryItem GetItem(Type itemType);
    IInventoryItem[] GetAllItems();
    IInventoryItem[] getAllItems(Type itemType);
    IInventoryItem[] GetEquippedItems();
    int GetItemAmount(Type itemTYpe);

    bool TryToAdd(object sender, IInventoryItem item);
    void Remove(object sender, Type itemType, int amount = 1);
    bool HasItem(Type type, out IInventoryItem item);
}
