using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]

public static class GameFormulas
{
    public static bool HasElementAdvantage(ELEMENT attackElement, Hero defender)
    {
        if (attackElement == defender.weakness1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool ElementDisadvantage(ELEMENT attackElement, Hero defender)
    {
        if (attackElement == defender.resistence1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static float EvaluateElementalModifier(ELEMENT attackElement, Hero defender)
    {
        if (HasElementAdvantage(attackElement, defender) && !ElementDisadvantage(attackElement, defender))
        {
            Debug.Log("WEAKNESS");
            return 1.5f;
        }
        else if (ElementDisadvantage(attackElement, defender) && !HasElementAdvantage(attackElement, defender))
        {
            Debug.Log("RESIST");
            return 0.5f;
        }
        else
        { return 1f; }
    }

    public static bool HasHit(Stats attacker, Stats defender)
    {
        int hitChance = Math.Clamp(attacker.aim - defender.eva, 1, 100);
        int chance = Random.Range(0, 100);
        if (chance < hitChance)
        {
            return true;
        }
        else
        {
            Debug.Log("MISS");
            return false;
        }
    }
    public static bool IsCrit(Stats attacker)
    {
        int critValue = attacker.crt;
        int critical = Random.Range(0, 99);
        if (critical < critValue)
        {
            Debug.Log("CRIT");
            return true;
        }
        else
        {
            return false;
        }
    }
    public static int CalculateDamage(Hero attacker, Hero defender)
    {
        Stats finalAttack = Stats.Sum(attacker.baseStats1, attacker.weapon1.BonusStats);
        int defense = defender.baseStats1.def;
        int baseDamage = Mathf.Max(finalAttack.atk - defense, 1);
        float elementalModifier = EvaluateElementalModifier(attacker.weapon1.Elem, defender);
        float critModifier = IsCrit(finalAttack) ? 2f : 1f;
        float finalDamage = baseDamage * elementalModifier * critModifier;

        return Mathf.Max(Mathf.RoundToInt(finalDamage), 0);
    }
}

