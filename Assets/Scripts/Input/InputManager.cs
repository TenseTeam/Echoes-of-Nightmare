using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputActions _input;
    public InputActions Input { get => _input; }
    public Vector2 vectorMove => _input.Player.Movement.ReadValue<Vector2>();
    public bool InventoryPressed => _input.Player.Inventory.IsPressed();
    public bool InteractPressed => _input.Player.Interact.IsPressed();

    public bool MenuPressed => _input.Player.Menu.IsPressed();


    private void Awake()
    {
        _input = new InputActions();        
    }
    private void OnEnable()
    {
        WorldInputEnable();
    }
   

    public void WorldInputEnable()
    {
        _input.Player.Movement.Enable();
        _input.Player.Inventory.Enable();
    }
    public void BattleInputEnable()
    {
        _input.Player.Movement.Disable();
        _input.Player.Inventory.Disable();
    }
}
