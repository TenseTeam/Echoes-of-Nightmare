using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject m_Key;
    [SerializeField] private GameObject m_SpawnList;

    private void Start()
    {
        SpawnKey();
    }

    private void SpawnKey()
    {
        int rnd = UnityEngine.Random.Range(0, m_SpawnList.transform.childCount - 1);
        Instantiate(m_Key, m_SpawnList.transform.GetChild(rnd).transform.position, Quaternion.identity);
    }
}
