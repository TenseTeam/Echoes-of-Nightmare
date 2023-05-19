using ProjectEON.Managers;
using ProjectEON.PartySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerMovement))]

public class PlayerController : MonoBehaviour, IPlayer
{
    private PlayerParty m_Party;
    private PlayerMovement m_Movement;

    public PlayerParty Party { get => m_Party; set => m_Party = value; }

    private void Awake()
    {
        m_Movement = GetComponent<PlayerMovement>();
        Party = GetComponent<PlayerParty>();
    }

    private void Start()
    {
        GameManager.Instance.CombatManager.BuildPlayerParty();
    }

    private void FixedUpdate()
    {
        m_Movement.Move(GameManager.Instance.InputManager.MovementValue.y, GameManager.Instance.InputManager.MovementValue.x);
    }

    private void Update()
    {
        Inventory();
        Menu();
    }

    private void Inventory()
    {
        if (GameManager.Instance.InputManager.InventoryPressed && !GameManager.Instance.UIManager.IsInventoryActive() && !GameManager.Instance.UIManager.IsMenuActive())
        {
            GameManager.Instance.UIManager.OpenInventory();
        }
        else if (GameManager.Instance.InputManager.InventoryPressed && GameManager.Instance.UIManager.IsInventoryActive())
        {
            GameManager.Instance.UIManager.CloseInventory();
        }
    }

    private void Menu()
    {
        if (GameManager.Instance.InputManager.MenuPressed && !GameManager.Instance.UIManager.IsMenuActive())
        {
            GameManager.Instance.UIManager.OpenMenu();
            Time.timeScale = 0f;
        }
        else if (GameManager.Instance.InputManager.MenuPressed && GameManager.Instance.UIManager.IsMenuActive())
        {
            GameManager.Instance.UIManager.CloseMenu();
            Time.timeScale = 1f;
        }
    }
}
