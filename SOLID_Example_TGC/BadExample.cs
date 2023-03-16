
// S: A class should have one and only one reason to change, meaning that a class should have only one job.

namespace SOLIDExampleTGC_S_Bad
{
    public class BattleField
    {
        static void Main(string[] args)
        {
            Card monster = new Card("Young Red Dragon", 3, 2, "Young Red Dragon can't block", "Monster");
            // Spells dont need ATK or DEF
            Card spell = new Card("Lightning Bolt", 0, 0, "Lightning Bolt deals 3 damage to any target", "Spell");
        }
    }

    // Card can have more then one meening
    // They can be a monster, a spell, a trap, etc.
    public class Card
    {
        public string Name;
        public int ATK;
        public int DEF;
        public string Description;
        // Strings are bad to categorize cards
        public string CardType;

        public Card(string name, int atk, int def, string description, string cardType)
        {
            Name = name;
            ATK = atk;
            DEF = def;
            Description = description;
            CardType = cardType;
        }
    }
}