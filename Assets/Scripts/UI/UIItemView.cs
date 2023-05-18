using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItemView : MonoBehaviour, IPointerClickHandler
{
    private UIInventoryManager uIInventory;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemType;
    [SerializeField] private TextMeshProUGUI itemOwner;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private Sprite itemIcon;
    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}

