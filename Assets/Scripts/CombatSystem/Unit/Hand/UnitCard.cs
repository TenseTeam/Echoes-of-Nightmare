namespace ProjectEON.CombatSystem.Units.Hand
{
    using ProjectEON.SOData;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    [RequireComponent(typeof(Image))]
    public class UnitCard : MonoBehaviour
    {
        [SerializeField] private Image _cardSkillImage;
        [SerializeField] private TMP_Text _cardDescriptionText;
        private SkillData _data;
        private UnitHand _relatedHand;

        public void Init(SkillData data, UnitHand relatedHand)
        {
            _relatedHand = relatedHand;
            _data = data;
            transform.name = "Card " + _data.name;
            _cardDescriptionText.text = _data.description;
            _cardSkillImage.sprite = _data.skillSprite;
        }

        //Methods for using this card will go here, that will call the CombatManger.AttacksManager
    }
}