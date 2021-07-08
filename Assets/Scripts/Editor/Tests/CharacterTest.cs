using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CharacterTest
    {
        Character character;
        Character target;

        [SetUp]
        public void SetUp()
        {
            character = new Character();
            
        }

        [Test]
        public void CharacterTestHealth()
        {


            Assert.AreEqual(1000, character.Health);
        }

        [Test]
        public void CharacterTestLevel()
        {
            Assert.AreEqual(1, character.Level);
        }

        [Test]
        public void CharacterTestAlive()
        {
            Assert.IsTrue(character.Alive);
        }

        [Test]
        public void CharacterTakeDamage()
        {
            int initialHealth = character.Health;

            character.TakeDamage(50);

            Assert.AreEqual(initialHealth - 50, character.Health);
        }

        [Test]
        public void CharacterDealDamage()
        {
            target = new Character();

            int initialHealth = target.Health;

            character.DealDamage(target);

            Assert.AreEqual(initialHealth - character.AttackDamage, target.Health);
        }

        [Test]
        public void CharactersDiesOnHealthBelow0()
        {
            int initialHealth = character.Health;

            character.TakeDamage(initialHealth + 1);

            Assert.AreEqual(0, character.Health);

            Assert.IsFalse(character.Alive);
        }

        [Test]
        public void CharacterTakeHeal()
        {
            character.TakeDamage(50);
            int initialHealth = character.Health;

            character.TakeHeal(50);

            Assert.AreEqual(initialHealth + 50, character.Health);
        }

        [Test]
        public void CharacterCannotHealIsDead()
        {
            character.TakeDamage(character.Health);
            int initialHealth = character.Health;

            character.TakeHeal(50);

            Assert.AreEqual(initialHealth, character.Health);
        }

        [Test]
        public void CharacterMaxHeal()
        {
            character.TakeDamage(50);

            character.TakeHeal(51);

            Assert.AreEqual(character.MaxHealth, character.Health);
        }
    }
}