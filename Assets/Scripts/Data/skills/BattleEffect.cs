using System;
using UnityEngine;

[Serializable]
public class BattleEffect
{
    [SerializeField]
    private int _id;
    [SerializeField]
    private int _duration;
    [SerializeField]
    private ParameterChange _onContinueParameterChange;
    [SerializeField]
    private ParameterChange _onEndParametersChange;
    [SerializeField]
    private Condition _earlyEndCondition;

    public int Id //"poison","shield"
    {
        get { return _id; }
        private set { _id = value; }
    }

    public int Duration
    {
        get { return _duration; }
        private set { _duration = value; }
    }

    public ParameterChange OnContinueParametersChange
    {
        get { return _onContinueParameterChange; }
        private set { _onContinueParameterChange = value; }
    }

    public ParameterChange OnEndParametersChange
    {
        get { return _onEndParametersChange; }
        private set { _onEndParametersChange = value; }
    }

    public Condition EarlyEndCondition
    {
        get { return _earlyEndCondition; }
        private set { _earlyEndCondition = value; }
    }

    public BattleEffect(int id, int duration, ParameterChange continueChange, ParameterChange endChange, Condition earlyEndCondition)
    {
        Id = id;
        Duration = duration;
        OnContinueParametersChange = continueChange;
        OnEndParametersChange = endChange;
        EarlyEndCondition = earlyEndCondition;
    }

    public BattleEffect Clone()
    {
        var clone = new BattleEffect(_id, _duration, _onContinueParameterChange.Clone(), _onEndParametersChange.Clone(), _earlyEndCondition);
        return clone;
    }

    public void Update(BattleEffect newEffect)
    {
        //poison and shield stacks up
        Duration += newEffect.Duration;
        OnContinueParametersChange.AddChange(newEffect.OnContinueParametersChange.ChangeAmount);
        OnEndParametersChange.AddChange(newEffect.OnEndParametersChange.ChangeAmount);
    }

    public void ChangeDuration(int change)
    {
        Duration += change;
    }
}