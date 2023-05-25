namespace ProjectEON.CombatSystem.Managers
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    using ProjectEON.SOData.Structures.Enums;
    using ProjectEON.CombatSystem.Units.CardsSystem;
    using ProjectEON.CombatSystem.Units;
    using System;
    using ProjectEON.SOData;

    public class TargetManager : MonoBehaviour
    {
        private UnitCard _selectedCard;
        private Unit _selectedTargetUnit;

        [field: SerializeField]
        public AttacksManager AttacksManager { get; private set; }

        public event Action<UnitCard> OnCheckValidTargets;
        public event Action OnTargetAcquisitionCompleted;

        private void Update()
        {
            if (_selectedCard)
                CardSelecting();
        }

        public void SelectCard(UnitCard selectedCard)
        {
            OnTargetAcquisitionCompleted?.Invoke();

            if(_selectedCard && _selectedCard != selectedCard)
                _selectedCard.SetSelectAnimation(false);

            _selectedCard = selectedCard;
        }

        public bool IsValidTargetUnit(UnitManager unitManager, SkillData skillData, UnitManager selectedTargetUnit)
        {
            if (skillData.SkillTarget.HasFlag(SkillTarget.Everything))
            {
                return true;
            }

            if (skillData.SkillTarget.HasFlag(SkillTarget.Self))
            {
                return unitManager == selectedTargetUnit;
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

        private void CardSelecting()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject()) // There is no need to check what is clicking in the 3d world anymore 
                {
                    Debug.Log("AAA");
                    OnCheckValidTargets?.Invoke(_selectedCard);    // because the UnitCard knows when the pointer is clicking on it
                    return;                                        // Otherwise it will instantly deselect the card 'cause the raycast won't hit a UI gameobject
                }

                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    if (_selectedCard && hit.transform.TryGetComponent(out UnitManager targetedUnit))
                    {
                        TargetAttackUnit(targetedUnit);
                    }
                }

                SelectCard(null);
            }
        }

        private void TargetAttackUnit(UnitManager targetedUnit)
        {
            if (IsValidTargetUnit(_selectedCard.RelatedHand.RelatedUnitManager, _selectedCard.Data, targetedUnit))
            {
                UnitManager unitAttacker = _selectedCard.RelatedHand.RelatedUnitManager;
                AttacksManager.UseSkillOnUnit(unitAttacker, _selectedCard.Data, targetedUnit);
                _selectedCard.UseCard();
                unitAttacker.UnitTurns.NextState();
            }
        }

        private bool IsSameParty(UnitManager unitManager, SkillData skillData, UnitManager targetUnit)
        {
            return unitManager.Party == targetUnit.Party;
        }
    }
}