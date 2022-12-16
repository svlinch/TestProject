using System.Collections;
using UnityEngine;

public class Pool : SingletonStarter<Pool>
{
    [SerializeField]
    private PoolSection<SimpleUnit> _playerUnitsSection;
    [SerializeField]
    private PoolSection<SimpleUnit> _enemyUnitsSection;
    [SerializeField]
    private PoolSection<AbilityIcon> _abilitiesSection;
    [SerializeField]
    private PoolSection<EffectIcon> _effectIconsSection;

    public override IEnumerator Initialize()
    {
        Events.RestartGame += restartHandle;

        yield return StartCoroutine(_playerUnitsSection.Initialize());
        yield return null;
        yield return StartCoroutine(_enemyUnitsSection.Initialize());
        yield return null;
        yield return StartCoroutine(_abilitiesSection.Initialize());
        yield return null;
        yield return StartCoroutine(_effectIconsSection.Initialize());
        yield return null;
    }

    public SimpleUnit GetPlayerUnit()
    {
        return _playerUnitsSection.GetFreeObject();
    }
    
    public SimpleUnit GetEnemyUnit()
    {
        return _enemyUnitsSection.GetFreeObject();
    }

    public AbilityIcon GetAbility()
    {
        return _abilitiesSection.GetFreeObject();
    }

    public EffectIcon GetIcon()
    {
        return _effectIconsSection.GetFreeObject();
    }

    public void ReturnPlayerUnit(SimpleUnit unit)
    {
        _playerUnitsSection.ReturnObject(unit);
    }

    public void ReturnEnemyUnit(SimpleUnit unit)
    {
        _enemyUnitsSection.ReturnObject(unit);
    }
    
    public void ReturnAbility(AbilityIcon ability)
    {
        _abilitiesSection.ReturnObject(ability);
    }

    public void ReturnEffectIcon(EffectIcon icon)
    {
        _effectIconsSection.ReturnObject(icon);
    }

    public void ResetAbilities()
    {
        _abilitiesSection.FullReset();
    }

    private void restartHandle()
    {
        _playerUnitsSection.FullReset();
        _enemyUnitsSection.FullReset();
        _abilitiesSection.FullReset();
        _effectIconsSection.FullReset();
    }
}