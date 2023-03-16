using System;

namespace _Scripts
{
    public class Apple : IInventoryItem
    {
        public bool isEquipped { get; set; }
        public Type type => GetType();
        public int maxItemsInInventorySlot { get; }
        public int amount { get; set; }

        public Apple(int maxItemsInInventorySlot)
        {
            this.maxItemsInInventorySlot = maxItemsInInventorySlot;
        }
        public IInventoryItem Clone()
        {
            return new Apple(maxItemsInInventorySlot)
            {
                amount = this.amount
            };
        }
    }
}