using OOP2.DataBase.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.Term
{
    public class AddPlayer : ICommand
    {
        private readonly IGameAccountService gameAccountService;

        public AddPlayer(IGameAccountService gameAccountService)
        {
            this.gameAccountService = gameAccountService;
        }

        public void Execute()
        {
            Console.Write("Enter the name of the player: ");
            string playerName = Console.ReadLine();

            Console.Write("Enter the account type (standart/premium/winstreak): ");
            string accountType = Console.ReadLine();

            Console.Write("Enter the initial rating: ");
            int initialRating;
            while (!int.TryParse(Console.ReadLine(), out initialRating))
            {
                Console.WriteLine("Invalid rating. Please enter a valid integer.");
            }

            gameAccountService.CreateGameAccount(accountType, playerName, initialRating);
            Console.WriteLine($"Player {playerName} added successfully.");
        }
    }
}
