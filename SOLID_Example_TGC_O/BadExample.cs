//O: Open-Closed-Principle open for extension, but closed for modification

namespace SOLID_Example_TGC_O_Bad
{
    public class BattleField
    {
        static MonsterCard[] MonsterFields = new MonsterCard[5];
        static SpellCard[] SpellFields = new SpellCard[5];

        static void Main(string[] args)
        {
            MonsterCard monster = new MonsterCard("Young Red Dragon", 2, 1, "This monster can attack twice per round");
            SpellCard spell = new SpellCard("Lightning Bolt", "Kill one monster with less then 2 ATK");

            // In der BattleField-Klasse muss für jeden neuen Card-Typen eine neue PlayCard()-Methode geschrieben werden
            // Die BattleField-Klasse muss dafür immer verändert werden
            PlayCard(monster);
            PlayCard(spell);
        }

        // Jede PlayCard()-Methode ist individuell
        public static void PlayCard(MonsterCard monster)
        {
            Console.WriteLine($"{monster.Name} was played on the field");
            for(int i = 0; i < MonsterFields.Length; i++)
            {
                if (MonsterFields[i] == null)
                {
                    MonsterFields[i] = monster;
                    break;
                }
            }
        }

        public static void PlayCard(SpellCard spell)
        {
            Console.WriteLine($"{spell.Name} was played on the field");
            for (int i = 0; i < SpellFields.Length; i++)
            {
                if (SpellFields[i] == null)
                {
                    SpellFields[i] = spell;
                    break;
                }
            }
        }
    }

    public class MonsterCard
    {
        public string Name;
        public int ATK;
        public int DEF;
        public string Description;

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
        public string Description;

        public SpellCard(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
