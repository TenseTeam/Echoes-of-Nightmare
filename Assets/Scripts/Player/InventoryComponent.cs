using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryComponent : MonoBehaviour
{
    private List<ItemBase> m_Inventory;
    private PlayerController m_Player;
    
    public List<ItemBase> Inventory { get => m_Inventory; set => m_Inventory = value; }

    private void Start()
    {
        m_Player = GetComponent<PlayerController>();
    }

    public void Use(ItemBase item)
    {
        switch(item.Type)
        {
            case ItemType.gateKey:
                break;
            case ItemType.Bandage:
                //float healthIncrement = (ItemBandage)item.
                break;
            case ItemType.Card:

                break;
        }
    }
}
