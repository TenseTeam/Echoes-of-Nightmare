namespace ProjectEON.CombatSystem.Units
{
    using System.Linq;
    using System.Collections.Generic;
    using UnityEngine;
    using ProjectEON.Managers;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Managers;

    [RequireComponent(typeof(EnemyUnitManager))]
    public class EnemyUnitAI : MonoBehaviour
    {
        private EnemyUnitManager _enemyUnitManager;

        private void Awake()
        {
            TryGetComponent(out _enemyUnitManager);
        }

        public void AttackRandomTarget()
        {
            SkillData skill = GetRandomSkill();

            if(TryGetValidTarget(skill, out UnitManager targetedUnit))
            {
                GameManager.Instance.CombatManager.AttacksManager.UseSkillOnUnit(_enemyUnitManager, skill, targetedUnit);
                return;
            }
        }

        private bool TryGetValidTarget(SkillData skill, out UnitManager targetedUnit)
        {
            List<UnitManager> playerUnits = GameManager.Instance.CombatManager.PlayerPartyComposer.InFightUnitsManager.GetComposedUnits();
            List<UnitManager> enemyUnits = GameManager.Instance.CombatManager.EnemyPartyComposer.InFightUnitsManager.GetComposedUnits();

            List<UnitManager> targetsList = playerUnits.Concat(enemyUnits).ToList();

            List<UnitManager> possibleTargets = GetPossibleTargets(skill, targetsList);

            if(possibleTargets.Count <= 0)
            {
                targetedUnit = null;
                return false;
            }

            targetedUnit = possibleTargets[Random.Range(0, possibleTargets.Count)];
            return true;
        }

        private List<UnitManager> GetPossibleTargets(SkillData skill, List<UnitManager> allUnits)
        {
            List<UnitManager> possibleTargets = new List<UnitManager>();
            
            foreach(UnitManager unitPossibleTarget in allUnits)
            {
                if(GameManager.Instance.CombatManager.TargetManager.IsValidTargetUnit(_enemyUnitManager, skill, unitPossibleTarget))
                {
                    possibleTargets.Add(unitPossibleTarget);
                    Debug.Log("Possible Target found " + unitPossibleTarget.UnitData.UnitName);
                }
            }

            return possibleTargets;
        }

        private SkillData GetRandomSkill()
        {
            return _enemyUnitManager.UnitData.Skills[Random.Range(0, _enemyUnitManager.UnitData.Skills.Count)];
        }
    }
}