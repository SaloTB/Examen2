using Exam2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class DamageCalculator
{
    // Matriz de modificadores según la tabla de tipos (simplificada pero extendida)
    private static readonly Dictionary<(PokemonType, PokemonType), double> typeChart =
        new Dictionary<(PokemonType, PokemonType), double>
        {
            // Agua
            { (PokemonType.Water, PokemonType.Fire), 2.0 },
            { (PokemonType.Water, PokemonType.Ground), 2.0 },
            { (PokemonType.Water, PokemonType.Rock), 2.0 },
            { (PokemonType.Water, PokemonType.Water), 0.5 },
            { (PokemonType.Water, PokemonType.Grass), 0.5 },

            // Fuego
            { (PokemonType.Fire, PokemonType.Grass), 2.0 },
            { (PokemonType.Fire, PokemonType.Bug), 2.0 },
            { (PokemonType.Fire, PokemonType.Water), 0.5 },
            { (PokemonType.Fire, PokemonType.Rock), 0.5 },
            { (PokemonType.Fire, PokemonType.Fire), 0.5 },

            // Planta
            { (PokemonType.Grass, PokemonType.Water), 2.0 },
            { (PokemonType.Grass, PokemonType.Ground), 2.0 },
            { (PokemonType.Grass, PokemonType.Rock), 2.0 },
            { (PokemonType.Grass, PokemonType.Fire), 0.5 },
            { (PokemonType.Grass, PokemonType.Grass), 0.5 },
            { (PokemonType.Grass, PokemonType.Poison), 0.5 },
            { (PokemonType.Grass, PokemonType.Bug), 0.5 },
            

            // Eléctrico
            { (PokemonType.Electric, PokemonType.Water), 2.0 },
            { (PokemonType.Electric, PokemonType.Electric), 0.5 },
            { (PokemonType.Electric, PokemonType.Grass), 0.5 },
            { (PokemonType.Electric, PokemonType.Ground), 0.0 }, // inmunidad

            // Tierra
            { (PokemonType.Ground, PokemonType.Fire), 2.0 },
            { (PokemonType.Ground, PokemonType.Electric), 2.0 },
            { (PokemonType.Ground, PokemonType.Poison), 2.0 },
            { (PokemonType.Ground, PokemonType.Rock), 2.0 },
            { (PokemonType.Ground, PokemonType.Grass), 0.5 },
            { (PokemonType.Ground, PokemonType.Bug), 0.5 },

            // Roca
            { (PokemonType.Rock, PokemonType.Fire), 2.0 },
            { (PokemonType.Rock, PokemonType.Bug), 2.0 },


            // Normal
            { (PokemonType.Normal, PokemonType.Rock), 0.5 },
            { (PokemonType.Normal, PokemonType.Ghost), 0.0 }, // inmunidad

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
                mod *= 1.0; // neutro por defecto
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

