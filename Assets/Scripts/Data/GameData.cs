using System.Collections;
using UnityEngine;

public class GameData : SingletonStarter<GameData>
{
    private GameRules _rules;
    private UnitModels _unitModels;
    private SkillModels _skillModels;
    private EffectModels _effectModels;

    public override IEnumerator Initialize()
    {
        _rules = JsonUtility.FromJson<GameRules>(Resources.Load<TextAsset>("GameRules").ToString());
        yield return null;
        _unitModels = JsonUtility.FromJson<UnitModels>(Resources.Load<TextAsset>("UnitModels").ToString());
        yield return null;
        _skillModels = JsonUtility.FromJson<SkillModels>(Resources.Load<TextAsset>("SkillModels").ToString());
        yield return null;
        _effectModels = JsonUtility.FromJson<EffectModels>(Resources.Load<TextAsset>("EffectModels").ToString());
        yield return null;
    }

    public int GetRules(bool player)
    {
        return player ? _rules.Players: _rules.Enemies;
    }

    public UnitModel GetUnitModel(int id)
    {
        return _unitModels.GetModel(id);
    }

    public SkillModel GetSkillModel(int id)
    {
        return _skillModels.GetSkillModel(id);
    }

    public BattleEffect GetBattleEffect(int id)
    {
        return _effectModels.GetBattleEffect(id).Clone();
    }
}