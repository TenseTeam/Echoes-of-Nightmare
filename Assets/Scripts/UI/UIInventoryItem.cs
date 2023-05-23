using ProjectEON.SOData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour
{
    
    [SerializeField] private Image borderImage;

    //public event Action<UIInventoryTile> OnItemClicked, OnRightMouseBtnClick;
    // Update is called once per frame
    private void Awake()
    {
        ResetData();
        Deselect();
    }
    private void ResetData()
    {
        //itemImage.gameObject.SetActive(false);
    }
    public void Select()
    {
        borderImage.enabled = true;
    }

    private void Deselect()
    {
        borderImage.enabled = false;
    }
    public void SetData(Sprite sprite, int quantity)
    {
        //itemImage.gameObject.SetActive(true);
        //itemImage.sprite = sprite;
        //quantityText.text = quantity + "";
    }

    
}
