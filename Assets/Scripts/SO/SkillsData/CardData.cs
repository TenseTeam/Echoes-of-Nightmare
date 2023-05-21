namespace ProjectEON.SOData
{
    using UnityEngine;

    [CreateAssetMenu(menuName = "Skills/CardData")]
    public class CardData : SkillData
    {
        public int RechargeTime;

        [Header("Graphic")]
        public Sprite CardFrameSprite;
        public Sprite SkillSprite;

        [Header("Info")]
        public string CardName;
        [TextArea(3, 10)]
        public string Description;
    }
}