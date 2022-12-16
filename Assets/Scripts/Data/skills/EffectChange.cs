using System;
using UnityEngine;

[Serializable]
public class EffectChange
{
    [SerializeField]
    private int _id;
    [SerializeField]
    private bool _add;

    public int Id
    {
        get { return _id; }
        private set { _id = value; }
    }

    public bool Add
    {
        get { return _add; }
        private set { _add = value; }
    }

}