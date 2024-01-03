using OOP2.Accounts;
using OOP2.DataBase.Repository;
using OOP2.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.DataBase.Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }
        public void CreateGame(string player, int rating, bool result)
        {
            var Player = gameRepository.ReadGameAccountByName(player);
            if (Player == null)
            {
                // Handle the case when the player account is not found
                Console.WriteLine($"Player account not found for: {player}");
                return;
            }
            gameRepository.CreateGame("bot", Player, null, rating, result);
        }

        public void CreateGame(string gameType, string player, string opponent, int rating, bool result)
        {
            if (player == opponent) throw new ArgumentException("You cannot play with yourself");

            if (gameType != "bot")
            {
                var user1 = gameRepository.ReadGameAccountByName(player);
                var user2 = gameRepository.ReadGameAccountByName(opponent);
                gameRepository.CreateGame(gameType, user1, user2, rating, result);
            }
            else
            {
                CreateGame(player, rating, result);
                CreateGame(opponent, rating, result);
            }
        }
        public GameAccount GetGameAccountByName(string userName)
        {
            return gameRepository.ReadGameAccountByName(userName);
        }
        public void PrintGames()
        {
            gameRepository.PrintGames();
        }
        public void PrintGames(GameAccount gameAccount)
        {
            gameRepository.PrintGames(gameAccount);
        }
        public void UpdateGames(Game game)
        {
            gameRepository.UpdateGame(game);
        }
        public void DeleteGame(Game game)
        {
            gameRepository.DeleteGame(game);
        }
    }
}
