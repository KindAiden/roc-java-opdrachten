using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace text_adventure
{
    internal static class Debug
    {
        public static void Menu(Player player, Location currentlocation, World world, Action Battle)
        {
            string[] actions = Console.ReadLine().ToLower().Split(' ');
            for (int i = 0; i < actions.Length; i++)
            {
                try
                {
                    switch (actions[i])
                    {
                        case "chp":
                            i++;
                            player.maxHP = int.Parse(actions[i]);
                            player.HP = player.maxHP;
                            Console.WriteLine($"HP set to {player.HP}");
                            break;

                        case "catk":
                            i++;
                            player.ATK = int.Parse(actions[i]);
                            Console.WriteLine($"ATK set to {player.ATK}");
                            break;

                        case "cdef":
                            i++;
                            player.DEF = int.Parse(actions[i]);
                            Console.WriteLine($"DEF set to {player.DEF}");
                            break;

                        case "cspd":
                            i++;
                            player.SPD = int.Parse(actions[i]);
                            Console.WriteLine($"SPD set to {player.SPD}");
                            break;

                        case "cmp":
                            i++;
                            player.maxMP = int.Parse(actions[i]);
                            player.MP = player.maxMP;
                            Console.WriteLine($"MP set to {player.MP}");
                            break;

                        case "cexp":
                            i++;
                            player.EXP = int.Parse(actions[i]);
                            Console.WriteLine($"EXP set to {player.EXP}");
                            break;

                        case "levelup":
                            player.EXP = player.maxEXP;
                            player.LevelUp();
                            break;

                        case "cgold":
                            i++;
                            player.money = int.Parse(actions[i]);
                            Console.WriteLine($"Gold set to {player.money}");
                            break;

                        case "teleport":
                            i++;
                            currentlocation = world.world[int.Parse(actions[i])];
                            Console.WriteLine($"teleported to {currentlocation.name}");
                            break;

                        case "heal":
                            player.HP = player.maxHP;
                            player.MP = player.maxMP; 
                            Console.WriteLine("You had a good rest in the inn");
                            break;

                        case "encounter":
                            Battle.Invoke();
                            break;

                        case "crng":
                            i++;
                            Randomizer.seed = byte.Parse(actions[i]);
                            Console.WriteLine($"RNG set to {Randomizer.seed}");
                            break;
                    }
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
