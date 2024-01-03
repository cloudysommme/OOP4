using OOP2.Accounts;
using OOP2.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.DataBase.Service
{
    public interface IGameService
    {
        void CreateGame(string player, int rating, bool result);
        void CreateGame(string gameType, string player, string opponent, int rating, bool result);
        void UpdateGames(Game game);
        void DeleteGame(Game game);
        GameAccount GetGameAccountByName(string userName);

    }
}
