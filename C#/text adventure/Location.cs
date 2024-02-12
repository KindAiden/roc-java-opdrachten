using System.Numerics;

namespace text_adventure
{
    internal class Location
    {
        public string name; // name of this location
        public string? prefix; // the text displayed before the name
        public int x;
        public int y;
        public string? state = "Normal";
        public List<string> directions = new List<string>();
        public Dictionary<string, Location> paths = new Dictionary<string, Location>(); // locations to go to from this location
        public List<Enemies.Enemy> encounters = new List<Enemies.Enemy>(); // enemies that can be encountered in this location
        public int encounterChance; // chance of an encounter starting
        public List<string> items = new List<string>(); // items that can be found in this location
        public int itemChance; // chance of an encounter starting

        // Parameterless constructor
        public Location()
        {

        }

        // Parameterized constructor
        public Location(string name)
        {
            this.name = name;
        }

        // Parameterized constructor
        public Location(string prefix, string name)
        {
            this.name = name;
            this.prefix = prefix;
        }

        // Parameterized constructor
        public Location(string prefix, string name, string directions)
        {
            this.name = name;
            this.prefix = prefix;
            this.directions = directions.Split(',').ToList();
        }

        public string GetLocation()
        {
            string output = "";
            output = $"you are {prefix} {name}\nYou can go in these directions:";
            foreach (string direction in directions)
            {
                string dir = direction.ToLower();
                if (paths[dir].name != "demon realm")
                    output += $"\n{direction} to a {paths[dir].name}";
                else
                    output += $"\n{direction} to the {paths[dir].name}";
            }
            return output;
        }

        public void SetEncounters()
        {
            bool hard = false;
            Enemies enemies = new Enemies();
            foreach (Location location in paths.Values)
            {
                if (location.name == "demon realm")
                {
                    hard = true;
                    break;
                }
            }
            switch (name)
            {
                case "city":
                    encounterChance = 1;
                    encounters.Add(enemies.Slime(100));
                    if (hard)
                        encounterChance = 5;
                    break;

                case "village":
                    encounterChance = 10;
                    if (hard)
                    {
                        encounters.Clear();
                        encounters.AddRange([enemies.Slime(95), enemies.Goblin(5)]);
                        break;
                    }
                    encounters.Add(enemies.Slime(100));
                    break;

                case "forest":
                    if (hard)
                    {
                        encounterChance = 60;
                        encounters.AddRange([enemies.Slime(40), enemies.Goblin(45), enemies.Orc(15)]);
                        break;
                    }
                    encounterChance = 50;
                    encounters.AddRange([enemies.Slime(60), enemies.Goblin(30), enemies.Orc(10)]);
                    break;

                case "dessert":
                    if (hard)
                    {
                        encounterChance = 50;
                        encounters.AddRange([enemies.Goblin(65), enemies.Orc(30), enemies.Demon(5)]);
                        break;
                    }
                    encounterChance = 30;
                    encounters.AddRange([enemies.Goblin(70), enemies.Orc(30)]);
                    break;

                case "mountain":
                    if (hard)
                    {
                        encounterChance = 40;
                        encounters.AddRange([enemies.Slime(20), enemies.Goblin(20), enemies.Orc(40), enemies.Wizzard(20)]);
                        break;
                    }
                    encounterChance = 30;
                    encounters.AddRange([enemies.Slime(40), enemies.Orc(40), enemies.Wizzard(20)]);
                    break;

                case "demon realm":
                    encounterChance = 90;
                    encounters.AddRange([enemies.Wizzard(20), enemies.Demon(70), enemies.DemonLord(10)]);
                    break;
            }
        }

        void GetEncounter()
        {

        }
    }
}
