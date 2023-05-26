namespace ProjectEON.Environment
{
    using UnityEngine;
    using ProjectEON.Managers;
    using ProjectEON.SOData;
    using ProjectEON.GenericInterfaces;
    using ProjectEON.Player.InteractionSystem;

    public class InteractableItem : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private ItemBaseData _item;
        private bool _inRange;

        public void Interact(InteractionComponent interaction)
        {
            interaction.Interact(_item);
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IPlayer player))
            {
                _inRange = true;
                GameManager.Instance.UIManager.InteractUIEnable();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out InteractionComponent interaction))
            {
                if (Input.GetKeyDown(KeyCode.E) && _inRange)
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
                _inRange = false;
                GameManager.Instance.UIManager.InteractUIDisable();
            }
        }
    }
}