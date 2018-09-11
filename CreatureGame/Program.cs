using System;
using System.Threading;

namespace CreatureGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                CreatureRepository repository = new CreatureRepository();
                Console.WriteLine("Welcome to Creatures Game program\n == Version 0.1 ==");
                repository.CreateCreatureRepository();
                Thread.Sleep(1000);

                Console.WriteLine("Currtent creatures: \n");
                foreach (var creature in repository.creatures)
                {
                    Thread.Sleep(250);
                    Console.WriteLine(" NAME -      ATTACK - DEFENSE -    FRACTION ");
                    Console.WriteLine($" { creature.Name }      { creature.Attack }         { creature.Defense }        { creature.group } \n");
                }
                Thread.Sleep(1000);
                Console.WriteLine("Choose a creature and type its name: ");
                string input = Console.ReadLine().ToLower();
                Creature choosenCreature = new Creature();

                foreach (var creature in repository.creatures)
                {
                    if (input == creature.Name.ToLower())
                    {
                        choosenCreature = creature;
                        Console.WriteLine("You have choosen: " + choosenCreature.Name.ToUpper());
                    }
                }
                repository.PickRandomCreature(choosenCreature, input);
                Console.WriteLine("Do you want to repeat the game? \n\n press Y to repeat or N to exit ");
                var userInput = Console.ReadLine().ToLower();
                if (userInput == "y")
                {
                    exit = false;
                }
                else
                {
                    exit = true;
                }
                //Console.ReadLine();
            }

            //Console.WriteLine("Please insert a charactere name \n");
            //string inputName = Console.ReadLine().ToLower();
            //Console.WriteLine("Please insert a charactere Attack level \n");
            //int inputAttackLevel = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Please insert a charactere Defense Level \n");
            //int inputDefenseLevel = Convert.ToInt32(Console.ReadLine());
            ////Console.WriteLine("Please insert a charactere Fraction \n");
            ////string inputGroup = Console.ReadLine().ToLower();

            //foreach (var character in repository.creatures)
            //{
            //    if (inputName == character.Name.ToLower())
            //    {
            //        Console.WriteLine("Character already exists. Please insert other name.");
            //    }
            //    else if (inputName != character.Name)
            //    {
            //        repository.CreatNewCreature(inputName, inputAttackLevel, inputDefenseLevel);
            //    }
            //}        
        }
    }
}
