using OOP2.Accounts;
using OOP2.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.DataBase.Service
{
    public class GameAccountService : IGameAccountService
    {
        private readonly IGameAccountRepository gameAccountRepository;

        public GameAccountService(IGameAccountRepository gameAccountRepository)
        {

            this.gameAccountRepository = gameAccountRepository;
        }

        public void CreateGameAccount(string accountType, string username, int initialRating)
        {
            gameAccountRepository.CreateGameAccount(accountType, username, initialRating);
        }

        public List<GameAccount> GetGameAccounts()
        {
            return gameAccountRepository.ReadGameAccounts();
        }

    }
}
