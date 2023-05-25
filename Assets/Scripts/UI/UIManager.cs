using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager s_instance;

    [Header("World")]
    [SerializeField]
    private GameObject _worldUI;

    [SerializeField]
    private GameObject _interactUI;

    [Header("Inventory")]
    [SerializeField]
    private GameObject _inventoryMenu;

    [Header("Pause")]
    [SerializeField]
    private GameObject _pausePanel;

    private void Awake()
    {
        s_instance = this;
    }

    public void OpenInventory()
    {
        _inventoryMenu.SetActive(true);
    }

    public void CloseInventory()
    {
        _inventoryMenu.SetActive(false);
    }

    public void OpenMenu()
    {
        _pausePanel.SetActive(true);
    }

    public void CloseMenu()
    {
        _pausePanel.SetActive(false);
    }

    public void SetActiveWorldUI(bool enabled)
    {
        _worldUI.SetActive(enabled);
    }

    public void InteractUIEnable()
    {
        _interactUI.SetActive(true);
    }

    public void InteractUIDisable()
    {
        _interactUI.SetActive(false);
    }

    public bool IsInventoryActive()
    {
        return _inventoryMenu.activeInHierarchy;
    }

    public bool IsMenuActive()
    {
        return _pausePanel.activeInHierarchy;
    }
}