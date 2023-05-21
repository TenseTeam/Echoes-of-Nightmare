namespace ProjectEON.CombatSystem.Units.Hand
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;
    using TMPro;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Managers;
    using Extension.Patterns.ObjectPool.Interfaces;
    using Extension.Patterns.ObjectPool;

    [RequireComponent(typeof(Image), typeof(Animator))]
    public class UnitCard : MonoBehaviour, IPointerDownHandler, IPooledObject
    {
        private const string SelectTriggerParameter = "Selected";

        [Header("Images")]
        [SerializeField] private Image _cardIconImage;

        [Header("Texts")]
        [SerializeField] private TMP_Text _cardDescriptionText;
        [SerializeField] private TMP_Text _cardNameText;
        [SerializeField] private TMP_Text _cardAttackText;
        [SerializeField] private TMP_Text _cardCriticalChanceText;
        [SerializeField] private TMP_Text _cardTurnsText;

        private Animator _anim;
        private Image _cardFrameImage;

        public UnitHand RelatedHand { get; private set; }
        public CardData Data { get; private set; }
        public Pool RelatedPool { get; private set; }

        private void Awake ()
        {
            TryGetComponent(out _anim);
            TryGetComponent(out _cardFrameImage);
        }

        public void Init(CardData data, UnitHand relatedHand, Pool relatedPool)
        {
            AssociatePool(relatedPool);
            RelatedHand = relatedHand;
            Data = data;
            transform.name = "Card " + Data.name;

            SetUpText(data);
            SetUpImages(data);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            SendToTargetManager();
        }

        public void SendToTargetManager()
        {
            SetSelectAnimation(true);
            CombatManager.Instance.TargetManager.SelectCard(this);
        }

        public void SetSelectAnimation(bool enabled)
        {
            _anim.SetBool(SelectTriggerParameter, enabled);
        }

        public void AssociatePool(Pool associatedPool)
        {
            RelatedPool = associatedPool;
        }

        public void Dispose()
        {
            RelatedPool.Dispose(gameObject);
        }
        
        private void SetUpText(CardData data)
        {
            _cardDescriptionText.text = data.Description;
            _cardNameText.text = data.CardName;
            _cardAttackText.text = $"{data.Power.Min} ~ {data.Power.Max}";
            _cardCriticalChanceText.text = $"{data.CriticalChance}%";
            UpdateTurnsText(data.RechargeTime);
        }

        private void SetUpImages(CardData data)
        {
            _cardIconImage.sprite = Data.SkillSprite;
            _cardFrameImage.sprite = Data.CardFrameSprite;
        }

        private void UpdateTurnsText(int remainingTurns)
        {
            _cardTurnsText.text = remainingTurns.ToString();
        }
    }
}