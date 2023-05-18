using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase
{
    protected BaseItemData m_BaseItemData;
    protected InventoryComponent m_Inventory;
    public BaseItemData BaseItemData { get => m_BaseItemData; }

    public ItemBase(BaseItemData item, InventoryComponent inventory)    
    {
        m_BaseItemData = item;
        m_Inventory = inventory;
    }
}
