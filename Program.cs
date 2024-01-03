using System;
using OOP2.Accounts;
using OOP2.DataBase.Repository;
using OOP2.DataBase.Service;
using OOP2.DataBase;
class Program
{
    static void Main()
    {
        DbContext dbContext = new DbContext();
        GameRep gameRepository = new GameRep(dbContext);
        GameAccRep gameAccountRepository = new GameAccRep(dbContext);
        GameAccountService gameAccountService = new GameAccountService(gameAccountRepository);
        GameService gameService = new GameService(gameRepository);

        gameAccountService.CreateGameAccount("standart", "Bobik", 200);
        gameAccountService.CreateGameAccount("standart", "Lyolik", 100);
        gameAccountService.CreateGameAccount("winstreak", "Kebab", 300);
        gameAccountService.CreateGameAccount("premium", "Nazik", 100);

        gameService.CreateGame("standart", "Bobik", "Lyolik", 20, false);

        gameService.CreateGame("standart", "Bobik", "Lyolik", 20, false);
        gameService.CreateGame("training", "Bobik", "Nazik", 50, true);
        gameService.CreateGame("standart", "Bobik", "Kebab", 30, true);

        gameService.CreateGame("Lyolik", 70, true);
        gameService.CreateGame("standart", "Lyolik", "Nazik", 23, false);

        gameService.CreateGame("standart", "Kebab", "Lyolik", 15, true);
        gameService.CreateGame("training", "Kebab", "Bobik", 20, false);
        gameService.CreateGame("standart", "Kebab", "Nazik", 20, true);

        gameService.CreateGame("standart", "Nazik", "Kebab", 80, false);
        gameService.CreateGame("standart", "Nazik", "Bobik", 80, true);




       

        gameService.PrintGames();

        var bobikAccount = gameRepository.ReadGameAccountByName("Bobik");
        var lyolikAccount = gameRepository.ReadGameAccountByName("Lyolik");
        var kebabAccount = gameRepository.ReadGameAccountByName("Kebab");
        var nazikAccount = gameRepository.ReadGameAccountByName("Nazik");

        gameService.PrintGames(bobikAccount);
        gameService.PrintGames(lyolikAccount);
        gameService.PrintGames(kebabAccount);
        gameService.PrintGames(nazikAccount);
    }
}
