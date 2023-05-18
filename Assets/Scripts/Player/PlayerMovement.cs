using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_Speed;
    private Rigidbody m_RigidBody;
    private SpriteRenderer m_Sprite;
    private Animator m_Animator;

    private void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        m_Sprite = GetComponentInChildren<SpriteRenderer>();
    }

    public void Move(float vertical, float horizontal)
    {
        if (Mathf.Abs(m_RigidBody.velocity.x) > 0.001f || Mathf.Abs(m_RigidBody.velocity.z) > 0.001f)
            m_Animator.SetBool("isMoving", true);
        else
            m_Animator.SetBool("isMoving", false);

        m_RigidBody.velocity = (Vector3.forward * vertical + Vector3.right * horizontal) * (m_Speed * 100) * Time.deltaTime;

        m_Sprite.flipX = m_RigidBody.velocity.x < 0;
    }
}
