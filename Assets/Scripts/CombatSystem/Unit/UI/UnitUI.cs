namespace ProjectEON.CombatSystem.Units
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    [RequireComponent(typeof(Unit))]
    public class UnitUI : MonoBehaviour
    {
        [SerializeField] private Image _redBarImage;
        [SerializeField] private TMP_Text _hitPointsText;
        private Unit _unit;

        private void Awake()
        {
            _unit = GetComponent<Unit>();
        }

        private void OnEnable()
        {
            _unit.OnHitPointsChange += UpdateHitPointsUI;
        }

        private void OnDisable()
        {
            _unit.OnHitPointsChange -= UpdateHitPointsUI;
        }

        private void UpdateHitPointsUI(float currentHitPoints, float maxHitPoints)
        {
            _hitPointsText.text = $"{currentHitPoints} / {maxHitPoints}";
            _redBarImage.fillAmount = currentHitPoints / maxHitPoints;
        }
    }
}