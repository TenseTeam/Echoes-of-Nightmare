namespace ProjectEON.CombatSystem.Units.Hand
{
    using UnityEngine;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Pools;
    using UnityEngine.UI;

    public class UnitHand : MonoBehaviour
    {
        [SerializeField] private GameObject _baseHandLayoutPrefab;
        private CardsPool _cardsPool;
        private RectTransform _relatedHandRectTransform;
        private GameObject _handLayout;
        private string _handName;

        public UnitManager RelatedUnitManager { get; private set; }

        public void Init(string handName, RectTransform relatedTransform, UnitManager relatedUnit, CardsPool cardsPool)
        {
            _cardsPool = cardsPool;
            _handName = handName;
            _relatedHandRectTransform = relatedTransform;
            RelatedUnitManager = relatedUnit;
            InstantiateHand();
        }

        public void SetActiveHand(bool active)
        {
            if (!_handLayout)
                return;

            _handLayout.SetActive(active);
        }

        private void InstantiateHand()
        {
            _handLayout = Instantiate(_baseHandLayoutPrefab, _relatedHandRectTransform.position, Quaternion.identity, _relatedHandRectTransform);
            _handLayout.transform.name = _handName;
            SetUpSkipButton();
            GenerateCards();
            SetActiveHand(false);
        }

        private void GenerateCards()
        {
            foreach (CardSkillData skillData in RelatedUnitManager.UnitData.Skills) // TO DO Deck class here instead of Data.Skills
            {
                GameObject cardGO = _cardsPool.Get();
                cardGO.transform.SetParent(_handLayout.transform);

                if (cardGO.TryGetComponent(out UnitCard card))
                {
                    card.Init(skillData, this, _cardsPool);
                }
            }
        }

        private void SetUpSkipButton()
        {
            if (TryGetSkipButton(out Button btn))
            {
                btn.onClick.AddListener(() => RelatedUnitManager.UnitTurns.NextState());
            }
        }

        private bool TryGetSkipButton(out Button button)
        {
            return _handLayout.transform.GetChild(0).TryGetComponent(out button);
        }
    }
}