namespace ProjectEON.SOData.Structures.Enums
{
    public enum SkillType : uint
    {
        Damage,
        Heal
    }

    [System.Flags]
    public enum SkillTarget : uint
    {
        None = 0,
        SameParty = 1,
        OpponentParty = 2,
        Everything
    }

    public enum StatusEffectType : uint
    {
        Single,
        Iterative
    }
}