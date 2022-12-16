public class AbilitiesPool : PoolSection<AbilityIcon>
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