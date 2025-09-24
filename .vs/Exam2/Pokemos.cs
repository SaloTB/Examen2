using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    internal class Pokemos
    {

        namespace Exam2
    {
        public class Pokemon
        {
            public string Name { get; }
            public int Level { get; }
            public int Attack { get; }
            public int Defense { get; }
            public int SpAttack { get; }
            public int SpDefense { get; }
            public List<string> Moves { get; }

            public Pokemon(string name, int level = 1, int atk = 10, int def = 10, int spAtk = 10, int spDef = 10)
            {
                Name = name;
                Level = level;
                Attack = atk;
                Defense = def;
                SpAttack = spAtk;
                SpDefense = spDef;
                Moves = new List<string>();
            }
        }

        public class Pikachu : Pokemon
        {
            public Pikachu() : base("Pikachu", 1, 10, 10, 15, 10) { }
        }
    }

}
}
