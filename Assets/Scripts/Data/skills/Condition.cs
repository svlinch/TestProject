using System;
using UnityEngine;

[Serializable]
public class Condition
{
    //simplified condition, only for shield effect
    [SerializeField]
    private EnumHolder.ConditionCheckType _checkType;
    [SerializeField]
    private bool _isHealth; // or shield
    [SerializeField]
    private int _numToCompare;

    public bool CheckCondition(UnitModel model, UnitParameters parameters)
    {
        if (_isHealth)
        {
            return compare(parameters.Health);
        }
        else
        {
            return compare(parameters.Shield);
        }
    }

    private bool compare(int modelValue)
    {
        switch (_checkType)
        {
            case EnumHolder.ConditionCheckType.More:
                if (modelValue > _numToCompare)
                {
                    return true;
                }
                break;
            case EnumHolder.ConditionCheckType.Less:
                if (modelValue < _numToCompare)
                {
                    return true;
                }
                break;
            case EnumHolder.ConditionCheckType.Equal:
                if (modelValue == _numToCompare)
                {
                    return true;
                }
                break;
        }
        return false;
    }
}