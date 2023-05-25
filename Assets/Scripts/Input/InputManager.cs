using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InputActions Input { get; private set; }

    public Vector2 MovementValue => Input.Player.Movement.ReadValue<Vector2>();
    //public bool InventoryPressed => _input.Player.Inventory.IsPressed();
    //public bool InteractPressed => _input.Player.Interact.IsPressed();
    //public bool MenuPressed => _input.Player.Menu.IsPressed();

    private void Awake()
    {
        Input = new InputActions();
    }

    private void OnEnable()
    {
        Input.Enable();
        WorldInputEnable();
    }

    public void WorldInputEnable()
    {
        Input.Player.Movement.Enable();
        Input.Player.Inventory.Enable();
    }

    public void BattleInputEnable()
    {
        Input.Player.Movement.Disable();
        Input.Player.Inventory.Disable();
    }
}
