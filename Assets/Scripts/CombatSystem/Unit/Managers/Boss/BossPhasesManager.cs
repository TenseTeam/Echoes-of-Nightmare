namespace ProjectEON.CombatSystem.Unit.Managers.Boss
{
    using UnityEngine;
    using ProjectEON.SOData;
    using ProjectEON.CombatSystem.Units;

    public class BossPhasesManager : MonoBehaviour
    {
        public int CurrentPhase { get; private set; }
        public int PhasesCount => _data.Phases.Count;
        public bool HasNoMorePhases => PhasesCount <= CurrentPhase;

        private BossData _data;
        private BossUnitManager _bossManager;

        public void Init(BossUnitManager bossManager, BossData data)
        {
            _data = data;
            _bossManager = bossManager;
        }

        public void NextPhase()
        {
            if (HasNoMorePhases) return;

            _bossManager.ReInit(_data.Phases[CurrentPhase]);
            CurrentPhase++;
        }
    }
}