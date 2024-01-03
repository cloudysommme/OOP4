using OOP2.Accounts;
using OOP2.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.DataBase.Repository
{
    public interface IGameRepository
    {
        void CreateGame(string gameType, GameAccount user1, GameAccount user2, int rating, bool result);
        List<Game> ReadGames();
        Game GetGameById(int gameID);
        void UpdateGame(Game game);
        void DeleteGame(Game game);
        void PrintGames();
        void PrintGames(GameAccount gameAccount);
        GameAccount ReadGameAccountByName(string username);
    }
}
