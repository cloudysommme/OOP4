using OOP2.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.DataBase.Service
{
    public interface IGameAccountService
    {
        void CreateGameAccount(string gameType, string userName, int initialRating);
        List<GameAccount> GetGameAccounts();

    }
}
