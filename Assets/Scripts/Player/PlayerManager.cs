namespace ProjectEON.PlayerSystem
{
    using UnityEngine;
    using ProjectEON.GenericInterfaces;
    using ProjectEON.Managers;
    using ProjectEON.PartySystem;

    [RequireComponent(typeof(Rigidbody))]
    //[RequireComponent(typeof(PlayerMovement))]

    public class PlayerManager : MonoBehaviour, IPlayer
    {
        private PlayerParty _party;
        //private PlayerMovement _movement;

        public PlayerParty Party { get => _party; set => _party = value; }

        private void Awake()
        {
            TryGetComponent(out _party);
            //TryGetComponent(out _movement);
        }

        //private void FixedUpdate()
        //{
        //    _movement.Move(GameManager.Instance.InputManager.MovementValue.y, GameManager.Instance.InputManager.MovementValue.x);
        //}

        private void Update()
        {
            Inventory();
            //Menu();
        }

        private void Inventory()
        {
            if (Input.GetKeyDown(KeyCode.I) &&
                !GameManager.Instance.UIManager.IsInventoryActive() &&
                !GameManager.Instance.UIManager.IsMenuActive())
            {
                GameManager.Instance.UIManager.OpenInventory();
            }
            else if (Input.GetKeyDown(KeyCode.I) &&
                GameManager.Instance.UIManager.IsInventoryActive())
            {
                GameManager.Instance.UIManager.CloseInventory();
            }
        }

        //private void Menu() 
        //{
        //    if (GameManager.Instance.InputManager.MenuPressed && !GameManager.Instance.UIManager.IsMenuActive())
        //    {
        //        GameManager.Instance.UIManager.OpenMenu();
        //        Time.timeScale = 0f;
        //    }
        //    else if (GameManager.Instance.InputManager.MenuPressed && GameManager.Instance.UIManager.IsMenuActive())
        //    {
        //        GameManager.Instance.UIManager.CloseMenu();
        //        Time.timeScale = 1f;
        //    }
        //}
    }
}