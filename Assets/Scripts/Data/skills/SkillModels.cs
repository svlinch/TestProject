using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SkillModels
{
    [SerializeField]
    private List<SkillModel> _models;

    public SkillModel GetSkillModel(int index)
    {
        return _models[index];
    }
}