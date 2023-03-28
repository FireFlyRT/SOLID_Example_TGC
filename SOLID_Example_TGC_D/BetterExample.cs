//D:  Dependency Inversion Principle: Classes and Details should depend upon abstraction

// Steps:
//      1. In der Main-Methode alle Variablen mit ICard implementieren
//      2. In der Battlefield-Klasse alle Arrays mit ICard deklarieren und
//          intitialisieren
//      3. In dern PlayCard-Methoden die Parameter zu ICard anpassen
namespace SOLID_Example_TGC_D_Good
{
    public class BattleField : IBattleField
    {
        // In den Arrays können alle Klassen gespeichert werden, die das Interface implementieren
        // Jetzt ist es egal welche Karten-Arten noch hinzukommen.
        static ICard[] MonsterFields = new ICard[5];
        static ICard[] SpellFields = new ICard[5];

        static void Main(string[] args)
        {
            // Die Variablen werden mit der Klasse initialisiert
            // müssen aber über das Interface auf die Funktionen der Klasse zugreifen.
            ICard monster = new MonsterCard("Young Red Dragon", 2, 1, "This monster can attack twice per round");
            ICard spell = new SpellCard("Lightning Bolt", "Kill one monster with less then 2 ATK");
            ICard instandSpell = new InstantSpellCard("Dream Fracture", "Counter target Spell. Its controller draws a card");

            monster.PlayCard(MonsterFields);
            spell.PlayCard(SpellFields);
            instandSpell.PlayCard(SpellFields);
        }
    }

    public interface ICard
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public abstract void PlayCard(ICard[] cardFields);
    }

    public interface IBattleField { }

    public abstract class Card : ICard
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Card(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public virtual void PlayCard(ICard[] cardFields)
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

        public override void PlayCard(ICard[] cardFields)
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

        public override void PlayCard(ICard[] cardFields)
        {
            base.PlayCard(cardFields);
            Console.WriteLine($"This is an instant spell!");
        }
    }
}
