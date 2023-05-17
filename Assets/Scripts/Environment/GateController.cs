using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GateController : MonoBehaviour
{
    [SerializeField] private ItemBase GateKey;

    private bool CheckForKey(List<ItemBase> list)
    {
        foreach (ItemBase item in list)
        {
            if(item == GateKey)
            {
                return true;
            }
        }

        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out InventoryComponent inventory))
        {
            if (CheckForKey(inventory.Inventory))
                Destroy(gameObject);
            else
                Debug.Log("Needed a specific key");
        }
    }
}
