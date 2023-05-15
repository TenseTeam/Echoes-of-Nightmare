using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_Speed;
    private Rigidbody m_RigidBody;

    public KeyCode ForwardKeyCode = KeyCode.W;
    public KeyCode BackwardKeyCode = KeyCode.S;
    public KeyCode LeftKeyCode = KeyCode.A;
    public KeyCode RightKeyCode = KeyCode.D;

    public void MoveForward()
    {
        m_RigidBody.velocity = transform.forward * m_Speed * Time.deltaTime;
    }

    public void MoveBackward()
    {
        m_RigidBody.velocity = -transform.forward * m_Speed * Time.deltaTime;
    }

    public void MoveLeft()
    {
        m_RigidBody.velocity = -transform.right * m_Speed * Time.deltaTime;
    }

    public void MoveRight()
    {
        m_RigidBody.velocity = transform.right * m_Speed * Time.deltaTime;
    }
}
