using ProjectEON.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItem : MonoBehaviour, IInteractable
{
    //[SerializeField] private ItemType m_ItemType;
    [SerializeField] private ItemBaseData m_Item;
    //public ItemType ItemType { get => m_ItemType; }
    private bool m_InRange;
    public void Interact(InteractionComponent interaction)
    {
        interaction.Interact(m_Item);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IPlayer player))
        {
            m_InRange = true;
            GameManager.Instance.UIManager.InteractUIEnable();
        }            
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out InteractionComponent interaction))
        {
            if (Input.GetKeyDown(KeyCode.E) && m_InRange)
            {
                Interact(interaction);
                GameManager.Instance.UIManager.InteractUIDisable();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IPlayer player))
        {
            m_InRange = false;
            GameManager.Instance.UIManager.InteractUIDisable();
        }
    }
}
