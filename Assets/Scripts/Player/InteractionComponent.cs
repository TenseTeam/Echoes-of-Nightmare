namespace ProjectEON.Player.InteractionSystem
{
    using UnityEngine;
    using ProjectEON.SOData;
    using ProjectEON.InventorySystem;
    using ProjectEON.InventorySystem.Items.Factory;

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