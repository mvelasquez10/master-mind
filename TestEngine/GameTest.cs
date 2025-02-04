using Engine;

namespace TestEngine
{
    public class GameTest
    {
        #region Public Methods

        [Fact]
        public void Start_DuplicateDigit_ThrowException()
        {
            //Arrange
            var _game = new Game();

            //Act & Assert
            Assert.Throws<ArgumentException>(() => _game.Start("122"));
        }

        [Fact]
        public void Start_IncressOptionCodeLength_Pass()
        {
            //Arrange
            var _game = new Game();

            //Act & Assert
            _game.Start("1234", new() { CodeLength = 4 });
        }

        [Fact]
        public void Start_InvalidLength_ThrowException()
        {
            //Arrange
            var _game = new Game();

            //Act & Assert
            Assert.Throws<ArgumentException>(() => _game.Start("1234"));
        }

        [Fact]
        public void Start_OnStart_RaiseStartedEvent()
        {
            //Arrange
            var _game = new Game();
            var _raised = false;

            //Act
            _game.OnGameStarted += (s, e) => _raised = true;
            _game.Start("123");

            //Assert
            Assert.True(_raised);
        }

        [Fact]
        public void TryCode_AllInvalid_ReturnsXXX()
        {
            //Arrange
            var _game = new Game();

            //Act
            _game.Start("123");
            _game.TryCode("456");

            //Assert
            Assert.Equal("XXX", _game.Data.LastTryResult);
        }

        [Fact]
        public void TryCode_AllPartial_ReturnsIII()
        {
            //Arrange
            var _game = new Game();

            //Act
            _game.Start("123");
            _game.TryCode("312");

            //Assert
            Assert.Equal("???", _game.Data.LastTryResult);
        }

        [Fact]
        public void TryCode_AllValid_ReturnsOOO()
        {
            //Arrange
            var _game = new Game();

            //Act
            _game.Start("123");
            _game.TryCode("123");

            //Assert
            Assert.Equal("OOO", _game.Data.LastTryResult);
        }

        [Fact]
        public void TryCode_CorrectCode_WonGame()
        {
            //Arrange
            var _game = new Game();

            //Act
            _game.Start("123");
            _game.TryCode("123");

            //Assert
            Assert.True(_game.Data.Won);
            Assert.NotNull(_game.Data.Finished);
        }

        [Fact]
        public void TryCode_IncorrectCode_DontWonGame()
        {
            //Arrange
            var _game = new Game();

            //Act
            _game.Start("123");
            _game.TryCode("124");

            //Assert
            Assert.Null(_game.Data.Won);
            Assert.Null(_game.Data.Finished);
        }

        [Fact]
        public void TryCode_OneInvalid_ReturnsXOO()
        {
            //Arrange
            var _game = new Game();

            //Act
            _game.Start("123");
            _game.TryCode("423");

            //Assert
            Assert.Equal("XOO", _game.Data.LastTryResult);
        }

        [Fact]
        public void TryCode_OnePartial_ReturnsXXI()
        {
            //Arrange
            var _game = new Game();

            //Act
            _game.Start("123");
            _game.TryCode("345");

            //Assert
            Assert.Equal("?XX", _game.Data.LastTryResult);
        }

        [Fact]
        public void TryCode_OnTryCode_RaisesTriedEvent()
        {
            //Arrange
            var _game = new Game();
            var _raised = false;

            //Act
            _game.Start("123");
            _game.OnGameTried += (s, e) => _raised = true;
            _game.TryCode("123");

            //Assert
            Assert.True(_raised);
        }

        [Fact]
        public void TryCode_OnTryCorrectCode_RaisesFinishEvent()
        {
            //Arrange
            var _game = new Game();
            var _raised = false;

            //Act
            _game.Start("123");
            _game.OnGameFinished += (s, e) => _raised = true;
            _game.TryCode("123");

            //Assert
            Assert.True(_raised);
        }

        [Fact]
        public void TryCode_OptionLessTries_FailGame()
        {
            //Arrange
            var _game = new Game();

            //Act
            _game.Start("123", new Options { MaxTries = 1 });
            for (int i = 0; i < _game.Data.Options.MaxTries; i++)
            {
                _game.TryCode("124");
            }

            //Assert
            Assert.False(_game.Data.Won);
            Assert.NotNull(_game.Data.Finished);
        }

        [Fact]
        public void TryCode_OutOfTries_FailGame()
        {
            //Arrange
            var _game = new Game();

            //Act
            _game.Start("123");
            for (int i = 0; i < _game.Data.Options.MaxTries; i++)
            {
                _game.TryCode("124");
            }

            //Assert
            Assert.False(_game.Data.Won);
            Assert.NotNull(_game.Data.Finished);
        }

        #endregion Public Methods
    }
}