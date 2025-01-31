using System.Text;

namespace Engine
{
    public class Game
    {
        #region Public Delegates

        public delegate void GameEvent<T>(Game obj, T args) where T : EventArgs;

        #endregion Public Delegates

        #region Public Events

        public event GameEvent<EventArgs>? OnGameFinished;

        public event GameEvent<EventArgs>? OnGameStarted;

        public event GameEvent<LastTryResultEventArg>? OnGameTried;

        #endregion Public Events

        #region Public Properties

        public GameData Data { private set; get; } = new(string.Empty);

        #endregion Public Properties

        #region Public Methods

        public void Start(string secretCode, Options? options = null)
        {
            Data = new(secretCode, options);
            CheckEntry(secretCode);
            OnGameStarted?.Invoke(this, EventArgs.Empty);
        }

        public void TryCode(string currentTry)
        {
            CheckEntry(currentTry);
            Data.LastTry = currentTry;
            if (Data.LastTry.Equals(Data.SecrectCode))
                FinishGame(true);

            Data.LastTryResult = CalculateLastTry(Data.LastTry);
            OnGameTried?.Invoke(this, new(Data.LastTryResult));

            Data.LastTry = currentTry;
            Data.CurrentTurn++;
            if (Data.CurrentTurn > Data.Options.MaxTries)
                FinishGame(false);
        }

        #endregion Public Methods

        #region Private Methods

        private string CalculateLastTry(string lastTry)
        {
            var _result = new StringBuilder();

            for (var i = 0; lastTry.Length > i; i++)
            {
                if (lastTry[i] == Data.SecrectCode[i])
                {
                    _result.Append("O");
                    continue;
                }
                else
                {
                    if (Data.SecrectCode.Contains(lastTry[i]))
                    {
                        _result.Append("?");
                        continue;
                    }
                }

                _result.Append("X");
            }

            return _result.ToString();
        }

        private void CheckEntry(string entry)
        {
            CheckEntryDigitsAreUnique(entry);
            CheckEntryLength(entry);
        }

        private void CheckEntryDigitsAreUnique(string entry)
        {
            if (entry.GroupBy(c => c).Any(g => g.Count() > 1))
                throw new ArgumentException("The entry must contain unique characters");
        }

        private void CheckEntryLength(string entry)
        {
            if (entry.Length != Data.Options.CodeLength)
                throw new ArgumentException(
                        $"The entry must be equal to the code lenght option ({Data.Options.CodeLength})");
        }

        private void FinishGame(bool won)
        {
            Data.Won = won;
            Data.Finished = DateTime.UtcNow;
            OnGameFinished?.Invoke(this, EventArgs.Empty);
        }

        #endregion Private Methods
    }

    public class LastTryResultEventArg : EventArgs
    {
        #region Public Constructors

        public LastTryResultEventArg(string result) => Result = result;

        #endregion Public Constructors

        #region Public Properties

        public string Result { init; get; }

        #endregion Public Properties
    }

    public record GameData
    {
        public string SecrectCode { init; get; }
        public string LastTry { set; get; } = string.Empty;
        public string LastTryResult { set; get; } = string.Empty;
        public ushort CurrentTurn { set; get; } = 1;
        public DateTime? Finished { set; get; } = null;
        public Options Options { init; get; }
        public DateTime Started { init; get; } = DateTime.UtcNow;
        public bool? Won { set; get; } = null;

        public GameData(string secretCode, Options? options = null)
        {
            SecrectCode = secretCode;
            Options = options ?? new();
        }
    }

    public record Options
    {
        public uint CodeLength { init; get; } = 3;
        public ushort MaxTries { init; get; } = 9;
    }
}