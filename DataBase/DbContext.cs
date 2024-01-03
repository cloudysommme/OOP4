using OOP2.Accounts;
using OOP2.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.DataBase
{
    public class DbContext
    {
        public List<GameAccount> GameAccounts { get; set; }
        public List<Game> Games { get; set; }

        public DbContext()
        {
            GameAccounts = new();
            Games = new();
        }
    }
}
