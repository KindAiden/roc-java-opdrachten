using System.Numerics;

namespace text_adventure
{
    internal class World
    {
        // every big location in the world
        public List<Location> world = new List<Location>();
        public int worldSize = 5;

        public World() 
        {

        }

        public void generateWorld()
        {
            int x = 0;
            int y = 0;
            string[] names = { "in a-city", "in a-village", "in a-forest", "in a-dessert", "on a-mountain", "in the-demon realm" };
            while (y < worldSize)
            {
                Location newLocation = new Location();
                string[] name = names[Randomizer.RandomRange(0, names.Count() - 1)].Split('-');
                newLocation.name = name[1];
                newLocation.prefix = name[0];
                newLocation.x = x;
                newLocation.y = y;

                world.Add(newLocation);

                x++;
                if (x >= worldSize)
                {
                    x = 0;
                    y++;
                }
            }
            x = Randomizer.RandomRange(0, worldSize);
            y = Randomizer.RandomRange(0, worldSize);
            Location demonRealm = new Location();
            string[] Name = names[names.Count() - 1].Split('-');
            demonRealm.name = Name[1];
            demonRealm.prefix = Name[0];
            demonRealm.x = x;
            demonRealm.y = y;
            world[y * worldSize + x] = demonRealm;


            foreach (Location location in world)
            {
                location.SetEncounters();
                x = location.x;
                y = location.y;
                int index = world.IndexOf(location);

                if (y > 0) // north
                {
                    location.directions.Add("North");
                    location.paths.Add("north", world[index - worldSize]);
                }
                if (x < worldSize - 1) // east
                {
                    location.directions.Add("East");
                    location.paths.Add("east", world[index + 1]);
                }
                if (y < worldSize - 1) // south
                {
                    location.directions.Add("South");
                    location.paths.Add("south", world[index + worldSize]);
                }
                if (x > 0) // west
                {
                    location.directions.Add("West");
                    location.paths.Add("west", world[index - 1]);
                }
            }
        }
    }
}