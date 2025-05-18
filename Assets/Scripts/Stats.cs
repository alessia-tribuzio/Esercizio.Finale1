using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public struct Stats
{
    public int atk;
    public int def;
    public int res;
    public int spd;
    public int crt;
    public int aim;
    public int eva;

    public Stats(int atk, int def, int res, int spd, int crt, int aim, int eva)
    {
        this.atk = atk;
        this.def = def;
        this.res = res;
        this.spd = spd;
        this.crt = crt;
        this.aim = aim;
        this.eva = eva;
    }
    public static Stats Sum(Stats a, Stats b)
    {
        Stats result;
        result.atk = a.atk + b.atk;
        result.def = a.def + b.def;
        result.res = a.res + b.res;
        result.spd = a.spd + b.spd;
        result.crt = a.crt + b.crt;
        result.aim = a.aim + b.aim;
        result.eva = a.eva + b.eva;
        return result;
    }
}
