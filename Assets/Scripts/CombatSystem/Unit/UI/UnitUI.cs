namespace ProjectEON.CombatSystem.Units
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;
    using Extension.Patterns.ObjectPool;
    using ProjectEON.Managers;
    using ProjectEON.CombatSystem.StatusEffects;

    [RequireComponent(typeof(UnitManager), typeof(UnitStatusEffects))]
    public class UnitUI : MonoBehaviour
    {
        private const string ReceivedDamageAnimatorTriggerParamer = "Play";

        [SerializeField, Header("Unit Turn Indicator")]
        private GameObject _indicator;

        [SerializeField, Header("Status Effects")]
        private GridLayoutGroup _effectsLayoutGroup;

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
        private Dictionary<StatusEffectBase, Image> _dictStatusEffectImage;
        private Pool _iconStatusEffectPool;

        private void Awake()
        {
            _iconStatusEffectPool = GameManager.Instance.CombatManager.UICombatManager.PoolIconEffect;/*.Get(_effectsLayoutGroup.transform)*/
            TryGetComponent(out _unitManager);
        }

        private void OnEnable()
        {
            _dictStatusEffectImage = new Dictionary<StatusEffectBase, Image>();

            _unitManager.Unit.OnHitPointsSetUp += SetHitPoints;
            _unitManager.Unit.OnTakeDamage += SetColorDamage;
            _unitManager.Unit.OnHealHitPoints += SetColorHeal;
            _unitManager.OnCriticalReceived += SetColorCritical;
            _unitManager.Unit.OnChangeHitPoints += UpdateHitPointsUI;
            _unitManager.Unit.OnChangeHitPoints += HitPointsChangeAnimation;

            _unitManager.OnUnitTurnStart += () => _indicator.SetActive(true);
            _unitManager.OnUnitTurnEnd += () => _indicator.SetActive(false);
            _unitManager.UnitStatusEffects.OnAddedEffect += AddEffectIcon;
            _unitManager.UnitStatusEffects.OnRemovedEffect += RemoveEffect;

            RemoveAllEffectIcons();
        }


        private void OnDisable()
        {
            _unitManager.Unit.OnHitPointsSetUp -= SetHitPoints;
            _unitManager.Unit.OnTakeDamage -= SetColorDamage;
            _unitManager.Unit.OnHealHitPoints -= SetColorHeal;
            _unitManager.OnCriticalReceived -= SetColorCritical;
            _unitManager.Unit.OnChangeHitPoints -= UpdateHitPointsUI;
            _unitManager.Unit.OnChangeHitPoints -= HitPointsChangeAnimation;
            _unitManager.UnitStatusEffects.OnAddedEffect -= AddEffectIcon;

            _unitManager.OnUnitTurnStart -= () => _indicator.SetActive(true);
            _unitManager.OnUnitTurnEnd -= () => _indicator.SetActive(false);
            _unitManager.UnitStatusEffects.OnAddedEffect -= AddEffectIcon;
            _unitManager.UnitStatusEffects.OnRemovedEffect -= RemoveEffect;
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

        private void AddEffectIcon(StatusEffectBase effect)
        {
            GameObject iconGO = _iconStatusEffectPool.Get(_effectsLayoutGroup.transform);

            if (iconGO.TryGetComponent(out Image image))
            {
                image.sprite = effect.Data.EffectIcon;
                _dictStatusEffectImage.Add(effect, image);
                // TO DO add text status effect tooltip
            }
        }

        private void RemoveEffect(StatusEffectBase effect)
        {
            if (_dictStatusEffectImage.ContainsKey(effect))
            {
                RemoveEffectIcon(effect);
                _dictStatusEffectImage.Remove(effect);
            }
            //else
            //{
            //    Debug.LogWarning("Tentativo di rimuovere un effetto non presente nel dizionario.");
            //}
        }

        private void RemoveEffectIcon(StatusEffectBase effect)
        {
            _iconStatusEffectPool.Dispose(_dictStatusEffectImage[effect].gameObject);
        }

        private void ChangeHitPoints(float currentHitPoints, float maxHitPoints)
        {
            _hitPointsText.text = $"{currentHitPoints} / {maxHitPoints}";
            _redBarImage.fillAmount = currentHitPoints / maxHitPoints;
        }

        private void RemoveAllEffectIcons()
        {
            int childCount = _effectsLayoutGroup.transform.childCount;
            for (int i = childCount - 1; i >= 0; i--)
            {
                _iconStatusEffectPool.Dispose(_effectsLayoutGroup.transform.GetChild(i).gameObject);
            }
            _dictStatusEffectImage.Clear();
        }
    }
}