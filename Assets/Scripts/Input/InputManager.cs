using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
    private InputActions _input;

    public Vector2 movementValue => _input.Player.Movement.ReadValue<Vector2>();
    public bool InventoryPressed => _input.Player.Inventory.WasPressedThisFrame();
    public bool InteractPressed => _input.Player.Interact.WasPressedThisFrame();

    public bool MenuPressed => _input.Player.Menu.WasPressedThisFrame();


    private void Awake()
    {
        _input = new InputActions();        
    }
    private void OnEnable()
    {
        _input.Enable();
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
