namespace ProjectEON.PlayerSystem
{
    using UnityEngine;

    [RequireComponent(typeof(Animator))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        private Rigidbody _rigidBody;
        private SpriteRenderer _sprite;
        private Animator _animator;
        private Vector3 _moveDirection;

        [Header("Slope Handling")]
        [SerializeField]
        private float _maxSlopeAngle;

        [SerializeField]
        private float _playerHeight;

        private RaycastHit _slopeHit;
        private bool _isExitingSlope;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
            _sprite = GetComponentInChildren<SpriteRenderer>();
        }

        public void Move(float vertical, float horizontal)
        {
            if (Mathf.Abs(_rigidBody.velocity.x) > 0.001f || Mathf.Abs(_rigidBody.velocity.z) > 0.001f)
                _animator.SetBool("isMoving", true);
            else
                _animator.SetBool("isMoving", false);

            _moveDirection = new Vector3(horizontal * (_speed * 100) * Time.deltaTime, _rigidBody.velocity.y, vertical * (_speed * 100) * Time.deltaTime);
            //m_RigidBody.velocity = (Vector3.forward * vertical + Vector3.right * horizontal) * (m_Speed * 100) * Time.deltaTime;

            // on slope
            if (OnSlope())
            {
                if (vertical == 0 && horizontal == 0)
                    _rigidBody.isKinematic = true;
                else
                    _rigidBody.isKinematic = false;

                _rigidBody.AddForce(GetSlopeMoveDirection() * _speed * 20f, ForceMode.Force);

                if (_rigidBody.velocity.y > 0)
                    _rigidBody.AddForce(Vector3.down * 100f, ForceMode.Force);
            }

            _rigidBody.velocity = _moveDirection;
            // turn gravity off while on slope
            //m_RigidBody.useGravity = !OnSlope();
            _sprite.flipX = _rigidBody.velocity.x < 0;
        }

        private void SpeedControl()
        {
            // limiting speed on slope
            if (OnSlope() && !_isExitingSlope)
            {
                if (_rigidBody.velocity.magnitude > _speed)
                    _rigidBody.velocity = _rigidBody.velocity.normalized * _speed;
            }
        }

        private bool OnSlope()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out _slopeHit, _playerHeight * 0.5f + 0.3f))
            {
                float angle = Vector3.Angle(Vector3.up, _slopeHit.normal);
                return angle < _maxSlopeAngle && angle != 0;
            }

            return false;
        }

        private Vector3 GetSlopeMoveDirection()
        {
            return Vector3.ProjectOnPlane(_moveDirection, _slopeHit.normal).normalized;
        }
    }
}