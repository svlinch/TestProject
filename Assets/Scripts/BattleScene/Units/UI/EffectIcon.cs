using UnityEngine;
using UnityEngine.UI;

public class EffectIcon : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private Image _image;
    
    public int Id
    {
        get;
        private set;
    }
    
    public void Initialize(int id, Transform transform)
    {
        Id = id;
        switch(id)
        {
            case 0: _image.color = Color.green; break;
            case 1: _image.color = Color.blue; break;
            case 2: _image.color = Color.yellow; break;
        }
        _transform.SetParent(transform);
    }

    public void Reset()
    {
        Pool.Instance.ReturnEffectIcon(this);
    }
}