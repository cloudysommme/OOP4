using System;
using System.Collections.Generic;
using OOP2.Games;

namespace OOP2.Accounts
{
    public abstract class GameAccount
    {
        public string UserName { get; set; }
        private int currentRating = 1;
        public int CurrentRating
        {
            get { return currentRating; }
            set
            {
                if (value < 1)
                {
                    currentRating = 1;
                }
                else { currentRating = value; }
            }
        }
        public List<int> gameHistory = new();

        public GameAccount(string userName, int initialRating = 100)
        {
            UserName = userName;
            CurrentRating = initialRating;
        }


        protected virtual void GameRating(bool result, int rating)
        {
            if (result)
            {
                CurrentRating += rating;
            }
            else
            {
                CurrentRating -= rating;
            }
        }
        public void WinGame(Game game)
        {
            GameRating(true, game.Rating);
            gameHistory.Add(game.GameId);
        }

        public void LoseGame(Game game)
        {
            GameRating(false, game.Rating);
            gameHistory.Add(game.GameId);
        }
        public string AccountType { get; set; }


    }
}
