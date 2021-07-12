
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

namespace Tests
{
    public class GamePresenterTest
    {
        GamePresenter gamePresenter;
        IGameView gameView;
        [SetUp]
        public void SetUp()
        {
            gameView = Substitute.For<IGameView>();
            gamePresenter = new GamePresenter(gameView);
        }

        [Test]
        public void GamePresenterAttack()
        {
            gameView.ClearReceivedCalls();

            gamePresenter.Attack("Matias", "Nicolas");
            Character origin = gamePresenter.FindCharacter("Matias");
            Character target = gamePresenter.FindCharacter("Nicolas");
            origin.DealDamage(target);
            gameView.Received(1).OnUpdate(target);
        }

        [Test]
        public void GamePresenterHeal()
        {
            gameView.ClearReceivedCalls();

            gamePresenter.Heal("Matias", "Matias");
            Character origin = gamePresenter.FindCharacter("Matias");
            Character target = gamePresenter.FindCharacter("Matias");
            origin.Heal(target);
            gameView.Received(1).OnUpdate(target);
        }
    }
}
