using System;
using UnityEditor;
using UnityEngine;

namespace ProjectEON.PlayerSystem.Movement
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimController : MonoBehaviour
    {
        private PlayerMovement _playerMovement;
        private Animator _animator;

        private void Awake()
        {
            TryGetComponent(out _playerMovement);
            TryGetComponent(out _animator);
        }

        private void OnEnable()
        {
            _playerMovement.OnMovement += AnimMovement;
        }

        private void OnDisable()
        {
            _playerMovement.OnMovement -= AnimMovement;
        }

        private void AnimMovement(Vector3 direction)
        {
            _animator.SetFloat("Horizontal", direction.x);
            _animator.SetFloat("Vertical", direction.z);
        }
    }
}