using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureGame
{
    public class Creature
    {
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public enum enumFraction { Devotion, Spawn }
        public enumFraction group;
        public Creature(enumFraction fraction)
        {
            group = fraction;
        }
        public Creature()
        {

        }
    }
}
