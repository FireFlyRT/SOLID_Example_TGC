
// S: A class should have one and only one reason to change, meaning that a class should have only one job.


// Steps:
//      1. Kopiere Card-Klasse und bennen beide um: "MonsterCard", "SpellCard"
//      2. Lösche alle Properties, die nicht mehr benötigt werden
//      3. In der Main-Funktion Klassen ändern
//      4. Jede Klasse hat nun seine eigene Aufgabe: Ein Monster oder Spell repräsentieren

namespace SOLIDExampleTGC_S_Good
{
    public class BattleField
    {
        //static void Main(string[] args)
        //{
        //    MonsterCard monster = new MonsterCard("Young Red Dragon", 2, 1, "This monster can attack twice per round");
        //    SpellCard spell = new SpellCard("Lightning Bolt", "Kill one monster with less then 2 ATK");
        //}
    }

    //public class Card
    //{
    //    public int ATK;
    //    public int DEF;
    //    public string Description;
    //    public string CardType;

    //    public Card(int atk, int def, string description, string cardType)
    //    {
    //        ATK = atk;
    //        DEF = def;
    //        Description = description;
    //        CardType = cardType;
    //    }
    //}

    public class MonsterCard
    {
        public string Name;
        public int ATK;
        public int DEF;
        public string Description;
        // CardType wird nicht mehr benötigt

        public MonsterCard(string name, int atk, int def, string description)
        {
            Name = name;
            ATK = atk;
            DEF = def;
            Description = description;
        }
    }

    public class SpellCard
    {
        public string Name;
        // ATK und DEF sind obsolet
        public string Description;
        // CardType wird nicht mehr benötigt

        public SpellCard(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}