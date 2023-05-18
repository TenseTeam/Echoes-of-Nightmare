using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UIManager : MonoBehaviour
{
    public static UIManager s_instance;
    [Header("World")]
    [SerializeField] private GameObject _worldUI;
    [SerializeField] private TextMeshProUGUI _PickUpUI;
    [SerializeField] private float _PickUpUIDisableTime;
    [SerializeField] private Slider _slider1UI;
    [SerializeField] private TextMeshProUGUI _life1UI;
    [SerializeField] private Slider _slider2UI;
    [SerializeField] private TextMeshProUGUI _life2UI;
    [SerializeField] private Slider _slider3UI;
    [SerializeField] private TextMeshProUGUI _life3UI;
    [SerializeField] private TextMeshProUGUI _missionText;
    [Header("Inventory")]
    [SerializeField] private GameObject _inventoryMenu;
    [Header("Pages")]
    [SerializeField] private GameObject _pagePanel;
    [SerializeField] private GameObject _pageText;
    [Header("Pause")]
    [SerializeField] private GameObject _pausePanel;
    private UIInventoryManager _inventoryManager;
    private void Awake()
    {
        s_instance = this;
    }
    public void PickUpText(string itemName)
    {
        _PickUpUI.text = itemName + " Collected";
        if (!_PickUpUI.gameObject.activeInHierarchy)
        {
            _PickUpUI.gameObject.SetActive(true);
            Invoke("PickUpTextDisable", _PickUpUIDisableTime);
        }
    }
    private void PickUpTextDisable()
    {
        _PickUpUI.gameObject.SetActive(false);
    }
    public void OpenInventory()
    {
        _inventoryManager.HideInventory();
        _inventoryMenu.gameObject.SetActive(true);
    }
    public void CloseInventory()
    {
        _inventoryManager.HideInventory();
        _inventoryMenu.gameObject.SetActive(false);
    }
}
