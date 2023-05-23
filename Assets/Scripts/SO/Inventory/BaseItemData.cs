using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectEON.SOData.Enums;

[CreateAssetMenu(menuName = "Item/ItemBase")]
public class BaseItemData : ScriptableObject
{
    public string Description;
    public Sprite ItemSprite;
    public ItemType Type;
}
