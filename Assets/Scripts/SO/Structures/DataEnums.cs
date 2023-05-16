namespace ProjectEON.SOData.Structures.Enums
{
    [System.Flags]
    public enum SkillType : uint
    {
        None = 0,
        Damage = 1,
        Heal = 2,
        Everything
    }

    [System.Flags]
    public enum SkillTarget : uint
    {
        None = 0,
        SameParty = 1,
        OpponentParty = 2,
        Everything,
    }

    public enum StatusEffectType : uint
    {
        DamageReduction,
        Bleed,
        Fear,
        Stun,
        Paralysis
    }
}