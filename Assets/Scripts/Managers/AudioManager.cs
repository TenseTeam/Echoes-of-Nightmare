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

        /// <summary>
        /// Initializes this <see cref="AudioManager"/>.
        /// </summary>
        /// <param name="gameManager">Related <see cref="GameManager"/>.</param>
        public void Init(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        /// <summary>
        /// Plays the <see cref="_transitionClip"/>.
        /// </summary>
        public void PlayTransition()
        {
            PlayClip(_transitionClip);
        }

        /// <summary>
        /// Plays the <see cref="_battleClip"/>.
        /// </summary>
        public void PlayBattle()
        {
            PlayClip(_battleClip);
        }

        /// <summary>
        /// Plays the <see cref="_themeClip"/>.
        /// </summary>
        public void PlayTheme()
        {
            PlayClip(_themeClip);
        }


        /// <summary>
        /// Plays an <see cref="AudioClip"/> of this <see cref="AudioManager"/>.
        /// </summary>
        /// <param name="clip"><see cref="AudioClip"/> to play.</param>
        private void PlayClip(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }
    }
}