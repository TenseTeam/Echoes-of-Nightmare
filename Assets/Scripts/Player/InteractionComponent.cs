using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(InventoryComponent))]
public class InteractionComponent : MonoBehaviour
{
    private InventoryComponent m_Inventory;

    private void Awake()
    {
        m_Inventory = GetComponent<InventoryComponent>();
    }

    public void Interact(BaseItemData item)
    {
        m_Inventory.Inventory.Add(item.CreateItem(item, m_Inventory));
    }
}
