namespace ProjectEON.Environment
{
    using UnityEngine;

    public class KeyGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject _key;
        [SerializeField]
        private GameObject _spawnList;

        private void Start()
        {
            SpawnKey();
        }

        private void SpawnKey()
        {
            int rnd = UnityEngine.Random.Range(0, _spawnList.transform.childCount - 1);
            Instantiate(_key, _spawnList.transform.GetChild(rnd).transform.position, Quaternion.identity);
        }
    }
}