using System;

[Serializable]
public static class EnumHolder
{
    public enum ParameterChangeType
    {
        Health,
        Shield,
        Both
    }

    public enum ConditionCheckType
    {
        More,
        Less,
        Equal
    }
}