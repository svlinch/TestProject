using System.Collections.Generic;
using UnityEngine;

public class EffectsBar : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;

    private List<EffectIcon> _effects;

    public void Awake()
    {
        _effects = new List<EffectIcon>();
    }

    public void UpdateEffects(List<BattleEffect> effects)
    {
        var existsArray = new bool[effects.Count];

        for(int i = 0; i < _effects.Count; i++)
        {
            bool exists = false;
            for(int j = 0; j < effects.Count; j++)
            {
                if (_effects[i].Id == effects[j].Id)
                {
                    existsArray[j] = true;
                    exists = true;
                }
            }
            if (!exists)
            {
                _effects[i].Reset();
                _effects.RemoveAt(i);
                i--;
            }
        }

        for(int i = 0; i < effects.Count; i++)
        {
            if (!existsArray[i])
            {
                var newIcon = Pool.Instance.GetIcon();
                newIcon.Initialize(effects[i].Id, _transform);
                _effects.Add(newIcon);
            }
        }
    }

    public void Reset()
    {
        _effects.Clear();
    }
}