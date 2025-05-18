using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Weapon
{
    public enum DAMAGE_TYPE { PHYSICAL, MAGICAL }

    [SerializeField]
    private string name;
    [SerializeField]
    private DAMAGE_TYPE type;
    [SerializeField]
    private ELEMENT elem;
    [SerializeField]
    private Stats bonusStats;

    public Weapon(string name, DAMAGE_TYPE type, ELEMENT elem, Stats bonusStats)
    {
        this.name = name;
        this.type = type;
        this.elem = elem;
        this.bonusStats = bonusStats;
    }
    public string Name
    {
        get => name;
        set => name = value;
    }

    public DAMAGE_TYPE Type
    {
        get => type;
        set => type = value;
    }

    public ELEMENT Elem
    {
        get => elem;
        set => elem = value;
    }

    public Stats BonusStats
    {
        get => bonusStats;
        set => bonusStats = value;
    }
}
