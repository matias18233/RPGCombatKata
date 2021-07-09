using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string Name { get; set; }
    public int MaxHealth { get; set; }
    public int Health { get; set; }
    public int Level { get; private set; }
    public bool Alive { get; set; }
    public int AttackDamage { get; set; }
    public int Medicine { get; set; }

    public Character(string name = "NN", int health = 1000, int level = 1)
    {
        Name = name;
        MaxHealth = health;
        Health = MaxHealth;
        Level = level;
        Alive = true;

        Medicine = 100;
        AttackDamage = 50;
    }

    public void DealDamage(Character target)
    {
        if (target.Equals(this)) return;

        int damage = AttackDamage;

        if ((this.Level - target.Level) >= 5)
            damage = (int)(AttackDamage * 1.5f);
        else if ((target.Level - this.Level) >= 5)
            damage = (int)(AttackDamage * 0.5f);

        target.TakeDamage(damage);
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

    public void Heal(Character target)
    {
        if (!target.Equals(this)) return;

        target.TakeHeal(Medicine);
    }

    public void TakeHeal(int heal)
    {
        if (!Alive) return;

        Health += heal;

        if (Health > MaxHealth)
            Health = MaxHealth;
    }
}
