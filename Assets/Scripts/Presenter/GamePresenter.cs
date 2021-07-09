using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter
{
    List<Character> Characters = new List<Character>();
    IGameView gameView;

    public GamePresenter(IGameView gameView)
    {
        this.gameView = gameView;

        Character nicolas = new Character("Nicolas");
        Characters.Add(nicolas);
        gameView.OnCreate(nicolas);

        Character matias = new Character("Matias");
        Characters.Add(matias);
        gameView.OnCreate(matias);
    }

    public void Attack(string nameOrigin, string nameTarget)
    {
        Character origin = FindCharacter(nameOrigin);
        Character target = FindCharacter(nameTarget);

        if (origin == null || target == null) return;

        origin.DealDamage(target);

        gameView.OnUpdate(target);
    }

    public void Heal(string nameOrigin, string nameTarget)
    {
        Character origin = FindCharacter(nameOrigin);
        Character target = FindCharacter(nameTarget);

        if (origin == null || target == null) return;
        
        origin.Heal(target);

        gameView.OnUpdate(target);
    }

    public Character FindCharacter(string name) => Characters.Find(character => character.Name.Equals(name));
}
