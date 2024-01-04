using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2.Term
{
     public class Exit : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("Exiting the program. Goodbye!");
            Environment.Exit(0);
        }
    }
}
