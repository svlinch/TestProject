public class PlayerUnit : SimpleUnit
{
    public override void Reset()
    {
        base.Reset();
        Pool.Instance.ReturnPlayerUnit(this);
    }

    protected override void initiateDeathEvent()
    {
        Events.UnitIsDead.Invoke(true);
    }
}
