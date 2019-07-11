using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class BossEnemyShould
    {

        private readonly ITestOutputHelper output;

        public BossEnemyShould(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        [Trait("Category", "Boss")]
        public void HaveCrrectPower()
        {
            //Floating point values

            output.WriteLine("Creating boss enemy"); //create output in test
            //Arrange
            BossEnemy sut = new BossEnemy();

            //Act

            //Assert
            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
        }
    }
}
