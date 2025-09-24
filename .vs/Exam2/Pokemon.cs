using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace Exam2
{
    public class Pokemon
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDefense { get; set; }
        public List<PokemonType> Types { get; set; }
        public List<Move> Moves { get; set; }

        public Pokemon(
            string name,
            int level = 1,
            int atk = 10,
            int def = 10,
            int spAtk = 10,
            int spDef = 10,
            PokemonType type1 = PokemonType.Normal,
            PokemonType? type2 = null)
        {
            Name = name;
            Level = level;
            Attack = atk;
            Defense = def;
            SpAttack = spAtk;
            SpDefense = spDef;
            Types = new List<PokemonType> { type1 };
            if (type2.HasValue) Types.Add(type2.Value);
            Moves = new List<Move>();
        }
    }
    
        public class Pikachu : Pokemon
        {
            public Pikachu()
                : base("Pikachu", 1, 10, 10, 15, 10, PokemonType.Electric) { }
        }

        public class Charmander : Pokemon
        {
            public Charmander()
                : base("Charmander", 1, 12, 10, 14, 10, PokemonType.Fire) { }
        }

        public class Squirtle : Pokemon
        {
            public Squirtle()
                : base("Squirtle", 1, 9, 12, 10, 14, PokemonType.Water) { }
        }

        public class Bulbasaur : Pokemon
        {
            public Bulbasaur()
                : base("Bulbasaur", 1, 11, 11, 12, 12, PokemonType.Grass, PokemonType.Poison) { }
        }

        public class Geodude : Pokemon
        {
            public Geodude()
                : base("Geodude", 1, 14, 15, 7, 7, PokemonType.Rock, PokemonType.Ground) { }
        }
    

}







