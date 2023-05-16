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
        [SerializeField, Header("Status Effects")]
        private GameObject _effectIconBasePrefab;
        private HorizontalLayoutGroup _effectsLayoutGroup;

        [SerializeField, Header("Images")]
        private Image _redBarImage;

        [SerializeField, Header("Texts")]
        private TMP_Text _hitPointsText;

        private UnitManager _unitManager;
        private UnitStatusEffects _statusEffects;

        private void Awake()
        {
            _unitManager = GetComponent<UnitManager>();
            //_statusEffects = GetComponent<UnitStatusEffects>();
        }

        private void OnEnable()
        {
            _unitManager.Unit.OnHitPointsChange += UpdateHitPointsUI;
            //_statusEffects.OnAddedEffect += AddEffectIcon;
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

        private void OnDisable()
        {
            _unitManager.Unit.OnHitPointsChange -= UpdateHitPointsUI;
        }

        private void UpdateHitPointsUI(float currentHitPoints, float maxHitPoints)
        {
            _hitPointsText.text = $"{currentHitPoints} / {maxHitPoints}";
            _redBarImage.fillAmount = currentHitPoints / maxHitPoints;
        }
    }
}