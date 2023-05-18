using ProjectEON.CombatSystem.Units;
using ProjectEON.Managers;
using ProjectEON.PartySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BandageItem : ItemBase
{
    private BandageItemData m_BandageItemData;
    public BandageItemData BandageItemData { get => m_BandageItemData; }

    public BandageItem(BaseItemData item, InventoryComponent inventory) : base(item, inventory)
    {

    }

    public void Use()
    {
        foreach (UnitManager unit in GameManager.Instance.CombatManager.PlayerPartyComposer.InFightUnitsManager.GetComposedUnits())
        {
            unit.Unit.HealHitPoints(m_BandageItemData.AmountOfCure);
        }

        foreach(ItemBase itemBase in m_Inventory.Inventory)
        {
            if(itemBase.BaseItemData == m_BandageItemData)
            {
                m_Inventory.Inventory.Remove(itemBase);
                break;
            }
        }
    }
}
