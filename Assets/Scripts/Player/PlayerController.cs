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

    // Start is called before the first frame update
    void Start()
    {
        m_Movement = GetComponent<PlayerMovement>();
        Party = GetComponent<PlayerParty>();
        GameManager.Instance.CombatManager.BuildPlayerParty();
    }

    // Update is called once per frame
    void Update()
    {
        m_Movement.Move(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
    }
}
