namespace ProjectEON.InventorySystem.UI
{
    using System;
    using UnityEngine;

    public class UIInventoryManager : MonoBehaviour
    {
        [SerializeField] 
        private GameObject _inventoryMenu;
        [SerializeField] 
        private UIInventoryTile _itemPrefab;
        [SerializeField] 
        private RectTransform _contentPanel;
        [SerializeField] 
        private UIInventoryDescription _itemDescription;
        [SerializeField] 
        private Inventory _inventory;
        [SerializeField] 
        private UIInventoryGrid _uiGrid;
        [SerializeField]
        private Vector2Int _inventorySize;

        private void Awake()
        {
            _itemDescription.ResetDescription();
            TryGetComponent(out _inventory);
        }

        private void Start()
        {
            _inventory.OnItemAdded += AddItem;
            _inventory.OnItemRemoved += RemoveItem;
            _uiGrid.Init(_inventorySize);
            _uiGrid.GenerateGrid();
            ResetSelection();
        }

        private void AddItem(ItemBase item) 
        {
            _uiGrid.AddItemToGrid(item);            
        }

        private void RemoveItem(ItemBase item)
        {
            _uiGrid.RemoveItemFromGrid(item);
        }

        public void ResetSelection()
        {
            _itemDescription.ResetDescription();
        }
    }
}
