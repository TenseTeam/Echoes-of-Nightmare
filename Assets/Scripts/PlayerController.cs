using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_Speed;
    private float m_Party;
    private Rigidbody m_RigidBody;
    public float Party { get => m_Party; set => m_Party = value; }

    public KeyCode ForwardKeyCode = KeyCode.W;
    public KeyCode BackwardKeyCode = KeyCode.S;
    public KeyCode LeftKeyCode = KeyCode.A;
    public KeyCode RightKeyCode = KeyCode.D;

    // Start is called before the first frame update
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(ForwardKeyCode))
            MoveForward();
        if (Input.GetKey(BackwardKeyCode))
            MoveBackward();
        if (Input.GetKey(LeftKeyCode))
            MoveLeft();
        if (Input.GetKey(RightKeyCode))
            MoveRight();
    }

    private void MoveForward()
    {
        m_RigidBody.velocity = transform.forward * m_Speed * Time.deltaTime;
    }

    private void MoveBackward()
    {
        m_RigidBody.velocity = -transform.forward * m_Speed * Time.deltaTime;
    }

    private void MoveLeft()
    {
        m_RigidBody.velocity = -transform.right * m_Speed * Time.deltaTime;
    }

    private void MoveRight()
    {
        m_RigidBody.velocity = transform.right * m_Speed * Time.deltaTime;
    }

    private void Interact()
    {

    }
}
