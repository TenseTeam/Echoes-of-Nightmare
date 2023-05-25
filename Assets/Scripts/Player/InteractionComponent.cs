using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Inventory))]
public class InteractionComponent : MonoBehaviour
{
    private Inventory m_Inventory;

    private void Awake()
    {
        m_Inventory = GetComponent<Inventory>();
    }

    public void Interact(ItemBaseData item)
    {
        m_Inventory.AddToInventory(ItemFactory.CreateItem(item, m_Inventory, item.Type));
    }
}
