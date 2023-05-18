namespace ProjectEON.CombatSystem.Managers
{
    using UnityEngine;

    public class AttacksManager : MonoBehaviour
    {
        [field: SerializeField, Header("Status Effects Statistics")]
        public int DamageReduction {  get; private set; }
        [field: SerializeField]
        public int BleedDamage { get; private set; }


        //public void ApplyEffectStatus()
        //{

        //}
    }
}