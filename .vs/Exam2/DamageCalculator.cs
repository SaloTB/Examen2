using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    public static class DamageCalculator
    {
        // Matriz de modificadores según la tabla de tipos (simplificada, se puede extender)
        private static readonly Dictionary<(PokemonType, PokemonType), double> typeChart =
            new Dictionary<(PokemonType, PokemonType), double>
            {
                { (PokemonType.Water, PokemonType.Fire), 2.0 },
                { (PokemonType.Water, PokemonType.Ground), 2.0 },
                { (PokemonType.Water, PokemonType.Rock), 2.0 },
                { (PokemonType.Electric, PokemonType.Water), 2.0 },
                { (PokemonType.Electric, PokemonType.Ground), 0.0 },
                { (PokemonType.Fire, PokemonType.Grass), 2.0 },
                { (PokemonType.Grass, PokemonType.Water), 2.0 },
                // Por defecto cualquier otra combinación es 1x
            };

        // Devuelve el modificador de daño para un movimiento contra una lista de tipos.

        public static double GetModifier(PokemonType moveType, List<PokemonType> defenderTypes)
        {
            double mod = 1.0;
            foreach (var defType in defenderTypes)
            {
                if (typeChart.TryGetValue((moveType, defType), out double factor))
                    mod *= factor;
                else
                    mod *= 1.0; // Si no está en la tabla, se considera neutro
            }
            return mod;
        }


        // Calcula el daño de un ataque según la fórmula de Pokémon.

        public static int CalculateDamage(Pokemon attacker, Pokemon defender, Move move, double mod)
        {
            int atk = move.MoveType == MoveType.Physical ? attacker.Attack : attacker.SpAttack;
            int def = move.MoveType == MoveType.Physical ? defender.Defense : defender.SpDefense;

            double dmg = (((2 * attacker.Level / 5.0 + 2) * move.BasePower * atk / def) / 50 + 2) * mod;

            return (int)Math.Floor(dmg);
        }
    }
}
