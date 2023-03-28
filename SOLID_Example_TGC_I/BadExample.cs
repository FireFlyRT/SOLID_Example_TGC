//I:  Interface Segregation Principle: do not force any client to implement an interface which is irrelevant to them

namespace SOLID_Example_TGC_I_Bad
{
    public class BattleField : IBattleField
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
            instandSpell.PlayCard(SpellFields);
        }
    }

    public interface ICard
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public abstract void PlayCard(Card[] cardFields);
    }

    public interface IBattleField { }

    // Die Card-Klasse braucht kein IBattleField-Interface,
    // da es nie Funktionen dafür ausuführen darf
    public abstract class Card : ICard, IBattleField
    {
        // Die Inhalte des Interfaces müssen in der Klasse vorhanden sein
        public string Name { get; set; }
        public string Description { get; set; }

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

    // Klassen, deren Parent-Klasse schon das Interface implementieren,
    // benötigen dieses nicht nocheinmal
    public class MonsterCard : Card, ICard
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
            base.PlayCard(cardFields);
            Console.WriteLine($"This is an instant spell!");
        }
    }
}
