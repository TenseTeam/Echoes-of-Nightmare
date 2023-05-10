using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKey(ForwardKeyCode))
            MoveForward();
        if (Input.GetKey(BackwardKeyCode))
            MoveBackward();
        if (Input.GetKey(LeftKeyCode))
            MoveLeft();
        if (Input.GetKey(RightKeyCode))
            MoveRight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MoveForward()
    {

    }

    private void MoveBackward()
    {

    }

    private void MoveLeft()
    {

    }

    private void MoveRight()
    {
        
    }

    private void Interact()
    {

    }
}
