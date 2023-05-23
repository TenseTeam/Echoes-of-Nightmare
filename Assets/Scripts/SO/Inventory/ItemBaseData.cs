using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectEON.SOData.Enums;

[CreateAssetMenu(menuName = "Item/ItemBase")]
public class ItemBaseData : ScriptableObject
{
    public string ItemName;
    public string Description;
    public Sprite ItemSprite;
    public ItemType Type;
}
