using OOP2.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    class GameAccountFactory
    {
        public static GameAccount CreateGameAccount(string accountType, string username, int initialRating)
        {
            return accountType.ToLower() switch
            {
                "standart" => new StandartAccount(username, initialRating),
                "premium" => new PremiumAccount(username, initialRating),
                "winstreak" => new WinStreakAccount(username, initialRating),
                _ => throw new ArgumentException($"Account type doesn't exist - {accountType}"),
            };
        }
    }
}
