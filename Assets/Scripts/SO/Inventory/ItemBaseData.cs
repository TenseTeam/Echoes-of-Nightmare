namespace ProjectEON.SOData
{
    using UnityEngine;
    using ProjectEON.SOData.Structures.Enums;

    [CreateAssetMenu(menuName = "Item/Generic Item")]
    public class ItemBaseData : ScriptableObject
    {
        public string ItemName;
        public string Description;
        public Sprite ItemSprite;
        public ItemType Type;
    }
}
