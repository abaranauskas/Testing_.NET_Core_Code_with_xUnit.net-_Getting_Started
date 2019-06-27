using System;
using Xunit;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould
    {
        [Fact]
        public void BeInexperiencedWhenNew()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();

            //Assert
            Assert.True(sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";
            var expected = "Sarah Smith";

            //Act


            //Assert
            Assert.Equal(expected, sut.FullName);
        }

        [Fact]
        public void HaveFullNameStatingWithFirstName()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";
            var expected = "Sarah";

            //Act


            //Assert
            Assert.StartsWith(expected, sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";
            var expected = "Smith";

            //Act


            //Assert
            Assert.EndsWith(expected, sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCase()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "SARAH";
            sut.LastName = "SMITH";
            var expected = "Sarah Smith";

            //Act


            //Assert
            Assert.Equal(expected, sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubStringAssert()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";
            var substring = "ah Sm";

            //Act


            //Assert
            Assert.Contains(substring, sut.FullName);
        }


        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            sut.FirstName = "Sarah";
            sut.LastName = "Smith";
            var regExPattern = "[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+";

            //Act


            //Assert
            Assert.Matches(regExPattern, sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            int expected = 100;

            //Act


            //Assert
            Assert.Equal(expected, sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();

            //Act


            //Assert
            Assert.NotEqual(0, sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();

            //Act
            sut.Sleep();

            //Assert
            //Assert.True(sut.Health >= 101 && sut.Health <= 201); 
            //better way bellow
            Assert.InRange(sut.Health, 101, 201);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();

            //Act

            //Assert            
            Assert.Null(sut.Nickname);
        }


        [Fact]
        public void ContainALongBow()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();

            //Act

            //Assert            
            Assert.Contains("Long Bow", sut.Weapons);
        }


        [Fact]
        public void NotContainABazuka()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();

            //Act

            //Assert            
            Assert.DoesNotContain("Bazuka", sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();

            //Act

            //Assert            
            Assert.Contains(sut.Weapons, w => w.Contains("sword", StringComparison.CurrentCultureIgnoreCase));
        }


        [Fact]
        public void HaveAllExpectedWeapons()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();
            var expectedWeapons = new string[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            //Act

            //Assert            
            Assert.Equal(expectedWeapons, sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();

            //Act

            //Assert            
            Assert.All(sut.Weapons, w => Assert.False(string.IsNullOrWhiteSpace(w)));
        }


        [Fact]
        public void RaiseSleptEvent()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();

            //Act

            //Assert            
            Assert.Raises<EventArgs>(
                handler => sut.PlayerSlept += handler,
                handler => sut.PlayerSlept -= handler,
                () => sut.Sleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            //Arrange
            PlayerCharacter sut = new PlayerCharacter();

            //Act

            //Assert            
            Assert.PropertyChanged(sut, "Health", () => sut.TakeDamage(12));
        }

    }
}
