using Extension.Generic.Structures;
using ProjectEON.InventorySystem.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventoryGrid : Grid<UIInventoryTile>
{ 
    private UIInventoryDescription _uiDescription; 

    public void Init(UIInventoryDescription description, Vector2Int size)
    {
        base.Init(size);
        _uiDescription = description;
    }

    protected override UIInventoryTile GenerateTile(UIInventoryTile[,] grid, Vector2Int position)
    {
        UIInventoryTile tile = base.GenerateTile(grid, position);
        tile.Init(_uiDescription);
        return tile;
    }

    public void AddItemToGrid(ItemBase item)
    {
        if(TryFindEmptyTile(out UIInventoryTile emptyTile))
        {
            emptyTile.Fill(item);
        }
    }
    public void RemoveItemFromGrid(ItemBase item)
    {
        if (TryFindItemTile(out UIInventoryTile itemTile , item))
        {
            itemTile.ResetTile();
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

    private bool TryFindItemTile(out UIInventoryTile itemTile, ItemBase itemToFind)
    {
        foreach (UIInventoryTile tile in GridTiles)
        {
            if (tile.Item == itemToFind)
            {
                itemTile = tile;
                return true;
            }
        }
        itemTile = null;
        return false;
    }
}

