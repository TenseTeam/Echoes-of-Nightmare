using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/ItemBandage")]
public class BandageItemData : BaseItemData
{
    public int AmountOfCure;

    public override ItemBase CreateItem(BaseItemData item, InventoryComponent inventory)
    {
        return new BandageItem(item, inventory);
    }
}
