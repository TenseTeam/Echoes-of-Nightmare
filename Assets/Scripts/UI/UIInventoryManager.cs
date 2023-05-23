namespace ProjectEON.UI.Inventory
{
    using System;
    using UnityEngine;

    public class UIInventoryManager : MonoBehaviour
    {
        [SerializeField] private GameObject _inventoryMenu;
        [SerializeField] private UIInventoryTile _itemPrefab;
        [SerializeField] private RectTransform _contentPanel;
        [SerializeField] private UIInventoryDescription _itemDescription;
        [SerializeField] private InventoryComponent _inventoryComponent;

        public event Action<int> OnDescriptionRequested, OnItemActionRequested;

        private void Awake()
        {
            Hide();
            _itemDescription.ResetDescription();
        }
        private void Start()
        {
            _inventoryComponent = GetComponent<InventoryComponent>();
        }
        public void Show()
        {
            gameObject.SetActive(true);
            ResetSelection();
        }
        private void Hide()
        {
            gameObject.SetActive(false);
        }
        public void ResetSelection()
        {
            //itemDescription.ResetDescription();
            //DeselectAllItems();
        }

        public void InitializeInventoryUI()
        {
            //foreach (var item in )
            //{
            //    UIInventoryGrid uiItem = Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity);
            //    uiItem.transform.SetParent(_contentPanel);
            //    _inventoryComponent.Inventory.Add(item);
            //    Cursor.lockState = CursorLockMode.Confined;
            //    Cursor.visible = true;
            //    uiItem.OnItemClicked += HandleItemSelection;
            //    uiItem.OnRightMouseBtnClick += HandleItemActions;
            //}
        }

        internal void ResetAllItems()
        {
            //foreach (var item in listOfUIItems)
            //{
            //    item.ResetData();
            //    item.Deselect();
            //}
        }
        internal void UpdateDescription(int itemIndex, Sprite sprite, string itemTitle, string itemType, string itemOwner, string itemDescription)
        {
            //itemDescription.SetDescription(itemImage, name, description);
            //DeselectAllItems();
            //listOfUIItems[itemIndex].Select();
        }
        //private void HandleShowItemActions(UIInventoryItem inventoryItemUI)
        //{
        //    int index = listOfUIItems.IndexOf(inventoryItemUI);
        //    if (index == -1)
        //    {
        //        return;
        //    }
        //    OnItemActionRequested?.Invoke(index);
        //}
        //private void HandleItemSelection(UIInventoryItem inventoryItemUI)
        //{
        //    int index = listOfUIItems.IndexOf(inventoryItemUI);
        //    if (index == -1)
        //        return;
        //    OnDescriptionRequested?.Invoke(index);
        //}
    }
}
