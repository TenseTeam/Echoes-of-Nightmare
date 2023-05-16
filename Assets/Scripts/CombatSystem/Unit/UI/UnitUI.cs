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
        [SerializeField]
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
            _unitManager.Unit.OnHitPointsSetUp += SetHitPointsText;
            _unitManager.OnCriticalReceived += SetColorCritical;
            _unitManager.Unit.OnHitPointsChange += SetColorDamage;
            _unitManager.Unit.OnHitPointsChange += UpdateHitPointsUI;
            _unitManager.Unit.OnHitPointsChange += HitPointsChangeAnimation;
            //_statusEffects.OnAddedEffect += AddEffectIcon;
        }


        private void OnDisable()
        {
            _unitManager.Unit.OnHitPointsSetUp -= SetHitPointsText;
            _unitManager.OnCriticalReceived -= SetColorCritical;
            _unitManager.Unit.OnHitPointsChange -= SetColorDamage;
            _unitManager.Unit.OnHitPointsChange -= UpdateHitPointsUI;
            _unitManager.Unit.OnHitPointsChange -= HitPointsChangeAnimation;
            //_statusEffects.OnAddedEffect -= AddEffectIcon;
        }

        private void SetHitPointsText(float currentHitPoints, float maxHitPoints)
        {
            ChangeHitPointsText(currentHitPoints, maxHitPoints);
        }

        private void UpdateHitPointsUI(float hitPointsChange, float currentHitPoints, float maxHitPoints)
        {
            ChangeHitPointsText(currentHitPoints, maxHitPoints);
            _redBarImage.fillAmount = currentHitPoints / maxHitPoints;
        }

        private void SetColorCritical()
        {
            Debug.LogAssertion("Criti");
            _receivedDamageText.color = _receivedCriticalColor;
        }

        private void SetColorDamage(float arg1, float arg2, float arg3)
        {
            Debug.LogAssertion("Dama");
            _receivedDamageText.color = _receivedDamageTextColor;
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

        private void ChangeHitPointsText(float currentHitPoints, float maxHitPoints)
        {
            _hitPointsText.text = $"{currentHitPoints} / {maxHitPoints}";
        }
    }
}