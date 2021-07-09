using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GamePresenterTest
    {
        GamePresenter gamePresenter;

        [SetUp]
        public void SetUp()
        {
            GameObject go = new GameObject();
            GameView gameView = go.AddComponent<GameView>();

            gamePresenter = new GamePresenter(gameView);
        }

        [Test][Ignore("No implementado")]
        public void GamePresenterAttack()
        {
            gamePresenter.Attack("Matias", "Nicolas");
        }

        [Test][Ignore("No implementado")]
        public void GamePresenterHeal()
        {
            gamePresenter.Heal("Nicolas", "Nicolas");
        }
    }
}
