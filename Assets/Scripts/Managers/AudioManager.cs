namespace ProjectEON.Managers
{
    using UnityEngine;

    [RequireComponent(typeof(AudioSource))]
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioClip _transitionClip, _endFightClip;

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

        public void PlayBattleEnded()
        {
            PlayClip(_endFightClip);
        }

        private void PlayClip(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}