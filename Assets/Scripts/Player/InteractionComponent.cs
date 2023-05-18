using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionComponent : MonoBehaviour
{
    private InventoryComponent m_Inventory;

    private void Start()
    {
        m_Inventory = GetComponent<InventoryComponent>();
    }

    public void Interact(BaseItemData item)
    {
        m_Inventory.Inventory.Add(new ItemBase(item));
    }
}
