using UnityEngine;
using System;

[Serializable]
public class GameRules
{
    [SerializeField]
    private int _enemies;
    public int Enemies
    {
        get { return _enemies; }
    }

    [SerializeField]
    private int _players; 
    public int Players
    {
        get { return _players; }
    }
}
