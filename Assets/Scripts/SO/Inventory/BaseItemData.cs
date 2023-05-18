using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemBase")]
public class BaseItemData : ScriptableObject
{
    public string Description;
    public Sprite ItemSprite;
    public ItemType Type;
}
