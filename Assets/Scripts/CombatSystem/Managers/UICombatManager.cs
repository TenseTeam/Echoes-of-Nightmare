namespace ProjectEON.CombatSystem.Managers
{
    using System;
    using UnityEngine;
    using ProjectEON.SOData.Structures.Enums;
    using ProjectEON.CombatSystem.Units.Hand;

    public class UICombatManager : MonoBehaviour
    {
        [SerializeField] private TargetManager _targetManager;
        [SerializeField] private GameObject _indicatorPlayerParty, _indicatorEnemyParty;

        private void OnEnable()
        {
            _targetManager.OnCheckValidTargets += ShowIndicatorValidTargets;
            _targetManager.OnTargetAcquisitionCompleted += DisableIndicators;
        }

        private void OnDisable()
        {
            _targetManager.OnCheckValidTargets -= ShowIndicatorValidTargets;
        }

        private void ShowIndicatorValidTargets(UnitCard card)
        {
            // That's simply logic cause only the player when selecting the card
            // will show the indicators and the SameParty value for the UnitCard cards means the PlayerParty
            _indicatorPlayerParty.SetActive(card.Data.SkillTarget.HasFlag(SkillTarget.SameParty));
            _indicatorEnemyParty.SetActive(card.Data.SkillTarget.HasFlag(SkillTarget.OpponentParty));
        }

        private void DisableIndicators()
        {
            _indicatorPlayerParty.SetActive(false);
            _indicatorEnemyParty.SetActive(false);
        }
    }
}