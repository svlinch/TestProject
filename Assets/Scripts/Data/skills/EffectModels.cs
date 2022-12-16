using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EffectModels
{
    [SerializeField]
    public List<BattleEffect> _models;

    public BattleEffect GetBattleEffect(int index)
    {
        return _models[index];
    }
}