using ProjectEON.SOData;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EncounterGenerator : MonoBehaviour
{
    [System.Serializable]
    public struct UnitSpawn
    {
        public UnitData Unit;
        public int Rate;
        public bool AtStart;
    }

    [Header("External objects")]
    [SerializeField] private GameObject m_SpawnList;
    [SerializeField] private List<UnitSpawn> m_EnemyList;
    [SerializeField] private UnitData m_EnemyJolly;
    [SerializeField] private GameObject m_PrefabEncounter;

    [Header("Setting for RNG")]
    [SerializeField] private int m_MinEncounter;
    [SerializeField] private int m_MaxEncounter;
    [SerializeField] private int m_MinEnemyForEncounter;
    [SerializeField] private int m_MaxEnemyForEncounter;

    private GameObject[] m_ListSpawnAreas;

    // Start is called before the first frame update
    void Start()
    {
        m_ListSpawnAreas = new GameObject[m_SpawnList.transform.childCount];
        for(int i = 0; i< m_ListSpawnAreas.Length; i++)
        {
            m_ListSpawnAreas[i] = m_SpawnList.transform.GetChild(i).gameObject;
        }

        GenerateSpawnPoints(true);
    }
    
    private void GenerateSpawnPoints(bool isStart)
    {
        List<UnitSpawn> actualList = new List<UnitSpawn>();
        foreach(UnitSpawn unitSpawn in m_EnemyList)
        {
            if (isStart)
            {
                if (unitSpawn.AtStart)
                    actualList.Add(unitSpawn);
            }
            else
                actualList.Add(unitSpawn);
        }

        actualList = actualList.OrderByDescending(x => x.Rate).ToList();
        

        foreach (GameObject SpawnArea in m_ListSpawnAreas)
        {
            int indexEncounter = Random.Range(m_MinEncounter, m_MaxEncounter);
            for(int i = 0; i < indexEncounter; i++)
            {
                Vector3 encounterPosition = GetRandomPointInsideCollider(SpawnArea.GetComponent<BoxCollider>());
                GameObject tmp = Instantiate(m_PrefabEncounter, SpawnArea.transform);
                tmp.transform.position = encounterPosition;

                int enemyCount = Random.Range(m_MinEnemyForEncounter, m_MaxEnemyForEncounter);
                UnitData[] enemyArray = new UnitData[enemyCount];
                
                for(int j = 0; j < enemyCount; j++)
                {
                    foreach(UnitSpawn enemy in actualList)
                    {
                        int rndEnemy = Random.Range(1, 100);
                        if(enemy.Rate >= rndEnemy)
                        {
                            enemyArray[j] = enemy.Unit;
                            break;
                        }
                    }
                    if (enemyArray[j] == null)
                        enemyArray[j] = m_EnemyJolly;
                }

                tmp.GetComponent<Encounter>().Initialize(enemyArray);
                //tmp.GetComponent<Party>().BuildParty(enemyArray);
            }
        }
    }

    private Vector3 GetRandomPointInsideCollider(BoxCollider boxCollider)
    {
        Vector3 extents = boxCollider.size / 2f;
        Vector3 point = new Vector3(
            Random.Range(-extents.x, extents.x),
            Random.Range(-extents.y, extents.y),
            Random.Range(-extents.z, extents.z)
        );

        return boxCollider.transform.TransformPoint(point);
    }
}
