# C# Master Mind Game

## Table of Contents
- [Introduction](#introduction)
- [Recommendations](#recomendations)
- [Prerequisites](#prerequisites)
- [Building the Application](#building-the-application)
- [Running the Application](#running-the-application)
- [Testing the Application](#testing-the-application)
- [License](#license)
- [Author](#author)

## Introduction
This project is a console application that simulates the Master Mind game. 
The game is played between two players: the code maker and the code breaker. 
The code maker creates a secret code, and the code breaker tries to guess the code. 
The code breaker has a limited number of attempts to guess the code. 
After each guess, the code maker provides feedback to the code breaker. 
The feedback consists of 3 outputs: 
- ? if the number is correct but in the wrong possition.
- O if the number is correct and in the correct possition.
- X if the number is incorrect.
The code breaker uses this feedback to make better guesses. 
The game ends when the code breaker guesses the code or runs out of attempts.

## Recommendations
- Try to conceptualize how would you implement the game before looking at the code.
- Try to implement the game on your own before looking at the code.
- Use the code as a reference if you get stuck or need help.
- Experiment with the code and try to make improvements or add new features.
- There is a secrect message hidden in the code. Can you find it? (there is a hint from the rising sun culture)
- Have fun!

## Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- Any text editor or IDE (e.g., Visual Studio Code, Visual Studio)

## Building the Application
To build the application, navigate to the project directory and use the following command:
```bash
dotnet build
```

## Running the Application
To run the application, use the following command:
```bash
dotnet run
```

## Testing the Application
To test the application, navigate to the test project directory (if you have a separate test project) and use the following command:
```bash
dotnet test
```

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.

## Author
Miguel Velasquez  
[GitHub Profile](https://github.com/mvelasquez10)