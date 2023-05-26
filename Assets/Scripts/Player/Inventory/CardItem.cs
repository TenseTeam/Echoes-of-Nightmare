namespace ProjectEON.InventorySystem.Items
{
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Units;
    using ProjectEON.Managers;

    public class CardItem : ItemBase
    {
        private CardItemData _cardItemData;

        public CardItem(ItemBaseData item, Inventory inventory) : base(item, inventory)
        {
            _cardItemData = item as CardItemData;
        }

        public override void Use()
        {
            foreach (PlayerUnitManager unitManager in GameManager.Instance.CombatManager.PlayerPartyComposer.InFightUnitsManager.GetComposedUnits())
            {
                if (unitManager.UnitData.UnitName == _cardItemData.UnitDataOwner.UnitName)
                {
                    unitManager.UnitDeck.CardDatas.Add(_cardItemData.CardData);
                    unitManager.UnitHand.GenerateCard(_cardItemData.CardData);
                    return;
                }
            }
        }
    }
}