using System;
using UnityEngine;
using System.Collections.Generic;

//could use T for UnitModels,SkillModels,EffectModels
//if serializing of T had proper support

[Serializable]
public class UnitModels
{
    [SerializeField]
    private List<UnitModel> _models;

    public UnitModel GetModel(int i)
    {
        return _models[i];
    }
}