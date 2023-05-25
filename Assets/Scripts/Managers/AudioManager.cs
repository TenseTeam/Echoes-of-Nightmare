namespace ProjectEON.Managers
{
    using UnityEngine;

    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioClip _transitionClip, _themeClip, _battleClip;

        private GameManager _gameManager;
        private AudioSource _audioSource;

        private void Awake()
        {
            TryGetComponent(out _audioSource);
        }

        public void Init(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public void PlayTransition()
        {
            PlayClip(_transitionClip);
        }

        public void PlayBattle()
        {
            PlayClip(_battleClip);
        }

        public void PlayTheme()
        {
            PlayClip(_themeClip);
        }

        private void PlayClip(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}