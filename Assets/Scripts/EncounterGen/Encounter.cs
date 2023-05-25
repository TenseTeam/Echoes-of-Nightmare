using ProjectEON.Managers;
using ProjectEON.PartySystem;
using ProjectEON.SOData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    [SerializeField]private UnitData[] m_EnemyArray;
    private EnemyParty m_EnemyParty;
    
    private void Awake()
    {
        m_EnemyParty = GetComponent<EnemyParty>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IPlayer iplayer))
        {
            //GameManager.Instance.CameraSwapperManager.SwapToCombat();
            GameManager.Instance.CombatManager.BeginBattle(m_EnemyParty);
            GameManager.Instance.InputManager.BattleInputEnable();
            GameManager.Instance.UIManager.SetActiveWorldUI(false);
            Destroy(transform.parent.gameObject);
        }
    }
}
