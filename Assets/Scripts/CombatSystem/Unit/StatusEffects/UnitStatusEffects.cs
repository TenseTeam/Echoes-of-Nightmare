namespace ProjectEON.CombatSystem.Units
{
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.CombatSystem.StatusEffects;
    using ProjectEON.SOData;
    using ProjectEON.SOData.Structures.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEditor.PackageManager.Requests;
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
        public int AccumulatedDamage { get; private set; }
        public int CurrentDamageReduction { get; private set; }
        public int CurrentDamageDown { get; private set; }
        public int CurrentDamageUp { get; private set; }
        public bool IsStunned { get; private set; }
        public bool HasDamageReceiveReduction { get; private set; }
        public bool HasDamageDown { get; private set; }
        public bool HasDamageUp { get; private set; }
        #endregion

        private void Awake()
        {
            _appliedStatusEffects = new List<StatusEffectBase>();
            TryGetComponent(out _unitManager);
        }

        private void OnEnable()
        {
            //Reset();
            _unitManager.OnInitialize += ResetEffects;
            _unitManager.OnUnitTurnStart += ProcessStatusEffects;
        }

        private void ResetEffects()
        {
            AccumulatedDamage = 0;
            CurrentDamageReduction = 0;
            IsStunned = false;
            HasDamageReceiveReduction = false;
        }

        private void OnDisable()
        {
            _unitManager.OnInitialize -= ResetEffects;
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

            if(AccumulatedDamage > 0)
                ReleaseAccumulatedDamage();
        }

        public void ExitRemoveAllStatusEffects()
        {
            for (int i = 0; i < _appliedStatusEffects.Count; i++)
            {
                RemoveStatusEffect(_appliedStatusEffects[i]);
            }
            _appliedStatusEffects.Clear();
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

        public void ApplyDamageDown(int damageDown)
        {
            CurrentDamageDown = damageDown;
            HasDamageDown = true;
        }

        public void ApplyDamageUp(int damageUp)
        {
            CurrentDamageUp = damageUp;
            HasDamageUp = true;
        }

        public void RemoveDamageUp()
        {
            CurrentDamageUp = 0;
            HasDamageUp = false;
        }

        public void RemoveDamageDown()
        {
            CurrentDamageDown = 0;
            HasDamageDown = false;
        }

        public void ApplyBleedDamage(int bleedDamage)
        {
            AccumulatedDamage += bleedDamage;
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
            RemoveStun();
            RemoveDamageReduction();
        }

        private void RemoveStatusEffect(StatusEffectBase effect)
        {
            OnRemovedEffect?.Invoke(effect);
            effect.Exit();
            _appliedStatusEffects.Remove(effect);
        }

        private void ReleaseAccumulatedDamage()
        {
            _unitManager.Unit.TakeDamage(AccumulatedDamage);
            AccumulatedDamage = 0;
        }
    }
}