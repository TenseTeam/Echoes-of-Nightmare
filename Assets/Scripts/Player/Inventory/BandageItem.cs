namespace ProjectEON.InventorySystem.Items
{
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.Managers;
    using ProjectEON.SOData;

    public class BandageItem : ItemBase
    {
        private BandageItemData _bandageItemData;

        public BandageItem(ItemBaseData item, Inventory inventory) : base(item, inventory)
        {
        }

        public override void Use()
        {
            foreach (UnitManager unit in GameManager.Instance.CombatManager.PlayerPartyComposer.InFightUnitsManager.GetComposedUnits())
            {
                unit.Unit.HealHitPoints(_bandageItemData.AmountOfCure);
            }

            Inventory.RemoveFromInventory(this);
        }
    }
}
