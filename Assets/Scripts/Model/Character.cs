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

        if ((Level - target.Level) >= 5)
            damage = (int)(AttackDamage * 1.5f);
        else if ((target.Level - Level) >= 5)
            damage = (int)(AttackDamage * 0.5f);

        target.TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        UnityEngine.Mathf.Clamp(Health, 0, MaxHealth);
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

        //UnityEngine.Mathf.Clamp(Health, 0, MaxHealth);
        if (Health > MaxHealth)
            Health = MaxHealth;
    }
}




/*
public abstract class BaseSkill
{
    public Character owner;
    public Character target;

    public abstract void Execute();
    public void SetTarget(Character target) { this.target = target; }
}

public class Heal : BaseSkill
{
    public override void Execute()
    {
        owner.Heal(target);
    }
}
public class Attack : BaseSkill
{
    public override void Execute()
    {
        owner.DealDamage(target);
    }
}
*/
