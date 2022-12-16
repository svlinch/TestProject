using UnityEngine;

public class AbilitiesBar : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;
    private SimpleUnit _unit;
    private AbilityIcon _abilityIcon;

    public void Initialize(SimpleUnit unit)
    {
        _unit = unit;
    }

    public void UpdateSkill(int skillId)
    {
        _abilityIcon = Pool.Instance.GetAbility();
        _abilityIcon.Initialize(_unit, skillId, _transform);
    }

    public AbilityIcon GetCurrentAbility()
    {
        return _abilityIcon;
    }

    public void Reset()
    {
        _abilityIcon = null;
        _unit = null;
    } 
}