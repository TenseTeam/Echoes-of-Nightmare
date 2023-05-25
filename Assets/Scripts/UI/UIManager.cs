using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("World")]
    [SerializeField]
    private GameObject _worldUI;
    [SerializeField]
    private GameObject _interactUI;
    [SerializeField]
    private TMP_Text _PickUpUI;
    [SerializeField]
    private float _PickUpUIDisableTime;
    [SerializeField]
    private TMP_Text _missionText;
    [Header("Inventory")]
    [SerializeField]
    private GameObject _inventoryMenu;
    [Header("Pages")]
    [SerializeField]
    private GameObject _pagePanel;
    [SerializeField]
    private GameObject _pageText;
    [Header("Pause")]
    [SerializeField]
    private GameObject _pausePanel;

    [field: SerializeField]
    public UIRoasterManager UIRoasterManager { get; private set; }

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
        //_inventoryManager.HideInventory();
        _inventoryMenu.SetActive(true);
    }
    public void CloseInventory()
    {
        //_inventoryManager.HideInventory();
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

    public void MissionUpdate(string textMission)
    {
        _missionText.text = textMission;
    }

}
