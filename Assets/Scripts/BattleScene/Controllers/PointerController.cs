using System.Collections.Generic;
using UnityEngine;

public class PointerController : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private List<GameObject> _pointObjects;
    [SerializeField]
    private int _sectionSize;

    private Vector3 _startPoint;

    private void Awake()
    {
        Events.RestartGame += restartHandle;
    }

    public void StartDrag(Vector3 position)
    {
        _startPoint = position;
        _startPoint.z = 0;
        _transform.position = position;
    }

    public void UpdateDrag(Vector3 position)
    {
        position.z = 0;
        var direction = position - _startPoint;
        var angle = Vector3.Angle(Vector3.right, direction);
        if (_startPoint.y > position.y)
        {
            angle = -angle;
        }

        var range = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
        var sections = (int)(range - range % (_sectionSize)) /  (_sectionSize);

        if (sections > _pointObjects.Count - 1)
        {
            sections = _pointObjects.Count - 1;
        }

        for (int i = 0; i < sections; i++)
        {
            _pointObjects[i].SetActive(true);
        } 
        for (int i = sections; i < _pointObjects.Count; i++)
        {
            _pointObjects[i].SetActive(false);
        }

        _transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    public void Reset()
    {
        foreach(var point in _pointObjects)
        {
            point.SetActive(false);
        }
    }

    private void restartHandle()
    {
        Reset();
    }
}