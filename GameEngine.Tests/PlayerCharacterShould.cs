using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class PlayerCharacterShould : IDisposable
    {
        private readonly PlayerCharacter _sut;
        private readonly ITestOutputHelper testOutput;

        public PlayerCharacterShould(ITestOutputHelper testOutput)
        {
            this.testOutput = testOutput;
            testOutput.WriteLine("Creating new player character");
            _sut = new PlayerCharacter();
        }

        [Fact]
        public void BeInexperiencedWhenNew()
        {
            //Arrange


            //Assert
            Assert.True(_sut.IsNoob);
        }

        [Fact]
        public void CalculateFullName()
        {
            //Arrange
            ;
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";
            var expected = "Sarah Smith";

            //Act


            //Assert
            Assert.Equal(expected, _sut.FullName);
        }

        [Fact]
        public void HaveFullNameStatingWithFirstName()
        {
            //Arrange            
            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";
            var expected = "Sarah";

            //Act


            //Assert
            Assert.StartsWith(expected, _sut.FullName);
        }

        [Fact]
        public void HaveFullNameEndingWithLastName()
        {
            //Arrange

            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";
            var expected = "Smith";

            //Act


            //Assert
            Assert.EndsWith(expected, _sut.FullName);
        }

        [Fact]
        public void CalculateFullName_IgnoreCase()
        {
            //Arrange

            _sut.FirstName = "SARAH";
            _sut.LastName = "SMITH";
            var expected = "Sarah Smith";

            //Act


            //Assert
            Assert.Equal(expected, _sut.FullName, ignoreCase: true);
        }

        [Fact]
        public void CalculateFullName_SubStringAssert()
        {
            //Arrange

            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";
            var substring = "ah Sm";

            //Act


            //Assert
            Assert.Contains(substring, _sut.FullName);
        }


        [Fact]
        public void CalculateFullNameWithTitleCase()
        {
            //Arrange

            _sut.FirstName = "Sarah";
            _sut.LastName = "Smith";
            var regExPattern = "[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+";

            //Act


            //Assert
            Assert.Matches(regExPattern, _sut.FullName);
        }

        [Fact]
        public void StartWithDefaultHealth()
        {
            //Arrange

            int expected = 100;

            //Act


            //Assert
            Assert.Equal(expected, _sut.Health);
        }

        [Fact]
        public void StartWithDefaultHealth_NotEqualExample()
        {
            //Arrange


            //Act


            //Assert
            Assert.NotEqual(0, _sut.Health);
        }

        [Fact]
        public void IncreaseHealthAfterSleeping()
        {
            //Arrange


            //Act
            _sut.Sleep();

            //Assert
            //Assert.True(sut.Health >= 101 && sut.Health <= 201); 
            //better way bellow
            Assert.InRange(_sut.Health, 101, 201);
        }

        [Fact]
        public void NotHaveNickNameByDefault()
        {
            //Arrange


            //Act

            //Assert            
            Assert.Null(_sut.Nickname);
        }


        [Fact]
        public void ContainALongBow()
        {
            //Arrange


            //Act

            //Assert            
            Assert.Contains("Long Bow", _sut.Weapons);
        }


        [Fact]
        public void NotContainABazuka()
        {
            //Arrange


            //Act

            //Assert            
            Assert.DoesNotContain("Bazuka", _sut.Weapons);
        }

        [Fact]
        public void HaveAtLeastOneKindOfSword()
        {
            //Arrange


            //Act

            //Assert            
            Assert.Contains(_sut.Weapons, w => w.Contains("sword", StringComparison.CurrentCultureIgnoreCase));
        }


        [Fact]
        public void HaveAllExpectedWeapons()
        {
            //Arrange

            var expectedWeapons = new string[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            //Act

            //Assert            
            Assert.Equal(expectedWeapons, _sut.Weapons);
        }

        [Fact]
        public void HaveNoEmptyDefaultWeapons()
        {
            //Arrange


            //Act

            //Assert            
            Assert.All(_sut.Weapons, w => Assert.False(string.IsNullOrWhiteSpace(w)));
        }


        [Fact]
        public void RaiseSleptEvent()
        {
            //Arrange


            //Act

            //Assert            
            Assert.Raises<EventArgs>(
                handler => _sut.PlayerSlept += handler,
                handler => _sut.PlayerSlept -= handler,
                () => _sut.Sleep());
        }

        [Fact]
        public void RaisePropertyChangedEvent()
        {
            //Arrange


            //Act

            //Assert            
            Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(12));
        }

        //[Fact]
        //public void TakeZeroDemage()
        //{
        //    //Arrange


        //    //Act
        //    _sut.TakeDamage(0);

        //    //Assert            
        //    Assert.Equal(100, _sut.Health);
        //}

        //[Fact]
        //public void TakeSmallDemage()
        //{
        //    //Arrange


        //    //Act
        //    _sut.TakeDamage(1);

        //    //Assert            
        //    Assert.Equal(99, _sut.Health);
        //}


        //[Fact]
        //public void TakeMediumDemage()
        //{
        //    //Arrange


        //    //Act
        //    _sut.TakeDamage(50);

        //    //Assert            
        //    Assert.Equal(50, _sut.Health);
        //}

        //[Fact]
        //public void HaveMinimumOneHealth()
        //{
        //    //Arrange


        //    //Act
        //    _sut.TakeDamage(101);

        //    //Assert            
        //    Assert.Equal(1, _sut.Health);
        //}

        //data driven test [Theory] atributas

        [Theory]
        [InlineData(0,100)]
        [InlineData(1,99)]
        [InlineData(50,50)]
        [InlineData(101,1)]
        public void TakeDamage(int damage, int expectedHealth)
        {
            //Arrange

            //Act
            _sut.TakeDamage(damage);

            //Assert            
            Assert.Equal(expectedHealth, _sut.Health);
        }


        [Theory]
        [MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
        public void TakeDamage2(int damage, int expectedHealth)
        {
            //Arrange

            //Act
            _sut.TakeDamage(damage);

            //Assert            
            Assert.Equal(expectedHealth, _sut.Health);
        }

        [Theory]
        [MemberData(nameof(ExternalHealthDamageTestData.TestData), 
            MemberType = typeof(ExternalHealthDamageTestData))]
        public void TakeDamage3(int damage, int expectedHealth)
        {
            //Arrange

            //Act
            _sut.TakeDamage(damage);

            //Assert            
            Assert.Equal(expectedHealth, _sut.Health);
        }

        [Theory]
        [HealthDamageData] //custom attribute
        public void TakeDamage4(int damage, int expectedHealth)
        {
            //Arrange

            //Act
            _sut.TakeDamage(damage);

            //Assert            
            Assert.Equal(expectedHealth, _sut.Health);
        }





        public void Dispose()
        {
            testOutput.WriteLine($"Disposing PlayerCharacter {_sut.FullName}");
            //_sut.Dispose();
        }
    }
}
