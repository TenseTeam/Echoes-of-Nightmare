namespace ProjectEON.Player.InteractionSystem
{
    using ProjectEON.Player.InventorySystem;
    using UnityEngine;

    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Inventory))]
    public class InteractionComponent : MonoBehaviour
    {
        private Inventory _inventory;

        private void Awake()
        {
            TryGetComponent(out _inventory);
        }

        public void Interact(ItemBaseData item)
        {
            _inventory.AddToInventory(ItemFactory.CreateItem(item, _inventory, item.Type));
        }
    }
}