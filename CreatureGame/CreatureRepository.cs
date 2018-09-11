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
                    Console.WriteLine("Fight: \n" + input.ToUpper() + " vs " + cr.Name.ToUpper());
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
