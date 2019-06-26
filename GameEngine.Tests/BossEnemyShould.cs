using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameEngine.Tests
{
    

    public class BossEnemyShould
    {
        [Fact]
        public void HaveCrrectPower()
        {
            //Floating point values

            //Arrange
            BossEnemy sut = new BossEnemy();

            //Act

            //Assert
            Assert.Equal(166.667, sut.TotalSpecialAttackPower, 3);
        }
    }
}
