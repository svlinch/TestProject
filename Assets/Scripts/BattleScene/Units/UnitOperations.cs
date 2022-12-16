using System.Collections.Generic;

public class UnitOperations
{
    public static void CheckForDeadUnits(List<SimpleUnit> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].IsDead())
            {
                list[i].Reset();
                list.RemoveAt(i);
                i--;
            }
        }
    }

    public static void CheckForEndGame(List<SimpleUnit> playerUnits, List<SimpleUnit> enemyUnits)
    {
        if (enemyUnits.Count == 0 || playerUnits.Count == 0)
        {
            Events.RestartGame.Invoke();
        }
    }

    public static void CheckoutEffects(List<BattleEffect> effects, UnitModel model, UnitParameters parameters)
    {
        for (int i = 0; i < effects.Count; i++)
        {
            ApplyChange(effects[i].OnContinueParametersChange, model, parameters);

            effects[i].ChangeDuration(-1);
            if (effects[i].Duration <= 0)
            {
                ApplyChange(effects[i].OnEndParametersChange, model, parameters);
                effects.RemoveAt(i);
                i--;
            }
            else if (effects[i].EarlyEndCondition != null && effects[i].EarlyEndCondition.CheckCondition(model, parameters))
            {
                effects.RemoveAt(i);
                i--;
            }
        }
    }

    public static void ApplySkill(SkillModel skill, UnitModel model, UnitParameters parameters, List<BattleEffect> effects)
    {
        foreach (var change in skill.GetParameterChanges())
        {
            ApplyChange(change, model, parameters);
        }
        foreach (var effect in skill.GetEffectChanges())
        {
            ApplyEffect(effect, effects);
        }
    }

    public static void ApplyChange(ParameterChange change, UnitModel model, UnitParameters parameters)
    {
        var sign = change.Sign ? 1 : -1;
        switch (change.ApplyType)
        {
            case EnumHolder.ParameterChangeType.Health:
                parameters.ChangeHealth(parameters.Health + change.ChangeAmount * sign);
                break;
            case EnumHolder.ParameterChangeType.Shield:
                parameters.ChangeShield(parameters.Shield + change.ChangeAmount * sign);
                break;
            case EnumHolder.ParameterChangeType.Both:
                if (sign > 0)
                {
                    var healthDifference = model.MaxHealth - parameters.Health;
                    var shieldChange = change.ChangeAmount - healthDifference;

                    parameters.ChangeHealth(parameters.Health + change.ChangeAmount);
                    if (shieldChange > 0)
                    {
                        parameters.ChangeShield(parameters.Shield + shieldChange);
                    }
                }
                else
                {
                    parameters.ChangeShield(parameters.Shield - change.ChangeAmount);
                    if (parameters.Shield < 0)
                    {
                        parameters.ChangeHealth(parameters.Health + parameters.Shield);
                    }
                }
                break;
        }
        if (parameters.Health > model.MaxHealth)
        {
            parameters.ChangeHealth(model.MaxHealth);
        }
        if (parameters.Shield < 0)
        {
            parameters.ChangeShield(0);
        }
    }

    public static void ApplyEffect(EffectChange change, List<BattleEffect> effects)
    {
        if (!change.Add)
        {
            for(int i = 0; i < effects.Count; i++)
            {
                if (effects[i].Id == change.Id)
                {
                    effects.RemoveAt(i);
                    return;
                }
            }
        }
        else
        {
            var effectModel = GameData.Instance.GetBattleEffect(change.Id);
            var alreadyExists = false;

            for (int i = 0; i < effects.Count; i++)
            {
                if (effects[i].Id == change.Id)
                {
                    alreadyExists = true;
                    effects[i].Update(effectModel);
                }
            }
            if (!alreadyExists)
            {
                effects.Add(effectModel);
            }
        }
    }
}
