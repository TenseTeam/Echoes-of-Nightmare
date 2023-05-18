using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardItem : ItemBase
{
    private CardItemData m_CardItemData;
    public CardItemData CardItemData { get => m_CardItemData;}

    public CardItem(BaseItemData item, InventoryComponent inventory) : base(item, inventory)
    {

    }
}
