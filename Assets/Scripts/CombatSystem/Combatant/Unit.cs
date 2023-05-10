namespace ProjectEON.CombatSystem
{
    using Extension.EntitySystem;
    using Extension.Patterns.ObjectPool;
    using Extension.Patterns.ObjectPool.Interfaces;
    using ProjectEON.SOData;
    using UnityEngine;


    [RequireComponent(typeof(SpriteRenderer))]
    public class Unit : EntityBase, IPooledObject
    {
        public UnitData CombatantData { get; private set; }
        private SpriteRenderer _spriteRenderer;

        public Pool RelatedPool { get; private set; }

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();   
        }

        public void Init(UnitData data, Pool associatedPool)
        {
            CombatantData = data;
            hitPoints = CombatantData.hitPoints;
            _spriteRenderer.sprite = CombatantData.combatantSprite;
            AssociatePool(associatedPool);
            SetupHP();
        }

        public void AssociatePool(Pool associatedPool)
        {
            RelatedPool = associatedPool;
        }

        public void Dispose()
        {
            RelatedPool.Dispose(gameObject);
        }
    }
}
