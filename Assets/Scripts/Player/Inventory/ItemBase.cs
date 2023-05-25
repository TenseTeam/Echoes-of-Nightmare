using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase
{
    protected ItemBaseData Data;
    protected Inventory Inventory;
    public ItemBaseData ItemData { get => Data; }

    public ItemBase(ItemBaseData item, Inventory inventory)    
    {
        Data = item;
        Inventory = inventory;
    }

    public virtual void Use()
    {

    }
}
