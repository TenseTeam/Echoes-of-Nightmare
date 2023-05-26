namespace ProjectEON.InventorySystem
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using ProjectEON.InventorySystem.Items;
    using ProjectEON.SOData;

    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<ItemBase> _items = new List<ItemBase>();
        [SerializeField] private int _maxSize;

        public bool IsFull => _items.Count >= _maxSize;
        public bool IsEmpty => _items.Count <= 0;
        public int MaxSize => _maxSize;

        public event Action<ItemBase> OnItemAdded;

        public event Action<ItemBase> OnItemRemoved;

        public void AddToInventory(ItemBase item)
        {
            if (IsFull) return;
            _items.Add(item);
            OnItemAdded?.Invoke(item);
        }

        public void RemoveFromInventory(ItemBase item)
        {
            if (IsEmpty) return;
            _items.Remove(item);
            OnItemRemoved?.Invoke(item);
        }

        public bool CheckForItem(ItemBase itemToFind)
        {
            foreach (ItemBase item in _items)
            {
                if (item == itemToFind) return true;
            }
            return false;
        }

        public bool CheckForItemData(ItemBaseData itemToFind)
        {
            foreach (ItemBase item in _items)
            {
                if (item.ItemData == itemToFind) return true;
            }
            return false;
        }
    }
}