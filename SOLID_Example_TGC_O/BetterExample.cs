//O: Open-Closed-Principle open for extension, but closed for modification

// Steps:
//      1. Erstelle eine abstrakte Card-Klasse
//              mit den Variablen: Name und Description
//              + Konstruktor mit Name und Description
//      2. Kopiere eine PlayCard-Methode in die Card-Klasse
//          und schreibe sie um
//      3. Lass MonsterCard und SpellCard von Card erben (Basis Konstruktor nutzen)
//      4. Lösche alle Properties, die nicht mehr benötigt werden
//      5. Aufruf der PlayCard-Methode in der Main-Funktion umschreiben
//      6. PlayCard-Methode in MonsterCard erweitern

namespace SOLID_Example_TGC_O_Good
{
    public class BattleField
    {
        static MonsterCard[] MonsterFields = new MonsterCard[5];
        static SpellCard[] SpellFields = new SpellCard[5];

        //static void Main(string[] args)
        //{
        //    MonsterCard monster = new MonsterCard("Young Red Dragon", 2, 1, "This monster can attack twice per round");
        //    SpellCard spell = new SpellCard("Lightning Bolt", "Kill one monster with less then 2 ATK");

        //    // Die Methode wurde in eine abstrakte Klasse ausgelagert und wird dort aufgerufen
        //    // Die BattleField-Klasse wird nicht mehr verändert
        //    monster.PlayCard(MonsterFields);
        //    spell.PlayCard(SpellFields);
        //}
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

        // PlayerCard()-Methode ist für jeden CardType gleich
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

        public MonsterCard(string name, int atk, int def, string description) : base (name, description)
        {
            ATK = atk;
            DEF = def;
        }

        // Durch die abstrakte Klasse kann die Methode in anderen Klassen erweitert werden,
        // bleibt für alle anderen Klassen aber gleich
        public override void PlayCard(Card[] cardFields)
        {
            base.PlayCard(cardFields);
            Console.WriteLine($"This Card has {ATK} attack points and {DEF} defanse points");
        }
    }

    public class SpellCard : Card
    {
        public SpellCard(string name, string description) : base (name, description) { }
    }
}
