using OOP2.DataBase.Service;
using OOP2.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.Term
{
    public class PrintPlayers : ICommand
    {
        private readonly IGameAccountService gameAccountService;

        public PrintPlayers(IGameAccountService gameAccountService)
        {
            this.gameAccountService = gameAccountService;
        }

        public void Execute()
        {
            var players = gameAccountService.GetGameAccounts();
            Console.WriteLine("List of Players:");
            foreach (var player in players)
            {
                Console.WriteLine($"- {player.UserName}({player.CurrentRating})");
            }
        }
    }
}
