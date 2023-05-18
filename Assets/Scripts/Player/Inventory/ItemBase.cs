using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase: MonoBehaviour
{
    protected BaseItemData m_BaseItemData;
    public BaseItemData BaseItemData { get => m_BaseItemData; }

    public ItemBase(BaseItemData item)
    {
        m_BaseItemData = item;
    }
}
