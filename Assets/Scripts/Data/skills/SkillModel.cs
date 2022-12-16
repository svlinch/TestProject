using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[Serializable]
public class SkillModel
{
    [SerializeField]
    private int _id;
    [SerializeField]
    private bool _self;

    public int Id
    {
        get { return _id; }
        private set { _id = value; }
    }

    public bool Self
    {
        get { return _self; }
        private set { _self = value; }
    }

    [SerializeField]
    private List<ParameterChange> _parameterChanges;

    [SerializeField]
    private List<EffectChange> _effectChanges;

    public List<ParameterChange> GetParameterChanges()
    {
        return _parameterChanges;
    } 
    
    public ReadOnlyCollection<EffectChange> GetEffectChanges()
    {
        return _effectChanges.AsReadOnly();
    }
}
