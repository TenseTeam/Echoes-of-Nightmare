namespace ProjectEON.CombatSystem.Units
{
    using ProjectEON.SOData;
    using System;
    using UnityEngine;

    [RequireComponent(typeof(Animator))]
    [RequireComponent (typeof(UnitManager))]
    public class UnitAnimatorController : MonoBehaviour
    {
        private const string GetHitTrigger = "GetHit";
        private const string AttackTrigger = "Attack";

        private Animator _anim;
        private UnitManager _unitManager;

        private void Awake()
        {
            _unitManager = GetComponent<UnitManager>();
            _anim = GetComponent<Animator>();
        }

        public void AnimSkill(SkillData skill)
        {
            OverrideAnimator(skill.SkillAnimatorOverrideController);
            _anim.SetTrigger(AttackTrigger);
        }

        public void AnimGetHit()
        {
            OverrideAnimator(_unitManager.UnitData.AnimatorOverrideControllerGetHit);
            _anim.SetTrigger(GetHitTrigger);
        }

        private void OverrideAnimator(AnimatorOverrideController aoc)
        {
            _anim.runtimeAnimatorController = aoc;
        }
    }
}