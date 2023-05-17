using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private InputActions _input;
    public InputActions Input { get => _input; }
    public Vector2 vectorMove => _input.Player.Movement.ReadValue<Vector2>();

    private void Awake()
    {
        _input = new InputActions();
        
    }
    private void Start()
    {
        WorldInputEnable();
    }

    public void WorldInputEnable()
    {
        _input.Player.Enable();
        _input.Battle.Disable();
    }
    public void BattleInputEnable()
    {
        _input.Battle.Enable();
        _input.Player.Disable();
    }
}
