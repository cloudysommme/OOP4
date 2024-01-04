using OOP2.DataBase.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.Term
{
    public class PlayGame : ICommand
    {
        private readonly IGameService gameService;

        public PlayGame(IGameService gameService)
        {
            this.gameService = gameService;
        }

        public void Execute()
        {
            Console.Write("Enter the name of Player 1: ");
            string player1 = Console.ReadLine();

            Console.Write("Enter the name of Player 2 (or leave blank for BOT): ");
            string player2 = Console.ReadLine();

            Console.Write("Enter the game type (standart/training/bot): ");
            string gameType = Console.ReadLine().Trim().ToLower();
            Console.Write("Enter the rating: ");
            int rating;
            while (!int.TryParse(Console.ReadLine(), out rating))
            {
                Console.WriteLine("Invalid rating. Please enter a valid integer.");
            }

            if (string.IsNullOrWhiteSpace(player2))
            {
                gameService.CreateGame(player1, rating, true);
                Console.WriteLine($"Game played between {player1} and BOT with rating {rating}. Result: {player1} wins.");
            }
            else
            {

                gameService.CreateGame(gameType, player1, player2, rating, true);
                Console.WriteLine($"Game played between {player1} and {player2} with rating {rating}. Result: {player1} wins.");
            }
        }
    }
}
