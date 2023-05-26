namespace ProjectEON.EncounterSystem
{
    using System.Linq;
    using UnityEngine;
    using System.Collections.Generic;
    using ProjectEON.PartySystem;
    using ProjectEON.SOData;

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
        [SerializeField]
        private GameObject _spawnList;
        [SerializeField]
        private List<UnitSpawn> _enemyList;
        [SerializeField]
        private UnitData _enemyJolly;
        [SerializeField]
        private GameObject _prefabEncounter;

        [Header("Setting for RNG")]
        [SerializeField]
        private int _minEncounter;
        [SerializeField]
        private int _maxEncounter;
        [SerializeField]
        private int _minEnemyForEncounter;
        [SerializeField]
        private int _maxEnemyForEncounter;

        private GameObject[] m_ListSpawnAreas;

        private void Start()
        {
            m_ListSpawnAreas = new GameObject[_spawnList.transform.childCount];
            for (int i = 0; i < m_ListSpawnAreas.Length; i++)
            {
                m_ListSpawnAreas[i] = _spawnList.transform.GetChild(i).gameObject;
            }

            GenerateSpawnPoints(true);
        }

        private void GenerateSpawnPoints(bool isStart)
        {
            List<UnitSpawn> actualList = new List<UnitSpawn>();
            foreach (UnitSpawn unitSpawn in _enemyList)
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
                int indexEncounter = Random.Range(_minEncounter, _maxEncounter);
                for (int i = 0; i < indexEncounter; i++)
                {
                    Vector3 encounterPosition = GetRandomPointInsideCollider(SpawnArea.GetComponent<BoxCollider>());
                    GameObject tmp = Instantiate(_prefabEncounter, SpawnArea.transform);
                    tmp.transform.position = encounterPosition;

                    int enemyCount = Random.Range(_minEnemyForEncounter, _maxEnemyForEncounter);
                    UnitData[] enemyArray = new UnitData[enemyCount];

                    for (int j = 0; j < enemyCount; j++)
                    {
                        foreach (UnitSpawn enemy in actualList)
                        {
                            int rndEnemy = Random.Range(1, 100);
                            if (enemy.Rate >= rndEnemy)
                            {
                                enemyArray[j] = enemy.Unit;
                                break;
                            }
                        }
                        if (enemyArray[j] == null)
                            enemyArray[j] = _enemyJolly;
                    }
                    if (tmp.TryGetComponent(out EnemyParty enemyParty))
                    {
                        enemyParty.BuildParty(enemyArray.ToList());
                    }
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
}
