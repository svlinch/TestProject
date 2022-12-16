using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[Serializable]
public class UnitModel
{
    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private List<int> _availableSkills;

    public int MaxHealth
    {
        get { return _maxHealth; }
        private set { _maxHealth = value; }
    }

    public ReadOnlyCollection<int> GetAvailableSkills()
    {
        return _availableSkills.AsReadOnly();
    }
}

public class UnitParameters
{
    public int Health
    {
        get;
        private set;
    } 

    public int Shield
    {
        get;
        private set;
    }

    public void Build(UnitModel model)
    {
        Health = model.MaxHealth;
        Shield = 0;
    }

    public void ChangeHealth(int newHealth)
    {
        Health = newHealth;
    }

    public void ChangeShield(int newShield)
    {
        Shield = newShield;
    }
}
