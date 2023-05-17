namespace ProjectEON.CombatSystem.Managers
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using ProjectEON.SOData.Structures.Enums;
    using ProjectEON.CombatSystem.Units.Hand;
    using ProjectEON.CombatSystem.Units;
    using System;
    using ProjectEON.SOData;

    public class TargetManager : MonoBehaviour
    {
        [field: SerializeField]
        public AttacksManager AttacksManager { get; private set; }

        private UnitCard _selectedCard;
        private Unit _selectedTargetUnit;

        public event Action<UnitCard> OnCheckValidTargets;
        public event Action OnTargetAcquisitionCompleted;

        public void SelectCard(UnitCard selectedCard)
        {
            OnTargetAcquisitionCompleted?.Invoke();

            if(_selectedCard && _selectedCard != selectedCard)
                _selectedCard.SetSelectAnimation(false);

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
                                if (IsValidTargetUnit(_selectedCard.RelatedHand.RelatedUnitManager, _selectedCard.Data, targetedUnit))
                                {
                                    // _selectedCard.Dispose(); -> TO DO it won't dispose itself but disable itself with turns
                                    OnTargetAcquisitionCompleted?.Invoke();
                                    AttacksManager.UseSkillOnUnit(_selectedCard.Data, targetedUnit);
                                    _selectedCard.RelatedHand.RelatedUnitManager.UnitTurns.NextState(); // Goes to the next state
                                }
                            }
                        }
                        SelectCard(null);
                    }
                }
            }
        }

        public bool IsValidTargetUnit(UnitManager unitManager, SkillData skillData, UnitManager selectedTargetUnit)
        {
            if (skillData.SkillTarget.HasFlag(SkillTarget.Everything))
            {
                return true;
            }

            if (skillData.SkillTarget.HasFlag(SkillTarget.SameParty))
            {
                return IsSameParty(unitManager, skillData, selectedTargetUnit);
            }

            if (skillData.SkillTarget.HasFlag(SkillTarget.OpponentParty))
            {
                return !IsSameParty(unitManager, skillData, selectedTargetUnit);
            }

            return false;
        }

        private bool IsSameParty(UnitManager unitManager, SkillData skillData, UnitManager targetUnit)
        {
            return unitManager.Party == targetUnit.Party;
        }
    }
}