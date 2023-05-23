using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.U2D;

[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float m_Speed;
    private Rigidbody m_RigidBody;
    private SpriteRenderer m_Sprite;
    private Animator m_Animator;
    private Vector3 m_MoveDirection;

    [Header("Slope Handling")]
    [SerializeField] private float maxSlopeAngle;
    [SerializeField] private float playerHeight;
    private RaycastHit slopeHit;
    private bool exitingSlope;

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

        m_MoveDirection = new Vector3(horizontal * (m_Speed * 100) * Time.deltaTime, m_RigidBody.velocity.y, vertical * (m_Speed * 100) * Time.deltaTime);
        //m_RigidBody.velocity = (Vector3.forward * vertical + Vector3.right * horizontal) * (m_Speed * 100) * Time.deltaTime;


        // on slope
        if (OnSlope() && !exitingSlope)
        {
            m_RigidBody.AddForce(GetSlopeMoveDirection() * m_Speed * 20f, ForceMode.Force);

            if (m_RigidBody.velocity.y > 0)
                m_RigidBody.AddForce(Vector3.down * 80f, ForceMode.Force);
        }

        m_RigidBody.velocity = m_MoveDirection;

        // turn gravity off while on slope
        m_RigidBody.useGravity = !OnSlope();

        m_Sprite.flipX = m_RigidBody.velocity.x < 0;
    }

    private void SpeedControl()
    {
        // limiting speed on slope
        if (OnSlope() && !exitingSlope)
        {
            if (m_RigidBody.velocity.magnitude > m_Speed)
                m_RigidBody.velocity = m_RigidBody.velocity.normalized * m_Speed;
        }
    }

    private bool OnSlope()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f))
        {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    private Vector3 GetSlopeMoveDirection()
    {
        return Vector3.ProjectOnPlane(m_MoveDirection, slopeHit.normal).normalized;
    }
}
