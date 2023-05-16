using ProjectEON.SOData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{
    [SerializeField]private UnitData[] m_EnemyArray;
    //private Party m_EnemyParty

    private void Start()
    {
        //m_EnemyParty = GetComponent<Party>
    }

    public void Initialize(UnitData[] enemyArray)
    {
        m_EnemyArray = new UnitData[enemyArray.Length];
        m_EnemyArray = enemyArray;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IPlayer iplayer))
        {

        }
    }
}
