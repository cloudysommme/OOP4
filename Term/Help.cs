using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.Term
{
    public class Help : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("\nAvailable Commands:");
            Console.WriteLine("1. players - Print players from the database");
            Console.WriteLine("2. add_player - Add a new player");
            Console.WriteLine("3. player_stats - Display statistics for a specific player");
            Console.WriteLine("4. play_game - Play a game");
            Console.WriteLine("5. help - Show available commands");
            Console.WriteLine("6. exit - Exit the program");
        }
    }
}
