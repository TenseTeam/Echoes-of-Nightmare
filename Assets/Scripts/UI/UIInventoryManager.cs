using ProjectEON.SOData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UIInventoryManager : MonoBehaviour
{
    //private List<ItemCard> card = new List<ItemCard>();
    //private List<ItemBandage> bandage = new List<ItemBandage>();
    [SerializeField] private UIInventoryItem inventoryItem;
    private List<UIInventoryItem> _instantiatedItems = new List<UIInventoryItem>();


    public void ToggleUIInventory()
    {
        
    }
    
    public void ShowInventory()
    {
        //foreach (var item in )
        //{
        //    var uiItem = Instantiate(inventoryItem, this.transform);
        //    uiItem.Init(item);
        //    _instantiatedItems.Add(uiItem);
        //    Cursor.lockState = CursorLockMode.Confined;
        //    Cursor.visible = true;
        //}
    }
    public void HideInventory()
    {
        foreach (var item in _instantiatedItems)
        {
            Destroy(item.gameObject);
        }
        _instantiatedItems.Clear();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
