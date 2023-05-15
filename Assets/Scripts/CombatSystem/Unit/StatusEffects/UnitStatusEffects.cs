namespace ProjectEON.CombatSystem.Units
{
    using ProjectEON.CombatSystem.Managers;
    using ProjectEON.SOData.Structures;
    using ProjectEON.SOData.Structures.Enums;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    [RequireComponent(typeof(Unit))]
    public class UnitStatusEffects : MonoBehaviour
    {
        private List<StatusEffect> _appliedStatusEffects;
        private Unit _unit;
        public int CurrentDamageReduction { get; private set; }
        public bool IsStunned { get; private set; }

        public event Action<StatusEffect> OnAddedEffect;
        public event Action<StatusEffect> OnConsumedEffect;

        private void Awake()
        {
            _appliedStatusEffects = new List<StatusEffect>();
            _unit = GetComponent<Unit>();
        }

        public void AddStatusEffect(StatusEffect effect)
        {
            _appliedStatusEffects.Add(effect);
            OnAddedEffect?.Invoke(effect);
            ApplyStatusEffects(effect);
        }

        public void ApplyStatusEffects(StatusEffect effect)
        {
            switch (effect.EffectType)
            {
                case StatusEffectType.DamageReduction: ApplyDamageReduction(); break;
                case StatusEffectType.Stun: ApplyStun(); break;
                case StatusEffectType.Fear: ApplyFear(); break;
            }
        }

        public void ConsumeStatusEffects()
        {
            foreach (StatusEffect effect in _appliedStatusEffects)
            {
                switch (effect.EffectType)
                {
                    case StatusEffectType.Bleed: ApplyBleedDamage(); break;
                }

                ConsumeStatusEffect(effect);
            }
        }

        private void ConsumeStatusEffect(StatusEffect effect)
        {
            effect.Turns--;
            OnConsumedEffect?.Invoke(effect);
            if(effect.Turns == 0)
            {
                Remove(effect);
            }
        }

        private void Remove(StatusEffect effect)
        {
            switch(effect.EffectType)
            {
                case StatusEffectType.DamageReduction:
                    CurrentDamageReduction = 0;
                    break;
                case StatusEffectType.Stun:
                    IsStunned = false;
                    break;
                case StatusEffectType.Fear:
                    IsStunned = false;
                    ApplyDamageReduction();
                    break;
            }

            _appliedStatusEffects.Remove(effect);
        }

        private void ApplyDamageReduction()
        {
            CurrentDamageReduction = CombatManager.Instance.AttacksManager.DamageReduction;
        }

        private void ApplyBleedDamage()
        {
            _unit.TakeDamage(CombatManager.Instance.AttacksManager.BleedDamage);
        }

        private void ApplyStun()
        {
            IsStunned = true;
        }

        private void ApplyFear()
        {
            ApplyStun();
            ApplyDamageReduction();
        }
    }
}