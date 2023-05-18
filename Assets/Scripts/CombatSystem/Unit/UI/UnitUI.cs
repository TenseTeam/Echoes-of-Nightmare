namespace ProjectEON.CombatSystem.Units
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using ProjectEON.SOData;

    [RequireComponent(typeof(UnitManager), typeof(UnitStatusEffects))]
    public class UnitUI : MonoBehaviour
    {
        private const string ReceivedDamageAnimatorTriggerParamer = "Play";

        [SerializeField, Header("Unit Turn Indicator")]
        private GameObject _indicator;

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
        [SerializeField]
        private Color _receivedDamageTextColor = Color.red;
        [SerializeField]
        private Color _receivedHealTextColor = Color.green;

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
            _unitManager.Unit.OnHitPointsSetUp += SetHitPoints;
            _unitManager.Unit.OnTakeDamage += SetColorDamage;
            _unitManager.Unit.OnHealHitPoints += SetColorHeal;
            _unitManager.OnCriticalReceived += SetColorCritical;
            _unitManager.Unit.OnChangeHitPoints += UpdateHitPointsUI;
            _unitManager.Unit.OnChangeHitPoints += HitPointsChangeAnimation;

            _unitManager.OnUnitTurnStart += () => _indicator.SetActive(true);
            _unitManager.OnUnitTurnEnd += () => _indicator.SetActive(false);
            //_statusEffects.OnAddedEffect += AddEffectIcon;
        }


        private void OnDisable()
        {
            _unitManager.Unit.OnHitPointsSetUp -= SetHitPoints;
            _unitManager.Unit.OnTakeDamage -= SetColorDamage;
            _unitManager.Unit.OnHealHitPoints -= SetColorHeal;
            _unitManager.OnCriticalReceived -= SetColorCritical;
            _unitManager.Unit.OnChangeHitPoints -= UpdateHitPointsUI;
            _unitManager.Unit.OnChangeHitPoints -= HitPointsChangeAnimation;
            //_statusEffects.OnAddedEffect -= AddEffectIcon;
        }

        private void SetHitPoints(float currentHitPoints, float maxHitPoints)
        {
            ChangeHitPoints(currentHitPoints, maxHitPoints);
        }

        private void UpdateHitPointsUI(float hitPointsChange, float currentHitPoints, float maxHitPoints)
        {
            ChangeHitPoints(currentHitPoints, maxHitPoints);
        }

        private void SetColorCritical()
        {
            _receivedDamageText.color = _receivedCriticalColor;
        }

        private void SetColorDamage()
        {
            _receivedDamageText.color = _receivedDamageTextColor;
        }

        private void SetColorHeal()
        {
            _receivedDamageText.color = _receivedHealTextColor;
        }

        private void HitPointsChangeAnimation(float hitPointsChange, float currentHitPoints, float maxHitPoints)
        {
            _receivedDamageText.text = hitPointsChange.ToString();
            _animReceivedDamage.SetTrigger(ReceivedDamageAnimatorTriggerParamer);
            //_receivedDamageText.color = _receivedDamageTextColor;
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

        private void ChangeHitPoints(float currentHitPoints, float maxHitPoints)
        {
            _hitPointsText.text = $"{currentHitPoints} / {maxHitPoints}";
            _redBarImage.fillAmount = currentHitPoints / maxHitPoints;
        }
    }
}