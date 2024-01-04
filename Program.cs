using System;
using OOP2.Accounts;
using OOP2.DataBase.Repository;
using OOP2.DataBase.Service;
using OOP2.DataBase;
using OOP2.Term;

class Program
{
    static void Main()
    {
        DbContext dbContext = new DbContext();
        GameRep gameRepository = new GameRep(dbContext);
        GameAccRep gameAccountRepository = new GameAccRep(dbContext);
        GameAccountService gameAccountService = new GameAccountService(gameAccountRepository);
        GameService gameService = new GameService(gameRepository);

        Processor processor = new Processor(gameAccountService, gameService);

        try
        {
            while (true)
            {
                Console.Write("Enter a command: ");
                string inputCommand = Console.ReadLine();

                if (inputCommand.ToLower() == "exit")
                {
                    break;
                }

                processor.ProcessCommand(inputCommand);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
