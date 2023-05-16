using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(InventoryComponent))]
[RequireComponent(typeof(InteractionComponent))]
[RequireComponent(typeof(SphereCollider))]
public class PlayerController : MonoBehaviour, IPlayer
{
    private float m_Party;
    private PlayerMovement m_Movement;
    public float Party { get => m_Party; set => m_Party = value; }

    // Start is called before the first frame update
    void Start()
    {
        m_Movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(m_Movement.ForwardKeyCode))
            m_Movement.MoveForward();
        if (Input.GetKey(m_Movement.BackwardKeyCode))
            m_Movement.MoveBackward();
        if (Input.GetKey(m_Movement.LeftKeyCode))
            m_Movement.MoveLeft();
        if (Input.GetKey(m_Movement.RightKeyCode))
            m_Movement.MoveRight();
    }
}
