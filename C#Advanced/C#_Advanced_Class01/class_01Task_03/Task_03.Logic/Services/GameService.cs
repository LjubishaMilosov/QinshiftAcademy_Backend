using Task03.Logic.Enums;

namespace Task03.Logic.Services
{
    public class GameService
    {
        private int _userWins;
        private int _computerWins;
        private int _gamesPlayed;

        private static readonly Random _random = new Random();

        public (Choice userChoice, Choice computerChoice, string result) PlayRound(Choice userChoice)
        {
            var computerChoice = (Choice)_random.Next(1, 4); // Randomly pick Rock, Paper, or Scissors
            _gamesPlayed++;

            string result;
            if (userChoice == computerChoice)
            {
                result = "It's a tie!";
            }
            else if ((userChoice == Choice.Rock && computerChoice == Choice.Scissors) ||
                     (userChoice == Choice.Paper && computerChoice == Choice.Rock) ||
                     (userChoice == Choice.Scissors && computerChoice == Choice.Paper))
            {
                _userWins++;
                result = "You win!";
            }
            else
            {
                _computerWins++;
                result = "Computer wins!";
            }

            return (userChoice, computerChoice, result);
        }

        public (int userWins, int computerWins, int gamesPlayed, double userWinPercentage) GetStats()
        {
            double userWinPercentage = _gamesPlayed > 0 ? ((double)_userWins / _gamesPlayed) * 100 : 0;
            return (_userWins, _computerWins, _gamesPlayed, userWinPercentage);
        }
    }
}