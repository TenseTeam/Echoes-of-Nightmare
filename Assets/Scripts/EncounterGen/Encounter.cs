namespace ProjectEON.EncounterSystem
{
    using UnityEngine;
    using ProjectEON.Managers;
    using ProjectEON.PartySystem;
    using ProjectEON.GenericInterfaces;

    public class Encounter : MonoBehaviour
    {
        private EnemyParty _enemyParty;

        private void Awake()
        {
            TryGetComponent(out _enemyParty);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IPlayer iplayer))
            {
                GameManager.Instance.CombatManager.BeginBattle(_enemyParty);
                GameManager.Instance.InputManager.BattleInputEnable();
                GameManager.Instance.UIManager.SetActiveWorldUI(false);
                Destroy(transform.parent.gameObject);
            }
        }
    }
}