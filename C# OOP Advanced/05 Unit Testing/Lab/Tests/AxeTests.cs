using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            const int Health = 10;
            const int Experience = 10;
            const int Attack = 10;
            const int Durability = 10;

            Dummy dummy = new Dummy(Health, Experience);
            Axe axe = new Axe(Attack, Durability);

            axe.Attack(dummy);
            int expectedDurability = 9;

            Assert.That(expectedDurability.Equals(axe.DurabilityPoints), "Axe Durability doesn't change after attack.");
        }

        [Test]
        public void AxeThrowsExceptionIfBboken()
        {
            const int Health = 10;
            const int Experience = 10;
            const int Attack = 10;
            const int Durability = 0;

            Dummy dummy = new Dummy(Health, Experience);
            Axe axe = new Axe(Attack, Durability);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}
