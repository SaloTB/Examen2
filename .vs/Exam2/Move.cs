using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    public class Move
    {
        public string Name { get; set; }
        public int BasePower { get; set; }
        public int Speed { get; set; }
        public PokemonType Type { get; set; }
        public MoveType MoveType { get; set; }

        public Move(string name, int basePower, int speed, PokemonType type, MoveType moveType)
        {
            Name = name;
            BasePower = basePower;
            Speed = speed;
            Type = type;
            MoveType = moveType;
        }
    }
}
