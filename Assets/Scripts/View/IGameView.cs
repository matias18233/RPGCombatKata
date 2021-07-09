using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameView
{
    void OnCreate(Character character);

    void OnUpdate(Character character);
}
