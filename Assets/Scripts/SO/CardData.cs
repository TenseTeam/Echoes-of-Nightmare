namespace ProjectEON.SOData
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "CardData")]
    public class CardData : SkillData
    {
        [Header("Graphic")]
        public Sprite CardFrameSprite;
        public Sprite SkillSprite;

        [Header("Info")]
        public string CardName;
        [TextArea(3, 10)]
        public string Description;
    }
}