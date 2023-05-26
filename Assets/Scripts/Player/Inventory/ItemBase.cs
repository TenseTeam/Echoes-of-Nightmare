using ProjectEON.SOData;
namespace ProjectEON.InventorySystem.Items
{
    using System.Collections;

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
