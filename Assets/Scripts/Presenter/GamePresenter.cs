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
        
        Characters.Add(new Character("Nicolas"));
        Characters.Add(new Character("Matias"));
    }

    public void Attack(string nameOrigin, string nameTarget)
    {
        Character origin = FindCharacter(nameOrigin);
        Character target = FindCharacter(nameTarget);

        origin.DealDamage(target);
    }

    public void Heal(string nameOrigin, string nameTarget)
    {
        Character origin = FindCharacter(nameOrigin);
        Character target = FindCharacter(nameTarget);

        origin.Heal(target);
    }

    public Character FindCharacter(string name) => Characters.Find(character => character.Name.Equals(name));
}
