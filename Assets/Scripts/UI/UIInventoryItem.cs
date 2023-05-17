using ProjectEON.SOData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    public ItemBase data;
    public Image itemSprite;
    public void Init(ItemBase itemData)
    {
        data = itemData;
        itemSprite.sprite = data.ItemSprite;
    }
}
