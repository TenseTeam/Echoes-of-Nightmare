using System.Collections;
namespace ProjectEON.InventorySystem.Items
{
    public class ItemBase
    {
        protected ItemBaseData Data;
        protected Inventory Inventory;

        public ItemBaseData ItemData => Data;

        public ItemBase(ItemBaseData item, Inventory inventory)
        {
            Data = item;
            Inventory = inventory;
        }

        public virtual void Use() { }
    }
}
