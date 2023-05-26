using UnityEngine;
namespace ProjectEON.SOData
{
    [CreateAssetMenu(menuName = "Item/Card")]
    public class CardItemData : ItemBaseData
    {
        public CardSkillData CardData;
        public UnitData UnitDataOwner;
    }
}