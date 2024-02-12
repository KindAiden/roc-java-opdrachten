using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace text_adventure
{
    internal class Enemies
    {
        public class Enemy() : Person
        {
            public int HP;
            public int ATK;
            public int DEF;
            public int SPD;
            public int MP;
            public int EXP;
            public int gold;
            public int chance;
            public List<Move> moves = new List<Move>();

            public Enemy Clone(Enemy original)
            {
                Enemy enemy = new Enemy();
                enemy.name = original.name;
                enemy.race = original.race;
                enemy.HP = original.HP;
                enemy.ATK = original.ATK;
                enemy.DEF = original.DEF;
                enemy.SPD = original.SPD;
                enemy.MP = original.MP;
                enemy.EXP = original.EXP;
                enemy.gold = original.gold;
                enemy.chance = original.chance;
                enemy.moves = original.moves;
                return enemy;
            }
        }

        public Enemy Slime(int rate)
        {
            Enemy enemy = new Enemy();
            enemy.name = "slime";
            enemy.race = "slime";
            enemy.HP = 5;
            enemy.ATK = 2;
            enemy.DEF = 0;
            enemy.SPD = 3;
            enemy.MP = 0;
            enemy.chance = rate;
            enemy.moves = new List<Move>() { new Move().Slap()};
            enemy.EXP = 2;
            enemy.gold = Randomizer.RandomRange(0, 2);
            return enemy;
        }
        public Enemy Goblin(int rate)
        {
            Enemy enemy = new Enemy();
            enemy.name = "goblin";
            enemy.race = "goblin";
            enemy.HP = 8;
            enemy.ATK = 2;
            enemy.DEF = 0;
            enemy.SPD = 4;
            enemy.MP = 4;
            enemy.chance = rate;
            enemy.moves = new List<Move>() { new Move().Punch(), new Move().Stab()};
            enemy.EXP = 5;
            enemy.gold = Randomizer.RandomRange(4, 10);
            return enemy;
        }
        public Enemy Orc(int rate)
        {
            Enemy enemy = new Enemy();
            enemy.name = "orc";
            enemy.race = "orc";
            enemy.HP = 14;
            enemy.ATK = 5;
            enemy.DEF = 2;
            enemy.SPD = 3;
            enemy.MP = 6;
            enemy.chance = rate;
            enemy.moves = new List<Move>() { new Move().Punch(), new Move().Axe() };
            enemy.EXP = 10;
            enemy.gold = Randomizer.RandomRange(1, 8);
            return enemy;
        }
        public Enemy Wizzard(int rate)
        {
            Enemy enemy = new Enemy();
            enemy.name = "wizzard";
            enemy.race = "human";
            enemy.HP = 20;
            enemy.ATK = 6;
            enemy.DEF = 3;
            enemy.SPD = 5;
            enemy.MP = 20;
            enemy.chance = rate;
            enemy.moves = new List<Move>() { new Move().Fire(), new Move().Ice() };
            enemy.EXP = 17;
            enemy.gold = Randomizer.RandomRange(6, 10);
            return enemy;
        }
        public Enemy Demon(int rate)
        {
            Enemy enemy = new Enemy();
            enemy.name = "demon";
            enemy.race = "demon";
            enemy.HP = 50;
            enemy.ATK = 10;
            enemy.DEF = 6;
            enemy.SPD = 10;
            enemy.MP = 40;
            enemy.chance = rate;
            enemy.moves = new List<Move>() { new Move().Punch(), new Move().Fire(), new Move().Dark()};
            enemy.EXP = 25;
            enemy.gold = Randomizer.RandomRange(10, 12);
            return enemy;
        }
        public Enemy DemonLord(int rate)
        {
            Enemy enemy = new Enemy();
            enemy.name = "demon lord";
            enemy.race = "demon";
            enemy.HP = 200;
            enemy.ATK = 15;
            enemy.DEF = 10;
            enemy.SPD = 16;
            enemy.MP = 75;
            enemy.chance = rate;
            enemy.moves = new List<Move>() { new Move().Fire(), new Move().Dark(), new Move().Dispair() };
            enemy.EXP = 999;
            enemy.gold = 999;
            return enemy;
        }
        public Enemy Test(int rate)
        {
            Enemy enemy = new Enemy();
            enemy.name = "ERROR";
            enemy.HP = 1;
            enemy.ATK = 1;
            enemy.DEF = 1;
            enemy.SPD = 1;
            enemy.MP = 1;
            enemy.chance = rate;
            enemy.moves = new List<Move>() { new Move().Slap() };
            enemy.EXP = 1;
            enemy.gold = 1;
            return enemy;
        }
    }
}
