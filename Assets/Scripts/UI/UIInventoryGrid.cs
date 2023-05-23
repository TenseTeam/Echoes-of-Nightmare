using Extension.Generic.Structures;
using ProjectEON.UI.Inventory;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventoryGrid : Grid<UIInventoryTile>
{ 
    private UIInventoryManager uIInventory;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemType;
    [SerializeField] private TextMeshProUGUI itemOwner;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private Sprite itemIcon;

    [SerializeField]
    private Vector2Int _inventorySize;

    private void Start()
    {
        Init(_inventorySize);
        GenerateGrid();
    }

    public void AddItemToGrid(BaseItemData data)
    {
        if(TryFindEmptyTile(out UIInventoryTile emptyTile))
        {
            emptyTile.Fill(data);
        }
    }

    private bool TryFindEmptyTile(out UIInventoryTile emptyTile)
    {
        foreach (UIInventoryTile tile in GridTiles)
        {
            if (tile.IsEmpty)
            {
                emptyTile = tile;
                return true;
            }
        }
        emptyTile = null;
        return false;
    }
}

