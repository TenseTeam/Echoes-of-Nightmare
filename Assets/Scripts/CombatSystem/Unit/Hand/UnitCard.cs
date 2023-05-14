namespace ProjectEON.CombatSystem.Units.Hand
{
    using ProjectEON.SOData;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using UnityEngine.EventSystems;
    using ProjectEON.CombatSystem.Managers;

    [RequireComponent(typeof(Image), typeof(Animator))]
    public class UnitCard : MonoBehaviour, IPointerDownHandler
    {
        private const string SelectTriggerParameter = "Selected";

        [Header("Images")]
        [SerializeField] private Image _cardSkillImage;
        //[SerializeField] private Image _cardSkillFrameImage;

        [Header("Texts")]
        [SerializeField] private TMP_Text _cardDescriptionText;
        [SerializeField] private TMP_Text _cardNameText;
        private UnitHand _relatedHand;
        private Animator _anim;

        public CardSkillData Data { get; private set; }

        private void Start ()
        {
            _anim = GetComponent<Animator>();
        }

        public void Init(CardSkillData data, UnitHand relatedHand)
        {
            _relatedHand = relatedHand;
            Data = data;
            transform.name = "Card " + Data.name;
            _cardDescriptionText.text = Data.Description;
            _cardNameText.text = Data.SkillName;
            _cardSkillImage.sprite = Data.SkillSprite;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Select();
        }

        public void Select()
        {
            _anim.SetBool(SelectTriggerParameter, true);
            CombatManager.Instance.TargetManager.SelectCard(this);
        }

        public void Deselect()
        {
            _anim.SetBool(SelectTriggerParameter, false);
        }

        //Methods for using this card will go here, that will call the CombatManger.AttacksManager
    }
}