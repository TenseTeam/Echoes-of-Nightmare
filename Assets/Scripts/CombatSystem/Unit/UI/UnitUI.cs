namespace ProjectEON.CombatSystem.Units
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using ProjectEON.SOData.Structures;

    [RequireComponent(typeof(UnitManager), typeof(UnitStatusEffects))]
    public class UnitUI : MonoBehaviour
    {
        private const string ReceivedDamageAnimatorTriggerParamer = "Play";

        [SerializeField, Header("Status Effects")]
        private GameObject _effectIconBasePrefab;
        private HorizontalLayoutGroup _effectsLayoutGroup;

        [SerializeField, Header("Images")]
        private Image _redBarImage;

        [SerializeField, Header("Texts")]
        private TMP_Text _hitPointsText;
        [SerializeField]
        private TMP_Text _receivedDamageText;

        [SerializeField, Header("Text Colors")]
        private Color _receivedCriticalColor = Color.yellow;
        private Color _receivedDamageTextColor = Color.red;

        [SerializeField, Header("Animators")]
        private Animator _animReceivedDamage;

        private UnitManager _unitManager;
        //private UnitStatusEffects _statusEffects;

        private void Awake()
        {
            _unitManager = GetComponent<UnitManager>();
            //_statusEffects = GetComponent<UnitStatusEffects>();
        }

        private void OnEnable()
        {
            _unitManager.Unit.OnHitPointsChange += UpdateHitPointsUI;
            _unitManager.OnCriticalReceived += CriticalReceived;
            _unitManager.Unit.OnHitPointsChange += HitPointsChangeAnimation;
            //_statusEffects.OnAddedEffect += AddEffectIcon;
        }

        private void HitPointsChangeAnimation(float currentHitPoints, float maxHitPoints)
        {
            //_receivedDamageText.text = ;
            _animReceivedDamage.SetTrigger(ReceivedDamageAnimatorTriggerParamer);
            _receivedDamageText.color = _receivedDamageTextColor;
        }

        private void OnDisable()
        {
            _unitManager.Unit.OnHitPointsChange -= UpdateHitPointsUI;
            _unitManager.OnCriticalReceived -= CriticalReceived;
        }

        private void CriticalReceived()
        {
            _receivedDamageText.color = _receivedCriticalColor;
        }

        private void AddEffectIcon(StatusEffectData effect)
        {
            if(Instantiate(_effectIconBasePrefab, _effectsLayoutGroup.transform.position, _effectsLayoutGroup.transform.rotation, _effectsLayoutGroup.transform)
                .TryGetComponent(out Image image))
            {
                image.sprite = effect.EffectIcon;
                // TO DO add text turns
            }
        }

        private void UpdateHitPointsUI(float currentHitPoints, float maxHitPoints)
        {
            _hitPointsText.text = $"{currentHitPoints} / {maxHitPoints}";
            _redBarImage.fillAmount = currentHitPoints / maxHitPoints;
        }
    }
}