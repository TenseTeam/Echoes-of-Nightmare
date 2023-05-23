using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectEON.SOData.Enums;

public static class ItemFactory
{
    public static ItemBase CreateItem(ItemBaseData item, Inventory inventory, ItemType type)
    {
        switch(type)
        {
            case ItemType.Base:
                return new ItemBase(item, inventory);
            case ItemType.Bandage:
                return new BandageItem(item, inventory);
            case ItemType.Card: 
                return new CardItem(item, inventory);
            default:
                throw new System.Exception();
        }
    }
}

