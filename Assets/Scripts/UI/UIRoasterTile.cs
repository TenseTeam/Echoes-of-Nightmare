namespace ProjectEON.UI
{
    using ProjectEON.CombatSystem.Units;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class UIRoasterTile : MonoBehaviour
    {
        [SerializeField]
        private Image _rosterImage;
        [SerializeField]
        private TMP_Text _lifePoints;
        [SerializeField]
        private Image _lifeSlider;

        private Unit _unit;

        public void Init(Sprite sprite, Unit unit)
        {
            _rosterImage.sprite = sprite;
            _unit = unit;
            UpdatedRosterLife(unit.CurrentHitPoints, unit.MaxHitPoints);
            _unit.OnChangeHitPoints += UpdateRosterLife;
        }

        private void UpdateRosterLife(float damage, float current, float maximum)
        {
            UpdatedRosterLife(current, maximum);
        }

        public void UpdatedRosterLife(float current, float maximum)
        {
            _lifePoints.text = current + "/" + maximum;
            _lifeSlider.fillAmount = current / maximum;
        }
    }
}