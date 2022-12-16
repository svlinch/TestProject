using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolSection<T>: MonoBehaviour where T: Component
{
    [SerializeField]
    private int Limit;
    [SerializeField]
    private GameObject Prefab;
    [SerializeField]
    private Transform _transform;

    [SerializeField]
    protected List<T> _busyObjects;
    [SerializeField]
    protected Stack<T> _freeObjects;

    public virtual IEnumerator Initialize()
    {
        _busyObjects = new List<T>();
        _freeObjects = new Stack<T>();

        for(int i = 0; i < Limit; i++)
        {
            var newObj = Instantiate(Prefab, transform);
            newObj.name = i.ToString();
            _freeObjects.Push(newObj.GetComponent<T>());
            yield return null;
        }
        yield return null;
    }

    public virtual T GetFreeObject()
    {
        var toReturn = _freeObjects.Pop();
        _busyObjects.Add(toReturn);
        return toReturn;
    }

    public virtual void ReturnObject(T obj)
    {
        obj.transform.SetParent(transform);
        obj.transform.localPosition = Vector3.zero;
        _busyObjects.Remove(obj);
        _freeObjects.Push(obj);
    }

    public abstract void FullReset();
}