namespace ProjectEON.Environment
{
    using UnityEngine;
    using ProjectEON.Managers;
    using ProjectEON.SOData;
    using ProjectEON.InventorySystem;

    [RequireComponent(typeof(Collider))]
    public class GateController : MonoBehaviour
    {
        [SerializeField]
        private ItemBaseData _gateKey;
        private bool _isInRange;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Inventory inventory))
            {
                _isInRange = true;
                GameManager.Instance.UIManager.InteractUIEnable();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out Inventory inventory))
            {
                if (Input.GetKeyDown(KeyCode.E) && _isInRange)
                {
                    if (inventory.CheckForItemData(_gateKey))
                    {
                        GameManager.Instance.UIManager.InteractUIDisable();
                        Destroy(gameObject);
                    }
                    else
                    {
#if DEBUG
                        Debug.Log("Needed a specific key.");
#endif
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Inventory inventory))
            {
                GameManager.Instance.UIManager.InteractUIDisable();
                _isInRange = false;
            }
        }
    }
}