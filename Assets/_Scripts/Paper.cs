using System;



    public class Paper : IInventoryItem
    {
        public IInventoryItemInfo info { get; }
        public IInventoryItemState state { get; }
        public Type type { get; }
        
        public Paper(IInventoryItemInfo info)
        {
            this.info = info;
            state = new InventoryItemState();
        }
        public IInventoryItem Clone()
        {
            var clonedPaper = new Paper(info);
            clonedPaper.state.amount = state.amount;
            return clonedPaper;
        }
    }
