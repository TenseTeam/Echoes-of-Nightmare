using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/ItemBase")]
public class BaseItemData : ScriptableObject
{
    public string Description;
    public Sprite ItemSprite;
    //public ItemType Type;

    public virtual ItemBase CreateItem(BaseItemData item, InventoryComponent inventory)
    {
        return new ItemBase(item, inventory);
    }
}
