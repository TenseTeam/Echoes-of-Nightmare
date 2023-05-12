namespace ProjectEON.CombatSystem.Units.Hand
{
    using ProjectEON.SOData;
    using System.Collections.Generic;
    using UnityEngine;

    public class UnitHand : MonoBehaviour
    {
        [SerializeField] private GameObject _baseHandLayoutPrefab;
        [SerializeField] private GameObject _baseCardPrefab;
        private List<SkillData> _skillsData;
        private RectTransform _relatedHandRectTransform;
        private GameObject _handLayout;
        private string _handName;

        public void Init(string handName, RectTransform relatedTransform, List<SkillData> skillsData)
        {
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
            //Maybe it is poosible to pool these cards.
            GameObject handLayoutGO = Instantiate(_baseHandLayoutPrefab, _relatedHandRectTransform.position, Quaternion.identity, _relatedHandRectTransform);
            handLayoutGO.transform.name = _handName;

            foreach (SkillData skillData in _skillsData)
            {
                GameObject cardGO = Instantiate(_baseCardPrefab, handLayoutGO.transform.position, Quaternion.identity, handLayoutGO.transform);

                if (cardGO.TryGetComponent(out UnitCard card))
                {
                    card.Init(skillData, this);
                }
            }

            _handLayout = handLayoutGO;
            SetActiveHand(false);
        }
    }
}