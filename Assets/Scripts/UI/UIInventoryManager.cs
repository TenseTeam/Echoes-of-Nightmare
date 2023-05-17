using ProjectEON.SOData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryManager : MonoBehaviour
{
    public UIInventoryItem inventoryItem;
    private List<UIInventoryItem> _instantiatedItems = new List<UIInventoryItem>();

    public void ShowInventory(List<ItemBase> inventoryItems)
    {
        foreach (var item in inventoryItems)
        {
            var uiItem = Instantiate(inventoryItem, this.transform);
            uiItem.Init(item);
            _instantiatedItems.Add(uiItem);
        }
    }
    public void HideInventory(List<ItemBase> inventoryItems)
    {
        foreach (var item in _instantiatedItems)
        {
            Destroy(item.gameObject);
        }
        _instantiatedItems.Clear();
    }
}
