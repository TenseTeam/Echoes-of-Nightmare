namespace ProjectEON.CombatSystem.Units
{
    using ProjectEON.SOData;
    using UnityEngine;

    [RequireComponent(typeof(UnitManager))]
    [RequireComponent(typeof(AudioSource))]
    public class UnitAudioHandler : MonoBehaviour
    {
        private AudioClip _getHitClip;
        private AudioClip _attackClip;
        private AudioClip _healClip;

        private UnitManager _unitManager;
        private AudioSource _audioSource;

        private void Awake()
        {
            TryGetComponent(out _unitManager);
            TryGetComponent(out _audioSource);
        }

        public void Init(AudioClip getHitClip)
        {
            _getHitClip = getHitClip;
        }

        public void PlayClip(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }

        public void PlayHurtClip()
        {
            PlayClip(_getHitClip);
        }
    }
}