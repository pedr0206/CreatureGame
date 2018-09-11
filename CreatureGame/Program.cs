using System;
using System.Threading;

namespace CreatureGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            CreatureRepository repository = new CreatureRepository();
            Console.WriteLine("Welcome to Creatures Game program\n == Version 0.1 ==");
            repository.Run();   
        }
    }
}
