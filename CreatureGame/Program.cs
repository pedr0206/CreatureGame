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
            repository.CreateCreatureRepository();
            Thread.Sleep(1000);

            Console.WriteLine("Currtent creatures: \n");
            foreach (var creature in repository.creatures)
            {
                Thread.Sleep(500);
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
                    Console.WriteLine("You have choosen: " + choosenCreature.Name);
                }
            }
            Thread.Sleep(1000);
            Random random = new Random();
            var index = random.Next(repository.creatures.Count);
            Creature cr = repository.creatures[index];
            if (cr.group != choosenCreature.group)
            {
                Console.WriteLine("Fight: \n" + input.ToUpper() + " vs " + cr.Name.ToUpper());
                Thread.Sleep(1000);
                if ((cr.Attack + cr.Defense) > (choosenCreature.Attack + choosenCreature.Defense))
                {
                    Console.WriteLine("======== " + cr.Name + " is the winner!!! ========");
                }
                else if ((cr.Attack + cr.Defense) == (choosenCreature.Attack + choosenCreature.Defense))
                {
                    Console.WriteLine("======== It's a fucking draw! :/ ========");
                }
                else if ((cr.Attack + cr.Defense) < (choosenCreature.Attack + choosenCreature.Defense))
                {
                    Console.WriteLine("======== " + choosenCreature.Name + " is the winner!!! ========");
                }
            }
            Console.ReadLine();
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
