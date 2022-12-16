using System.Collections.Generic;
using UnityEngine;

public class SimpleUnit : MonoBehaviour
{
    [SerializeField]
    protected HealthBar _healthBar;
    [SerializeField]
    protected EffectsBar _effectsBar;
    [SerializeField]
    protected AbilitiesBar _abilitiesBar;

    protected List<BattleEffect> _effects;

    protected UnitModel _model;
    protected UnitParameters _parameters;

    public virtual void Initialize(UnitModel model)
    {
        _model = model;
        _parameters = new UnitParameters();
        _parameters.Build(_model);

        _effects = new List<BattleEffect>();
        _abilitiesBar.Initialize(this);
        checkoutBars();
    }

    public virtual void GetRandomAbility()
    {
        var randomIndex = Random.Range(0, _model.GetAvailableSkills().Count);
        _abilitiesBar.UpdateSkill(_model.GetAvailableSkills()[randomIndex]);
    }

    public virtual void ApplySkill(SkillModel skill)
    {
        UnitOperations.ApplySkill(skill, _model, _parameters, _effects);

        if (IsDead())
        {
            initiateDeathEvent();
            return;
        }

        checkoutBars();
    }

    public virtual void CheckoutEffects()
    {
        UnitOperations.CheckoutEffects(_effects, _model, _parameters);
        checkoutBars();
    }

    public bool IsDead()
    {
        return _parameters.Health <= 0;
    }

    public virtual void Reset()
    {
        _model = null;
        _effects.Clear();
        _effectsBar.Reset();
        _abilitiesBar.Reset();
    }

    protected virtual void checkoutBars()
    {
        _healthBar.UpdateHealth(_model.MaxHealth, _parameters.Health, _parameters.Shield);
        _effectsBar.UpdateEffects(_effects);
    }

    protected virtual void initiateDeathEvent()
    {
    }
}
