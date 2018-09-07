using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
