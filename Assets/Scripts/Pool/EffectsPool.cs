public class EffectsPool : PoolSection<EffectIcon>
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