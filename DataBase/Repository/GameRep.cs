using OOP2.Accounts;
using OOP2.Games;
using OOP2.DataBase.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.DataBase.Repository
{
    public class GameRep : IGameRepository
    {
        private readonly DbContext dbContext;

        public GameRep(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void CreateGame(string gameType, GameAccount user1, GameAccount user2, int rating, bool result)
        {
            if (rating < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating can't be less than 1");
            }

            var user2Name = user2 == null ? "Bot" : user2.UserName;
            var game = GameFactory.CreateGame(gameType, user1.UserName, user2Name, rating, result);

            dbContext.Games.Add(game);

            if (result)
            {
                user1.WinGame(game);
                user2?.LoseGame(game);
            }
            else
            {
                user1.LoseGame(game);
                user2?.WinGame(game);
            }
        }

        public GameAccount ReadGameAccountByName(string username)
        {
            return dbContext.GameAccounts.Find(account => account.UserName == username);
        }
        public List<Game> ReadGames()
        {
            return dbContext.Games;
        }

        public Game GetGameById(int GameID)
        {
            return dbContext.Games.Find(game => game.GameId == GameID);

        }

        public void UpdateGame(Game game)
        {
            var index = dbContext.Games.IndexOf(game);
            dbContext.Games[index] = game;
        }
        public void DeleteGame(Game game)
        {
            dbContext.Games.Remove(game);

        }

        public void PrintGames()
        {
            Console.WriteLine("All games:");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("| ID\t| Player 1\t| Player 2\t| Result\t| Rating\t|");
            Console.WriteLine("--------------------------------------------------------------------------");

            foreach (var game in dbContext.Games)
            {
                Console.WriteLine($"| {game.GameId,-4}| {game.Name,-14}| {game.OpponentName,-14}| {(game.Outcome ? $"{game.Name} Win" : $"{game.OpponentName} Win"),-14}| {game.Rating,-14}|");
            }

            Console.WriteLine("--------------------------------------------------------------------------");
        }

        public void PrintGames(GameAccount gameAccount)
        {
            Console.WriteLine($"\nGames history of {gameAccount.UserName}");
            Console.WriteLine($"(Current rating: {gameAccount.CurrentRating})");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("| Player 1\t| Player 2\t| Result\t| Rating\t|");
            Console.WriteLine("--------------------------------------------------------------------------");

            foreach (int i in gameAccount.gameHistory)
            {
                var game = GetGameById(i);

                Console.WriteLine($"| {game.Name,-14}| {game.OpponentName,-14}| {(game.Outcome ? "Win" : "Lose"),-14}| {game.Rating,-14}|");
            }

            Console.WriteLine("--------------------------------------------------------------------------");
        }
    }
}
