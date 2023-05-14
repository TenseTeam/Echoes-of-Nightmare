namespace ProjectEON.CombatSystem.Units.Hand
{
    using ProjectEON.SOData;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using UnityEngine.EventSystems;
    using ProjectEON.CombatSystem.Managers;
    using Extension.Patterns.ObjectPool.Interfaces;
    using Extension.Patterns.ObjectPool;

    [RequireComponent(typeof(Image), typeof(Animator))]
    public class UnitCard : MonoBehaviour, IPointerDownHandler, IPooledObject
    {
        private const string SelectTriggerParameter = "Selected";

        [Header("Images")]
        [SerializeField] private Image _cardSkillImage;
        //[SerializeField] private Image _cardSkillFrameImage;

        [Header("Texts")]
        [SerializeField] private TMP_Text _cardDescriptionText;
        [SerializeField] private TMP_Text _cardNameText;
        private Animator _anim;

        public UnitHand RelatedHand { get; private set; }
        public CardSkillData Data { get; private set; }

        public Pool RelatedPool { get; private set; }

        private void Start ()
        {
            _anim = GetComponent<Animator>();
        }

        public void Init(CardSkillData data, UnitHand relatedHand, Pool relatedPool)
        {
            AssociatePool(relatedPool);
            RelatedHand = relatedHand;
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

        public void AssociatePool(Pool associatedPool)
        {
            RelatedPool = associatedPool;
        }

        public void Dispose()
        {
            RelatedPool.Dispose(gameObject);
        }
        //Methods for using this card will go here, that will call the CombatManger.AttacksManager
    }
}