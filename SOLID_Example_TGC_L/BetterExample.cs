//L: Liskov’s-Substitution-Principle: Derived or child classes must be substitutable for their base or parent classes

// Steps:
//      1. Füge der InstandSpellCard-Klasse die Basis Funktion von PlayCard hinzu

namespace SOLID_Example_TGC_L_Good
{
    public class BattleField
    {
        static MonsterCard[] MonsterFields = new MonsterCard[5];
        static SpellCard[] SpellFields = new SpellCard[5];

        static void Main(string[] args)
        {
            MonsterCard monster = new MonsterCard("Young Red Dragon", 2, 1, "This monster can attack twice per round");
            SpellCard spell = new SpellCard("Lightning Bolt", "Kill one monster with less then 2 ATK");
            InstantSpellCard instandSpell = new InstantSpellCard("Dream Fracture", "Counter target Spell. Its controller draws a card");

            monster.PlayCard(MonsterFields);
            spell.PlayCard(SpellFields);
            // Das Verhalten ist wie erwartet
            instandSpell.PlayCard(SpellFields);
        }
    }

    public abstract class Card
    {
        public string Name;
        public string Description;

        public Card(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual void PlayCard(Card[] cardFields)
        {
            Console.WriteLine($"{Name} was played on the field");
            for (int i = 0; i < cardFields.Length; i++)
            {
                if (cardFields[i] == null)
                {
                    cardFields[i] = this;
                    break;
                }
            }
        }
    }

    public class MonsterCard : Card
    {
        public int ATK;
        public int DEF;

        public MonsterCard(string name, int atk, int def, string description) : base(name, description)
        {
            ATK = atk;
            DEF = def;
        }

        public override void PlayCard(Card[] cardFields)
        {
            base.PlayCard(cardFields);
            Console.WriteLine($"This Card has {ATK} attack points and {DEF} defanse points");
        }
    }

    public class SpellCard : Card
    {
        public SpellCard(string name, string description) : base(name, description) { }
    }

    public class InstantSpellCard : SpellCard
    {
        public InstantSpellCard(string name, string description) : base(name, description) { }

        public override void PlayCard(Card[] cardFields)
        {
            // Die Funktion der Basis-Klasse wird aufgerufen.
            // Die Kind-Klasse ergänzt die Funktion der Eltern-Klasse.
            base.PlayCard(cardFields);
            Console.WriteLine($"This is an instant spell!");
        }
    }
}
