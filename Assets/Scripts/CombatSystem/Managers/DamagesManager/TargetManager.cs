namespace ProjectEON.CombatSystem.Managers
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using ProjectEON.SOData.Structures.Enums;
    using ProjectEON.CombatSystem.Units.Hand;
    using ProjectEON.CombatSystem.Units;
    using System;

    public class TargetManager : MonoBehaviour
    {
        [field: SerializeField]
        public AttacksManager AttackManager { get; private set; }

        private UnitCard _selectedCard;
        private Unit _selectedTargetUnit;

        public event Action<UnitCard> OnCheckValidTargets;
        public event Action OnTargetAcquisitionCompleted;

        public void SelectCard(UnitCard selectedCard)
        {
            OnTargetAcquisitionCompleted?.Invoke();

            if(_selectedCard && _selectedCard != selectedCard)
                _selectedCard.Deselect();

            _selectedCard = selectedCard;
        }

        private void Update()
        {
            if (_selectedCard)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (EventSystem.current.IsPointerOverGameObject()) // There is no need to check what is clicking in the 3d world anymore 
                    {
                        OnCheckValidTargets?.Invoke(_selectedCard);    // because the UnitCard knows when the pointer is clicking on it
                        return;                                        // Otherwise it will instantly deselect the card 'cause the raycast won't hit a UI gameobject
                    }

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (_selectedCard)
                        {
                            if (hit.transform.TryGetComponent(out UnitManager targetedUnit))
                            {
                                if (IsValidTargetUnit(_selectedCard, targetedUnit))
                                {
                                    // _selectedCard.Dispose(); // it won't dispose itself but disable itself with turns
                                    OnTargetAcquisitionCompleted?.Invoke();
                                    AttackManager.UseSkillOnUnit(_selectedCard.Data, targetedUnit, () => _selectedCard.RelatedHand.RelatedUnitManager.UnitTurns.NextState());
                                }
                            }
                        }
                        SelectCard(null);
                    }
                }
            }
        }

        private bool IsValidTargetUnit(UnitCard card, UnitManager selectedTargetUnit)
        {
            if (card.Data.SkillTarget.HasFlag(SkillTarget.Everything))
            {
                return true;
            }

            if (card.Data.SkillTarget.HasFlag(SkillTarget.SameParty))
            {
                return IsSameParty(card, selectedTargetUnit);
            }

            if (card.Data.SkillTarget.HasFlag(SkillTarget.OpponentParty))
            {
                return !IsSameParty(card, selectedTargetUnit);
            }

            return false;
        }

        private bool IsSameParty(UnitCard card, UnitManager targetUnit)
        {
            return card.RelatedHand.RelatedUnitManager.Party == targetUnit.Party;
        }
    }
}