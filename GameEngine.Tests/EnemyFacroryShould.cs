using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameEngine.Tests
{
    public class EnemyFacroryShould
    {
        [Fact]
        public void CreateNormalEnemyByDefault()
        {
            //Arrange
            EnemyFactory sut = new EnemyFactory();

            //Act
            Enemy expectedEnemy = sut.Create("Xombie");

            //Assert
            Assert.IsType<NormalEnemy>(expectedEnemy);
        }

        [Fact]
        public void NotCreateBossEnemyByDefault()
        {
            //Arrange
            EnemyFactory sut = new EnemyFactory();

            //Act
            Enemy expectedEnemy = sut.Create("Xombie");

            //Assert
            Assert.IsNotType<BossEnemy>(expectedEnemy);
        }

        [Fact]
        public void CreateBossEnemy()
        {
            //Arrange
            EnemyFactory sut = new EnemyFactory();

            //Act
            Enemy expectedEnemy = sut.Create("Xombie King", true);

            //Assert
            Assert.IsType<BossEnemy>(expectedEnemy);
        }

        [Fact]
        public void CreateBossEnemy_CastReturnedTypeExample()
        {
            //Arrange
            EnemyFactory sut = new EnemyFactory();

            //Act
            Enemy expectedEnemy = sut.Create("Xombie King", true);

            //Assert
            var boss = Assert.IsType<BossEnemy>(expectedEnemy);

            Assert.Equal("Xombie King", boss.Name);
        }

        [Fact]
        public void CreateBossEnemy_AssertAssignableTypes()
        {
            //Arrange
            EnemyFactory sut = new EnemyFactory();

            //Act
            Enemy expectedEnemy = sut.Create("Xombie King", true);

            //Assert
            //Assert.IsType<Enemy>(expectedEnemy); //Stricktly
            Assert.IsAssignableFrom<Enemy>(expectedEnemy);

        }

        [Fact]
        public void CreateSeparateInstances()
        {
            //Arrange
            EnemyFactory sut = new EnemyFactory();

            //Act
            Enemy expectedEnemy1 = sut.Create("Xombie King", true);
            Enemy expectedEnemy2 = sut.Create("Xombie King", true);

            //Assert            
            Assert.NotSame(expectedEnemy1, expectedEnemy2);
        }


        [Fact]
        public void NotAllowNullName()
        {
            //Arrange
            EnemyFactory sut = new EnemyFactory();

            //Act

            //Assert            
            //Assert.Throws<ArgumentNullException>(()=> sut.Create(null));
            Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));
        }


        [Fact]
        public void OnlyAllowKingOrQueenEnemies()
        {
            //Arrange
            EnemyFactory sut = new EnemyFactory();

            //Act

            //Assert            
            EnemyCreationException ex =
                Assert.Throws<EnemyCreationException>(() => sut.Create("Zombiew", true));

            Assert.Equal("Zombiew", ex.RequestedEnemyName);
        }
    }
}
