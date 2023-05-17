using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager s_instance;
    [Header("World")]
    [SerializeField] private GameObject _worldUI;
    [SerializeField] private GameObject _interactUI;
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
    private UIInventoryManager _inventoryManager;
    private void Awake()
    {
        s_instance = this;
    }
    public void InteractTextEnable()
    {
        _interactUI.gameObject.SetActive(true);
    }
    public void InteractTextDisable()
    {
        _interactUI.gameObject.SetActive(false);
    }
    public void OpenInventory(List<ItemBase> items)
    {
        _inventoryManager.ShowInventory(items);
        _inventoryMenu.gameObject.SetActive(true);
    }
    public void CloseInventory(List<ItemBase> items)
    {
        _inventoryManager.HideInventory(items);
        _inventoryMenu.gameObject.SetActive(false);
    }
}
