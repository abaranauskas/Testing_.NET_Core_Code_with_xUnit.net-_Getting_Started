﻿using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests
{
    public class GameStateShould : IClassFixture<GameStateFixture>
    {
        private readonly GameStateFixture _gameStateFixture;
        private readonly ITestOutputHelper _output;

        public GameStateShould(GameStateFixture gameStateFixture, ITestOutputHelper testOutput)
        {
            _gameStateFixture = gameStateFixture;
            _output = testOutput;
        }

        [Fact]
        public void DamageAllPlayersWhenEarthquake()
        {
            _output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _gameStateFixture.State.Players.Add(player1);
            _gameStateFixture.State.Players.Add(player2);

            var expectedHealthAfterEarthquake = player1.Health - GameState.EarthquakeDamage;

            _gameStateFixture.State.Earthquake();

            Assert.Equal(expectedHealthAfterEarthquake, player1.Health);
            Assert.Equal(expectedHealthAfterEarthquake, player2.Health);
        }

        [Fact]
        public void Reset()
        {
            _output.WriteLine($"GameState ID={_gameStateFixture.State.Id}");

            var player1 = new PlayerCharacter();
            var player2 = new PlayerCharacter();

            _gameStateFixture.State.Players.Add(player1);
            _gameStateFixture.State.Players.Add(player2);

            _gameStateFixture.State.Reset();

            Assert.Empty(_gameStateFixture.State.Players);
        }


        //[Fact]
        //public void DamageAllPlayersWhenEarthquake()
        //{
        //    var sut = new GameState();

        //    var player1 = new PlayerCharacter();
        //    var player2 = new PlayerCharacter();

        //    sut.Players.Add(player1);
        //    sut.Players.Add(player2);

        //    var expectedHealthAfterEarthquake = player1.Health - GameState.EarthquakeDamage;

        //    sut.Earthquake();

        //    Assert.Equal(expectedHealthAfterEarthquake, player1.Health);
        //    Assert.Equal(expectedHealthAfterEarthquake, player2.Health);
        //}

        //[Fact]
        //public void Reset()
        //{
        //    var sut = new GameState();

        //    var player1 = new PlayerCharacter();
        //    var player2 = new PlayerCharacter();

        //    sut.Players.Add(player1);
        //    sut.Players.Add(player2);

        //    sut.Reset();

        //    Assert.Empty(sut.Players);
        //}
    }
}
