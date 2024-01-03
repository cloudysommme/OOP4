using OOP2.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.DataBase.Repository
{
    public class GameAccRep : IGameAccountRepository
    {
        private readonly DbContext dbContext;

        public GameAccRep(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateGameAccount(string accountType, string username, int initialRating)
        {
            dbContext.GameAccounts.Add(GameAccountFactory.CreateGameAccount(accountType, username, initialRating));
        }

        public List<GameAccount> ReadGameAccounts()
        {
            return dbContext.GameAccounts;
        }

        public void UpdateGameAccount(GameAccount gameAccount)
        {
            throw new NotImplementedException();
        }

        public void DeleteGameAccount(GameAccount gameAccount)
        {
            dbContext.GameAccounts.Remove(gameAccount);
        }
    }
}
