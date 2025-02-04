using ConsoleUI;

using Engine;

using System.Text;

int minWidth = 120;
int minHeight = 30;

Console.SetWindowSize(minWidth, minHeight);

Console.WriteLine(Strings.Title);
Console.WriteLine();

Game _game = new();
Options _options = new();

while (true)
{
    Console.WriteLine(Strings.Instructions, _options.CodeLength);
    while (true)
    {
        Console.Write(Strings.SecretCode);
        var secrectCode = ReadLineMasked();

        if (string.IsNullOrEmpty(secrectCode))
            secrectCode = GenerateRandomNumber(_options.CodeLength);

        if (!ValidateIsNumber(secrectCode))
            continue;

        if (SecretFeature.CheckSecretFeature(secrectCode))
            SecretFeature.ShowSecretFeature();

        try
        {
            _game.Start(secrectCode, _options);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }

        while (true)
        {
            Console.Write(Strings.EnterTry, _game.Data.CurrentTurn, _game.Data.Options.MaxTries);
            var currentTry = Console.ReadLine();
            if (!ValidateIsNumber(currentTry))
                continue;

            string result = string.Empty;
            try
            {
                _game.TryCode(currentTry);
                if (_game.Data.Won.HasValue)
                {
                    Console.WriteLine(_game.Data.Won.Value ? Strings.WinMessage : Strings.LoseMessage);
                    Console.Write(Strings.NewGame);
                    if (Console.ReadKey(true).Key != ConsoleKey.Y)
                        Environment.Exit(0);
                    Console.Clear();
                    break;
                }
                Console.WriteLine(Strings.AttemptResult, _game.Data.LastTryResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

static string GenerateRandomNumber(uint codeLength)
{
    string result = string.Empty;

    for (int i = 0; i < codeLength; i++)
    {
        int digit = 0;
        while (true)
        {
            digit = Random.Shared.Next(48, 57);
            if (result.Contains(Convert.ToChar(digit)))
                continue;
            break;
        }
        result += Convert.ToChar(digit);
    }

    return result;
}

static string ReadLineMasked()
{
    var input = new StringBuilder();
    while (true)
    {
        var key = Console.ReadKey(true);
        if (key.Key == ConsoleKey.Enter)
        {
            Console.WriteLine();
            break;
        };

        if (key.Key == ConsoleKey.Backspace && input.Length > 0)
        {
            input.Length--;
            Console.Write("\b \b");
        }
        else if (!char.IsControl(key.KeyChar))
        {
            input.Append(key.KeyChar);
            Console.Write('*');
        }
    }
    return input.ToString();
}

static bool ValidateIsNumber(string? secrectCode)
{
    if (string.IsNullOrEmpty(secrectCode) || secrectCode.Any(c => c < 48 || c > 57))
    {
        Console.WriteLine(Strings.MustBeNumber);
        return false;
    }
    return true;
}