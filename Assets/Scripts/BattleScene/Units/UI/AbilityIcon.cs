using UnityEngine;
using TMPro;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    [SerializeField]
    private Transform _transform;

    private SimpleUnit _unit;
    private int _id;

    public void Initialize(SimpleUnit unit, int id, Transform parent)
    {
        _transform.SetParent(parent);
        _unit = unit;
        _id = id;
        _text.text = _id.ToString();
    }

    public bool GetTargetInfo()
    {
        return GameData.Instance.GetSkillModel(_id).Self;
    }

    public SimpleUnit GetUnit()
    {
        return _unit;
    }

    public int GetId()
    {
        return _id;
    }

    public void Reset()
    {
        _unit = null;
        Pool.Instance.ReturnAbility(this);
    }
}