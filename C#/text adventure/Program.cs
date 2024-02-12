using System.Collections;
using System.Threading;
using text_adventure;

World world = new World();
Player player = new Player();
player.moves.Add(new Move().Punch());
player.moves.Add(new Move().Kick());

Location currentLocation = null;
try
{ 
    Console.Write("Set seed. (leave empty for random seed): ");
    Randomizer.seed = (byte)int.Parse(Console.ReadLine());
}
catch { Randomizer.seed = (byte)(DateTime.Now.Millisecond + DateTime.Now.Minute); }

try
{
    Console.Write("Set world size: ");
    world.worldSize = int.Parse(Console.ReadLine());
}
catch { }
world.generateWorld();

List<Location> spawns = new List<Location>();
for (int i = 0; i < world.world.Count(); i++)
{
    if (world.world[i].name != "demon realm")
        spawns.Add(world.world[i]);
}

currentLocation = spawns[Randomizer.RandomRange(0, spawns.Count() - 1)];

Console.WriteLine("What is your name?");
player.name = Console.ReadLine();

Console.Clear();

Console.WriteLine($"In the land of Quiliver everyone lived a peacefull life surounded by happiness. Untill one day the demon lord attacked the lands.\nThe people of Quiliver trembled in fear of the demon lord until a hero named {player.name} appeard.\nWill they be able to stop the looming terror?");
Console.ReadLine();
Console.Clear();

while (true)
{
    Console.WriteLine(player.GetStats());
    Console.WriteLine(currentLocation.GetLocation());
    string actions = "What would you like to do:\n0-Move\n1-Search";
    if (currentLocation.name == "city" || currentLocation.name == "village")
        actions += "\n2-Buy\n3-Rest";
    Console.WriteLine(actions);
    string input = Console.ReadLine().ToLower();

    if (currentLocation.paths.ContainsKey(input))
        currentLocation = currentLocation.paths[input];

    switch (input)
    {
        case "move":
        case "0":
            //Console.WriteLine(currentLocation.GetLocation());
            Console.WriteLine("Where would you like to go?");
            input = Console.ReadLine().ToLower();
            if (currentLocation.paths.ContainsKey(input))
                currentLocation = currentLocation.paths[input];
            break;

        case "search":
        case "1":
            int rand = Randomizer.RandomRange(0, 101);
            if (rand <= currentLocation.encounterChance)
            {
                Battle();
                break;
            }
            rand = Randomizer.RandomRange(0, 101);
            if (rand <= currentLocation.itemChance && currentLocation.items.Count() > 0)
            {
                string item = currentLocation.items[rand % currentLocation.items.Count() - 1];
                if (player.items.ContainsKey(item))
                    player.items[item]++;
                else
                    player.items.Add(item, 1);
                Console.WriteLine($"You found a {item}");
                break;
            }
            Console.WriteLine("You couldn't find anything");
            Console.ReadLine();
            break;

        case "buy":
        case "2":
            break;

        case "rest":
        case "3":
            player.HP = player.maxHP;
            player.MP = player.maxMP;
            Console.WriteLine("You had a good rest in the inn");
            break;

        case "debug":
            Debug.Menu(player, currentLocation, world, Battle);
            break;
    }
    Console.Clear();
}

