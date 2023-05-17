namespace ProjectEON.CombatSystem.Units
{
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.SOData;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    [RequireComponent(typeof(EnemyUnitManager))]
    public class EnemyUnitAI : MonoBehaviour
    {
        private EnemyUnitManager _enemyUnitManager;

        private void Awake()
        {
            _enemyUnitManager = GetComponent<EnemyUnitManager>();
        }

        public void AttackRandomTarget()
        {
            SkillData skill = GetRandomSkill();

            Debug.Log("Want to attack with " + skill.name);

            if(TryGetValidTarget(skill, out UnitManager targetedUnit))
            {
                CombatManager.Instance.AttacksManager.UseSkillOnUnit(skill, targetedUnit);
                return;
            }

            //Debug.LogWarning($"A Target for the skill {skill} of {_enemyUnitManager.UnitData.UnitName} could not be found!");
        }

        private bool TryGetValidTarget(SkillData skill, out UnitManager targetedUnit)
        {
            List<UnitManager> playerUnits = CombatManager.Instance.PlayerPartyComposer.InFightUnitsManager.GetComposedUnits();
            List<UnitManager> enemyUnits = CombatManager.Instance.EnemyPartyComposer.InFightUnitsManager.GetComposedUnits();

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
                if(CombatManager.Instance.TargetManager.IsValidTargetUnit(_enemyUnitManager, skill, unitPossibleTarget))
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