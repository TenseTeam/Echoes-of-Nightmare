using UnityEngine;
using ProjectEON.SOData;

[CreateAssetMenu(menuName = "Item/ItemCard")]
public class CardItemData : ItemBaseData
{
    public CardSkillData CardData;
    public UnitData UnitDataOwner;
}