void Battle()
{
    Console.Clear();
    int rand = Randomizer.RandomRange(0, 101);
    Enemies.Enemy enemy = new Enemies().Test(1);
    foreach (Enemies.Enemy encounter in currentLocation.encounters)
    {
        if (rand > encounter.chance)
        {
            rand -= encounter.chance;
            continue;
        }
        enemy = encounter.Clone(encounter);
    }
    Console.WriteLine($"{enemy.name} attacks.");
    Console.ReadLine();

    bool run = false;
    while (true)
    {
        Console.Clear();
        Console.WriteLine($"{player.name}: {player.HP}/{player.maxHP}\n{enemy.name}: {enemy.HP}");

        if (enemy.SPD > player.SPD)
        {
            attackEnemy();
            checkDeath();
            attackPlayer();
            if (run)
                return;
            if (enemy.HP <= 0)
                break;
        }
        else
        {
            attackPlayer();
            if (run)
                return;
            if (enemy.HP <= 0)
                break;
            attackEnemy();
            checkDeath();
        }
    }
    Console.WriteLine("You won!");
    Console.ReadLine();
    player.EXP += enemy.EXP;
    player.money += enemy.gold;
    Console.WriteLine($"Got {enemy.EXP} EXP\nGot {enemy.gold} gold");
    Console.ReadLine();
    Console.Clear();
    if (player.EXP >= player.maxEXP)
        player.LevelUp();

    void attackPlayer()
    {
        Move move = null;
        while (move == null)
        {
            Console.WriteLine("What will you do?\n0-Attack\n1-Run");
            string input = Console.ReadLine().ToLower();
            if (input == "0" || input == "attack")
            {
                Console.WriteLine($"MP: {player.MP}/{player.maxMP}");
                for (int i = 0; i < player.moves.Count(); i++)
                {
                    string output = $"{i}-{player.moves[i].name}";
                    if (player.moves[i].cost > 0)
                        output += $" MP:{player.moves[i].cost}";
                    Console.WriteLine(output);
                }
                int moveIndex;
                if (!int.TryParse(Console.ReadLine(), out moveIndex))
                {
                    Console.WriteLine("Invalid input");
                    Console.ReadLine();
                    continue;
                }
                if (moveIndex < player.moves.Count())
                {
                    if (player.moves[moveIndex].cost > player.MP)
                    {
                        Console.WriteLine("You don't have enough MP");
                        continue;
                    }
                    move = player.moves[moveIndex];
                }
                continue;
            }
            if (input == "1" || input == "run")
            {
                if (player.SPD > Randomizer.RandomRange(0, enemy.SPD))
                {
                    run = true;
                    Console.WriteLine("Ran away");
                    Console.ReadLine();
                    return;
                }
                Console.WriteLine("Couldn't run away");
                Console.ReadLine();
                return;
            }
        }
        player.MP -= move.cost;
        Console.WriteLine($"{player.name} used {move.name}");
        useMove(move, true);
    }

    void attackEnemy()
    {
        Move move = enemy.moves[Randomizer.RandomRange(0, enemy.moves.Count())];
        Console.WriteLine($"{enemy.name} used {move.name}");
        useMove(move, false);
    }

    void checkDeath()
    {
        if (player.HP <= 0)
        {
            Console.WriteLine("You died...");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }

    void useMove(Move move, bool playerMove)
    {
        int damage;
        int ATK;
        int DEF;
        float POW = move.POW;
        if (playerMove)
        {
            ATK = player.ATK;
            DEF = enemy.DEF;
        }
        else
        {
            ATK = enemy.ATK;
            DEF = player.DEF;
        }

        if (move.type)
            damage = (int)(ATK * POW);
        else
            damage = (int)(ATK + POW);

        if (!move.attack)
        {
            if (playerMove)
            {
                player.HP += damage;
                Console.WriteLine($"{player.name} healed {damage} HP!");
            }
            else
            {
                enemy.HP += damage;
                Console.WriteLine($"{enemy.name} healed {damage} HP!");
            }
            return;
        }

        damage = (int)MathF.Max(0, damage - DEF);

        if (damage == 0)
        {
            if (playerMove)
                Console.WriteLine($"{enemy.name} blocked the attack!");
            else
                Console.WriteLine($"{player.name} blocked the attack!");
            Console.ReadLine();
            return;
        }

        if (playerMove)
            enemy.HP -= damage;
        else
            player.HP -= damage;

        Console.WriteLine($"{move.name} did {damage} damage");
        Console.ReadLine();
    }
}
