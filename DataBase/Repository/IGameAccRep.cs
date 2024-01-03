using OOP2.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.DataBase.Repository
{
    public interface IGameAccountRepository
    {
        void CreateGameAccount(string accountType, string username, int initialRating);
        List<GameAccount> ReadGameAccounts();

        void UpdateGameAccount(GameAccount gameAccount);
        void DeleteGameAccount(GameAccount gameAccount);
    }
}
