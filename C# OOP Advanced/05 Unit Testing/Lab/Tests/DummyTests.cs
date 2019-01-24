using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    [TestFixture]
    public class DummyTests
    { 
        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            //Arrange
            const int Health = 10;
            const int Experience = 10;
            const int AttackPoints = 5;
            Dummy dummy = new Dummy(Health, Experience);

            //Act
            dummy.TakeAttack(AttackPoints);
            int expectedHealthAfterAttack = 5;

            //Assert
            Assert.That(expectedHealthAfterAttack.Equals(dummy.Health));
        }

        [Test]
        public void DeadDummyThrowsExceptionIfAttacked()
        {
            const int Health = 0;
            const int Experience = 5;
            const int AttackPoints = 1;

            Dummy dummy = new Dummy(Health, Experience);
            
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(AttackPoints));
        }

        [Test]
        public void DeadDummyCanGiveExperience()
        {
            const int Health = 0;
            const int Experience = 5;

            Dummy dummy = new Dummy(Health, Experience);

            int experience = dummy.GiveExperience();
            int expectedReturnValue = 5;

            Assert.That(expectedReturnValue.Equals(experience));
        }

        [Test]
        public void AliveDummyCanNotGiveExperience()
        {
            const int Health = 2;
            const int Experience = 5;

            Dummy dummy = new Dummy(Health, Experience);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}
