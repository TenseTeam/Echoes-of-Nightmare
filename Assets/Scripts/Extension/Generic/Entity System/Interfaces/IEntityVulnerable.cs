
namespace Extension.EntitySystem.Interfaces
{
    interface IEntityVulnerable : IVulnerable
    {
        void HealHitPoints(float healPoints);
    }
}