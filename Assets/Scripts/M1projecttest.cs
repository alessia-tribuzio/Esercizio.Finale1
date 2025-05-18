using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1projecttest : MonoBehaviour
{ public Hero a = new Hero 
        (
    "Giovanni", 
    100,
    new Stats (10, 10, 10, 10, 10, 80, 10),
    ELEMENT.FIRE,
    ELEMENT.ELECTRICS,
    new Weapon (
        "spada",
        Weapon.DAMAGE_TYPE.PHYSICAL,
        ELEMENT.ICE,
        new Stats ( 5, 5, 5, 5, 5, 5, 5)
        )
    );
    public Hero b = new Hero 
        (
    "Francesco", 
    100,
    new Stats (10, 10, 10, 10, 10, 80, 10),
    ELEMENT.ICE,
    ELEMENT.FIRE,
    new Weapon (
        "martello",
        Weapon.DAMAGE_TYPE.MAGICAL,
        ELEMENT.ELECTRICS,
        new Stats ( 5, 5, 5, 5, 5, 5, 5)
        )
    );
    private bool endDual = false;

    public void Start()
    {
        Debug.Log("The Duel Start: " + a.name1 + " VS " + b.name1 + ".");

    }

    public void Update()
    {
        if (!endDual)
        {
            duel(a, b);
            endDual = true;
        }
    }

    public void duel(Hero a, Hero b)
    {
        int speed1 = a.baseStats1.spd + a.weapon1.BonusStats.spd;
        int speed2 = b.baseStats1.spd + b.weapon1.BonusStats.spd;

        while (a.IsAlive(a.hp1) && b.IsAlive(b.hp1))
        {

            if (speed1 >= speed2)
            {
                Attack(a, b);
                if (b.IsAlive(b.hp1))
                    Attack(b, a);
            }
            else
            {
                Attack(b, a);
                if (a.IsAlive(a.hp1))
                    Attack(a, b);
            }
        }

        Debug.Log("Duel ended");
        if (!a.IsAlive(a.hp1))
        {
            Debug.Log(a.name1 + " is defeated. " + b.name1 + " wins.");
        }
        else if (!b.IsAlive(b.hp1))
        {
            Debug.Log(b.name1 + " is defeated. " + a.name1 + " wins.");
        }
    }

    private void Attack(Hero attacker, Hero defender)
    {
        Debug.Log(attacker.name1 + " attacks and " + defender.name1 + " defends.");

        if (GameFormulas.HasHit(attacker.baseStats1, defender.baseStats1))
        {
            int damage = GameFormulas.CalculateDamage(attacker, defender);
            defender.TakeDamage(damage);
            Debug.Log(attacker.name1 + "'s hit connects! " + defender.name1 + " takes " + damage + " damage. HP left: " + defender.hp1);
        }
        else
        {
            Debug.Log(attacker.name1 + "'s attack missed!");
        }

    }
}
