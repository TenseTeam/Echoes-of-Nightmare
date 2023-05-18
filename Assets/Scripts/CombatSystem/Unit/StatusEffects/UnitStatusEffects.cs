namespace ProjectEON.CombatSystem.Units
{
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.CombatSystem.StatusEffects;
    using ProjectEON.SOData;
    using ProjectEON.SOData.Structures.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    [RequireComponent(typeof(UnitManager))]
    public class UnitStatusEffects : MonoBehaviour
    {
        #region Events
        public event Action<StatusEffectBase> OnAddedEffect;
        public event Action<StatusEffectBase> OnRemovedEffect;
        #endregion

        #region Members
        private UnitManager _unitManager;
        private List<StatusEffectBase> _appliedStatusEffects;
        #endregion

        #region Properties
        public int CurrentDamageReduction { get; private set; }
        public bool IsStunned { get; private set; }
        public bool HasDamageReceiveReduction { get; private set; }
        #endregion

        private void Awake()
        {
            _appliedStatusEffects = new List<StatusEffectBase>();
            _unitManager = GetComponent<UnitManager>();
        }

        private void OnEnable()
        {
            ExitRemoveAllStatusEffects();
            _unitManager.OnUnitTurnStart += ProcessStatusEffects;
        }

        private void OnDisable()
        {
            _unitManager.OnUnitTurnStart -= ProcessStatusEffects;
        }

        public void AddStatusEffect(StatusEffectBase effect)
        {
            _appliedStatusEffects.Add(effect);
            effect.Enter();
            OnAddedEffect?.Invoke(effect);
        }

        private void ProcessStatusEffects()
        {
            for (int i = 0; i < _appliedStatusEffects.Count; i++) // I could not use a foreach loop 'cause the list in a foreach cannot be modiefied in loop
            {
                _appliedStatusEffects[i].Process();

                if (_appliedStatusEffects[i].AppliedTurns <= 0) // also "<" to avoid bugs
                {
                    RemoveStatusEffect(_appliedStatusEffects[i]);
                }
            }
        }

        public void ExitRemoveAllStatusEffects()
        {
            for (int i = 0; i < _appliedStatusEffects.Count; i++)
            {
                RemoveStatusEffect(_appliedStatusEffects[i]);
            }
        }

        public void ApplyDamageReduction(int damageReduction)
        {
            CurrentDamageReduction = damageReduction;
            HasDamageReceiveReduction = true;
        }

        public void RemoveDamageReduction()
        {
            CurrentDamageReduction = 0;
            HasDamageReceiveReduction = false;
        }

        public void ApplyBleedDamage(int bleedDaamge)
        {
            _unitManager.Unit.TakeDamage(bleedDaamge);
        }

        public void ApplyStun()
        {
            IsStunned = true;
        }

        public void RemoveStun()
        {
            IsStunned = false;
        }

        public void ApplyFear(int damageReduction)
        {
            ApplyStun();
            ApplyDamageReduction(damageReduction);
        }

        public void RemoveFear()
        {
            RemoveDamageReduction();
            RemoveStun();
        }

        private void RemoveStatusEffect(StatusEffectBase effect)
        {
            OnRemovedEffect?.Invoke(effect);
            effect.Exit();
            _appliedStatusEffects.Remove(effect);
        }
    }
}