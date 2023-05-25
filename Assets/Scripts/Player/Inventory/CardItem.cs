using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardItem : ItemBase
{
    private CardItemData m_CardItemData;
    public CardItemData CardItemData { get => m_CardItemData;}

    public CardItem(ItemBaseData item, Inventory inventory) : base(item, inventory)
    {

    }
}
