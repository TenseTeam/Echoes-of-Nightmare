namespace ProjectEON.UI
{
    using UnityEngine;
    using ProjectEON.InventorySystem;
    using ProjectEON.InventorySystem.Items;

    public class UIInventoryManager : MonoBehaviour
    {
        [SerializeField] 
        private UIInventoryDescription _itemDescription;
        [SerializeField] 
        private Inventory _inventory;
        [SerializeField]
        private UIInventoryGrid _uiGrid;
        [SerializeField]
        private int _inventoryColums;

        private void Awake()
        {
            _itemDescription.ResetDescription();
        }

        private void Start()
        {
            _inventory.OnItemAdded += AddItem;
            _inventory.OnItemRemoved += RemoveItem;
            _uiGrid.Init(_itemDescription, new Vector2Int(_inventoryColums, Mathf.CeilToInt((float)_inventory.MaxSize/ (float)_inventoryColums)));
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
