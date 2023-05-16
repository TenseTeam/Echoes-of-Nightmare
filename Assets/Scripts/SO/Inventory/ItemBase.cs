using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemBase")]
public class ItemBase : ScriptableObject
{
    public string Description;
    public Sprite ItemSprite;
    public ItemType Type;
}
