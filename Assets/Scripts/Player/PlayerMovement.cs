namespace ProjectEON.PlayerSystem.Movement
{
    using System;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Header("Speed")]
        private float _speed;
        [SerializeField, Header("Ground Raycast")]
        private LayerMask _groundLayer;
        [SerializeField]
        private float _groundDistance;

        private Animator _animator;
        private Rigidbody _rb;
        private SpriteRenderer _sprite;
        private bool _defaultFlipX;

        public event Action<Vector3> OnMovement;

        private void Awake()
        {
            TryGetComponent(out _rb);
            TryGetComponent(out _sprite);

            _defaultFlipX = _sprite.flipX;
        }

        private void FixedUpdate()
        {
            Movement();
            StayGrounded();
        }

        private void Movement()
        {
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 1, Input.GetAxis("Vertical"));
            OnMovement?.Invoke(moveDirection);
            _rb.velocity = moveDirection * _speed;
            Flip(moveDirection);
        }

        private void Flip(Vector3 direction)
        {
            if(_defaultFlipX)
            {
                _sprite.flipX = direction.x < 0;
            }
            else
            {
                _sprite.flipX = direction.x > 0;
            }
        }

        private void StayGrounded()
        {
            Vector3 castPos = transform.position;
            castPos.y += 1;

            if (Physics.Raycast(castPos, -transform.up, out RaycastHit hit, Mathf.Infinity, _groundLayer))
            {
                if (hit.collider != null)
                {
                    Vector3 movePos = transform.position;
                    movePos.y = hit.point.y + _groundDistance;
                    transform.position = movePos;
                }
            }
        }
    }
}