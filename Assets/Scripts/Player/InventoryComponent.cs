using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    [SerializeField] private List<ItemBase> m_Inventory;
    private PlayerController m_Player;
    
    public List<ItemBase> Inventory { get => m_Inventory; set => m_Inventory = value; }

    private void Start()
    {
        m_Player = GetComponent<PlayerController>();
    }
}
