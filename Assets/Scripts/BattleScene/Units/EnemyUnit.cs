public class EnemyUnit : SimpleUnit
{
    public override void Reset()
    {
        base.Reset();
        Pool.Instance.ReturnEnemyUnit(this);
    }

    public AbilityIcon GetAbility()
    {
        return _abilitiesBar.GetCurrentAbility();
    }

    protected override void initiateDeathEvent()
    {
        Events.UnitIsDead.Invoke(false);
    }
}
