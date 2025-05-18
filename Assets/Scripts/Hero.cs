using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Hero
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int hp;
    [SerializeField]
    private Stats baseStats;
    [SerializeField]
    private ELEMENT resistence;
    [SerializeField]
    private ELEMENT weakness;
    [SerializeField]
    private Weapon weapon;

    public Hero(string name, int hp, Stats baseStats, ELEMENT resistence,
        ELEMENT weakness, Weapon weapon)
    {

        this.name = name;
        this.hp = hp;
        this.baseStats = baseStats;
        this.resistence = resistence;
        this.weakness = weakness;
        this.weapon = weapon;
    }

    public string name1
    {
        get => name;
        set => name = value;
    }
    public int hp1
    {
        get => hp;
        set => hp = value;
    }

    public Stats baseStats1
    {
        get => baseStats;
        set => baseStats = value;
    }

    public ELEMENT resistence1
    {
        get => resistence;
        set => resistence = value;
    }

    public ELEMENT weakness1
    {
        get => weakness;
        set => weakness = value;
    }
    public Weapon weapon1
    {
        get => weapon;
        set => weapon = value;
    }
    public int AddHp(int amount)
    {


        hp = Mathf.Max(hp + amount, 0);
        return hp;

    }

    public int TakeDamage(int damage)
    {
        return AddHp(-damage);
    }

    public bool IsAlive(int hp)
    {
        if (hp == 0)
        { return false; }
        else
        { return true; }
    }

}
