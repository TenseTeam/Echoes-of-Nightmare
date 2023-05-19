using ProjectEON.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GateController : MonoBehaviour
{
    [SerializeField] private BaseItemData GateKey;
    private bool m_InRange;

    private bool CheckForKey(List<ItemBase> list)
    {
        foreach (ItemBase item in list)
        {
            if(item.BaseItemData == GateKey)
            {
                return true;
            }
        }

        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InventoryComponent inventory))
        {
            m_InRange = true;
            GameManager.Instance.UIManager.InteractUIEnable();
        }
            
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out InventoryComponent inventory))
        {
            if (GameManager.Instance.InputManager.InteractPressed && m_InRange)
            {
                if (CheckForKey(inventory.Inventory))
                    Destroy(gameObject);
                else
                    Debug.Log("Needed a specific key");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out InventoryComponent inventory))
        {
            GameManager.Instance.UIManager.InteractUIEnable();
            m_InRange = false;
        }
    }
}