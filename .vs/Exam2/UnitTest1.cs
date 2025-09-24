namespace Exam2
{
    public class Tests
    {
        [Test]
        public void Pokemon_DefaultValues_ShouldInitializeCorrectly()
        {
            var pikachu = new Pikachu(); 

            Assert.AreEqual("Pikachu", pikachu.Name);
            Assert.AreEqual(1, pikachu.Level);
            Assert.AreEqual(10, pikachu.Attack);
            Assert.AreEqual(10, pikachu.Defense);
            Assert.AreEqual(10, pikachu.SpAttack);
            Assert.AreEqual(10, pikachu.SpDefense);
            Assert.IsNotNull(pikachu.Moves);
            Assert.LessOrEqual(pikachu.Moves.Count, 4);
        }

        [Test]
        public void Move_DefaultValues_ShouldInitializeCorrectly()
        {
            var thunderbolt = new Move("Thunderbolt", Type.Electric, MoveType.Special);

            Assert.AreEqual("Thunderbolt", thunderbolt.Name);
            Assert.AreEqual(100, thunderbolt.Power);
            Assert.AreEqual(1, thunderbolt.Speed);
            Assert.AreEqual(Type.Electric, thunderbolt.Type);
            Assert.AreEqual(MoveType.Special, thunderbolt.MoveType);
        }

        [Test]
        public void Modifier_ShouldMultiply_WhenDefenderHasTwoTypes()
        {
            var move = new Move("Surf", Type.Water, MoveType.Special);
            var defender = new PokemonStub(Type.Fire, Type.Ground); // Fire/Ground

            double mod = DamageCalculator.GetModifier(move, defender);

            Assert.AreEqual(4.0, mod); // 2x (Water vs Fire) * 2x (Water vs Ground)
        }



    }
}