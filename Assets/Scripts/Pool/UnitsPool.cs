public class UnitsPool : PoolSection<SimpleUnit>
{
    public override void FullReset()
    {
        for (int i = 0; i < _busyObjects.Count; i++)
        {
            _busyObjects[i].Reset();
            i--;
        }
    }
}