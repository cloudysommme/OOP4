using OOP2.DataBase.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.Term
{
    public class Processor
    {
        private readonly Dictionary<string, ICommand> commands;
        private readonly IGameAccountService gameAccountService;
        private readonly IGameService gameService;
        public Processor(IGameAccountService gameAccountService, IGameService gameService)
        {
            this.gameAccountService = gameAccountService;

            commands = new Dictionary<string, ICommand>
        {
            { "players", new PrintPlayers(gameAccountService) },
            { "add_player", new AddPlayer(gameAccountService) },
            { "player_stats", new PlayerStats(gameService) },
            { "play_game", new PlayGame(gameService) },
            { "help", new Help() },
            { "exit", new Exit() }
        };
            this.gameService = gameService;
        }

        public void ProcessCommand(string command)
        {
            if (commands.TryGetValue(command, out var commandObject))
            {
                commandObject.Execute();
            }
            else
            {
                Console.WriteLine("Invalid command. Enter 'help' for a list of available commands.");
            }
        }
    }

}
