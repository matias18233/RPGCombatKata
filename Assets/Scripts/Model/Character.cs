using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int Level { get; private set; }
    public bool Alive { get; set; }

    public int AttackDamage { get; set; }

    public Character()
    {
        MaxHealth = 1000;
        Health = MaxHealth;
        Level = 1;
        Alive = true;
        
        AttackDamage = 50;
    }

    public void DealDamage(Character target)
    {

        target.TakeDamage(AttackDamage);
    }

    public void TakeDamage(int damage)
    {

        Health -= damage;
        if (Health <= 0)
        {
            Health = 0;
            Alive = false;
        }
    }

    public void TakeHeal(int heal)
    {
        if (!Alive) return;

        Health += heal;

        if (Health > MaxHealth)
            Health = MaxHealth;
    }
}
