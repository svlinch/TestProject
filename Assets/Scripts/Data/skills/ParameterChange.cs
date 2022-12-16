using System;
using UnityEngine;

[Serializable]
public class ParameterChange
{
    [SerializeField]
    private bool _sign;
    [SerializeField]
    private int _changeAmount;
    [SerializeField]
    private EnumHolder.ParameterChangeType _applyType;

    public bool Sign
    {
        get { return _sign; }
        private set { _sign = value; }
    }

    public int ChangeAmount
    {
        get { return _changeAmount; }
        private set { _changeAmount = value; }
    }

    public EnumHolder.ParameterChangeType ApplyType
    {
        get { return _applyType; }
        private set { _applyType = value; }
    }

    public ParameterChange(bool sing, int changeAmount, EnumHolder.ParameterChangeType applyType)
    {
        Sign = Sign;
        ChangeAmount = changeAmount;
        ApplyType = applyType;
    }

    public ParameterChange Clone()
    {
        var clone = new ParameterChange(_sign, _changeAmount, _applyType);
        return clone;
    }

    public void AddChange(int change)
    {
        _changeAmount += change;
    }
}