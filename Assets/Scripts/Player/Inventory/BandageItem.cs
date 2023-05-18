using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandageItem : ItemBase
{
    private BandageItemData m_BandageItemData;
    public BandageItemData BandageItemData { get => m_BandageItemData; }

    public BandageItem(BaseItemData item) : base(item)
    {

    }

    public void Use()
    {

    }
}
