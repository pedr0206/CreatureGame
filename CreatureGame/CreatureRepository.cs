using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using static CreatureGame.Creature;

namespace CreatureGame
{
    public class CreatureRepository
    {
        public List<Creature> creatures = new List<Creature>();


        public void CreateCreatureRepository()
        {
            var filePath = @"C:\Users\Bruger\Desktop\GameInput.txt";
            List<string> lines = File.ReadAllLines(filePath).ToList();

            foreach (var line in lines)
            {
                string[] entries = line.Split('|');
                if (entries[3] == "Devotion")
                {
                    Creature newCreature = new Creature(enumFraction.Devotion);
                    newCreature.Name = entries[0];
                    newCreature.Attack = Convert.ToInt32(entries[1]);
                    newCreature.Defense = Convert.ToInt32(entries[2]);
                    creatures.Add(newCreature);
                }
                else
                {
                    Creature newCreature = new Creature(enumFraction.Spawn);
                    newCreature.Name = entries[0];
                    newCreature.Attack = Convert.ToInt32(entries[1]);
                    newCreature.Defense = Convert.ToInt32(entries[2]);
                    creatures.Add(newCreature);
                }
            }
        }
        public void Run()
        {
            bool exit = false;
            CreateCreatureRepository();
            while (exit == false)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Currtent creatures: \n");
                foreach (var creature in creatures)
                {
                    Thread.Sleep(250);
                    Console.WriteLine(" NAME -      ATTACK - DEFENSE -    FRACTION ");
                    Console.WriteLine($" { creature.Name }      { creature.Attack }         { creature.Defense }        { creature.group } \n");
                }
                Thread.Sleep(1000);
                Console.WriteLine("Choose a creature and type its name: ");
                string input = Console.ReadLine().ToLower();
                Creature choosenCreature = new Creature();

                foreach (var creature in creatures)
                {
                    if (input == creature.Name.ToLower())
                    {
                        choosenCreature = creature;
                        Console.WriteLine("You have choosen: " + choosenCreature.Name.ToUpper());
                    }
                }
                PickRandomCreature(choosenCreature, input);
                Console.WriteLine("Do you want to repeat the game? \n\n press Y to repeat, N to exit \n\n Type ADD to add a creature");
                var userInput = Console.ReadLine().ToLower();
                if (userInput == "y")
                {
                    exit = false;
                }
                //else if(userInput == "add")
                //{
                //    AddCreatrure();
                //}
                else
                {
                    exit = true;
                }
            }
        }

        public void PickRandomCreature(Creature choosenCreature, string input)
        {
            bool worngGroup = true;
            Thread.Sleep(1000);


            while (worngGroup)
            {
                Random random = new Random();
                var index = random.Next(creatures.Count);
                Creature cr = creatures[index];
                if (cr.group != choosenCreature.group)
                {
                    Console.WriteLine("Fight: \n\n\n" + input.ToUpper() + " vs " + cr.Name.ToUpper() + "\n");
                    Thread.Sleep(1000);
                    if ((cr.Attack + cr.Defense) > (choosenCreature.Attack + choosenCreature.Defense))
                    {
                        Console.WriteLine("\n ======== " + cr.Name + " is the winner!!! ======== \n");
                    }
                    else if ((cr.Attack + cr.Defense) == (choosenCreature.Attack + choosenCreature.Defense))
                    {
                        Console.WriteLine("======== It's a fucking draw! :/ ========");
                    }
                    else if ((cr.Attack + cr.Defense) < (choosenCreature.Attack + choosenCreature.Defense))
                    {
                        Console.WriteLine("======== " + choosenCreature.Name + " is the winner!!! ========");
                    }
                    worngGroup = false;
                }
                else if (cr.group == choosenCreature.group)
                {
                    worngGroup = true;
                }
            }
        }
        //public void AddCreatrure()
        //{
        //    Console.WriteLine("Please insert a charactere name \n");
        //    string inputName = Console.ReadLine().ToLower();
        //    Console.WriteLine("Please insert a charactere Attack level \n");
        //    int inputAttackLevel = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Please insert a charactere Defense Level \n");
        //    int inputDefenseLevel = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("Please insert a charactere Fraction (DEVOTION or SPAWN) \n");
        //    string inputGroup = Console.ReadLine().ToLower();

        //    foreach (var character in creatures)
        //    {
        //        if (inputName == character.Name.ToLower())
        //        {
        //            Console.WriteLine("Character already exists. Please insert other name.");
        //        }
        //        else if (inputName != character.Name && inputGroup == "Devotion")
        //        {
        //            Creature newCreature = new Creature(enumFraction.Devotion);
        //            newCreature.Name = inputName;
        //            newCreature.Attack = Convert.ToInt32(inputAttackLevel);
        //            newCreature.Defense = Convert.ToInt32(inputDefenseLevel);
        //            creatures.Add(newCreature);
        //            Console.WriteLine("Creature of fraction -Devotion- added successfully");
        //        }
        //        else if(inputName != character.Name && inputGroup == "Spawn")
        //        {
        //            Creature newCreature = new Creature(enumFraction.Spawn);
        //            newCreature.Name = inputName;
        //            newCreature.Attack = Convert.ToInt32(inputAttackLevel);
        //            newCreature.Defense = Convert.ToInt32(inputDefenseLevel);
        //            creatures.Add(newCreature);
        //            Console.WriteLine("Creature of fraction -Spawn- added successfully");
        //        }

        //    }
        }

        //public void CreatNewCreature(string name, int attack, int defense/*enumFraction*/)
        //{
        //    Creature newCreature = new Creature();
        //    newCreature.Name = name;
        //    newCreature.Attack = attack;
        //    newCreature.Defense = defense;
        //    creatures.Add(newCreature);
        //}
    }
}
