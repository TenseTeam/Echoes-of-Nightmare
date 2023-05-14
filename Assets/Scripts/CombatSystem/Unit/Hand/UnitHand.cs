namespace ProjectEON.CombatSystem.Units.Hand
{
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.CombatSystem.Pools;
    using ProjectEON.SOData;
    using System.Collections.Generic;
    using UnityEngine;

    public class UnitHand : MonoBehaviour
    {
        [SerializeField] private GameObject _baseHandLayoutPrefab;

        private List<SkillData> _skillsData;
        private RectTransform _relatedHandRectTransform;
        private GameObject _handLayout;
        private string _handName;
        private CardsPool _cardsPool;

        // TO DO - Deck class that contains all the default skills + the unlocekd skills

        public void Init(string handName, RectTransform relatedTransform, List<SkillData> skillsData, CardsPool cardsPool)
        {
            _cardsPool = cardsPool;
            _handName = handName;
            _relatedHandRectTransform = relatedTransform;
            _skillsData = skillsData;
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
            //No need to pool the hand since the UnitHands will be generated once at the beginning.
            GameObject handLayoutGO = Instantiate(_baseHandLayoutPrefab, _relatedHandRectTransform.position, Quaternion.identity, _relatedHandRectTransform);
            handLayoutGO.transform.name = _handName;

            foreach (CardSkillData skillData in _skillsData)
            {
                //GameObject cardGO = Instantiate(_baseCardPrefab, handLayoutGO.transform.position, Quaternion.identity, handLayoutGO.transform);
                GameObject cardGO = _cardsPool.Get(handLayoutGO.transform);

                if (cardGO.TryGetComponent(out UnitCard card))
                {
                    card.Init(skillData, this, _cardsPool);
                }
            }

            _handLayout = handLayoutGO;
            SetActiveHand(false);
        }
    }
}