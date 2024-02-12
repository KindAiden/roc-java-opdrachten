namespace text_adventure
{
    internal class Player : Person
    {
        public int HP = 10;
        public int ATK = 2;
        public int DEF = 0;
        public int SPD = 3;
        public int MP = 0;
        public int EXP = 0;
        public int maxHP = 10;
        public int maxMP = 0;
        public int maxEXP = 5;
        public int level = 1;
        public List<Move> moves = new List<Move>();
        public Dictionary<string, int> items = new Dictionary<string, int>();
        public int money;

        private List<Move> learnset = new List<Move>() { new Move().Stab(), new Move().Heal(), new Move().Fire(), new Move().Ice(), new Move().Light(), new Move().Holy()};

        public void LevelUp()
        {
            EXP -= maxEXP;
            maxEXP += 5;
            level++;
            if (EXP >= maxEXP)
                LevelUp();

            Console.WriteLine("Level UP");
            Console.WriteLine($"{name} is now level {level}");
            Console.ReadLine();

            // store the current seed
            byte seed = Randomizer.seed;
            // set the seed to a 'random' value
            Randomizer.seed = (byte)(DateTime.Now.Millisecond + DateTime.Now.Minute);
            // get at number from 0 to 4 to get which stat to update and a number from 2 to 4 to add to the chosen stat
            int rand = Randomizer.RandomRange(0, 5);
            int statboost = Randomizer.RandomRange(2, 5);
            //reset the seed to what it was before
            Randomizer.seed = seed;

            Console.WriteLine($"Choose which stat you want to improve:\n{GetStats()}");
            string input = Console.ReadLine().ToLower();
            switch (input)
            {
                default:
                case "hp":
                case "0":
                    maxHP += statboost;
                    Console.WriteLine($"HP went up by {statboost}");
                    break;

                case "atk":
                case "1":
                    ATK += statboost;
                    Console.WriteLine($"ATK went up by {statboost}");
                    break;

                case "def":
                case "2":
                    DEF += statboost;
                    Console.WriteLine($"DEF went up by {statboost}");
                    break;

                case "spd":
                case "3":
                    SPD += statboost;
                    Console.WriteLine($"SPD went up by {statboost}");
                    break;

                case "mp":
                case "4":
                    maxMP += statboost;
                    Console.WriteLine($"MP went up by {statboost}");
                        break;
            }
            // learn a new move
            if (level % 2 == 0 && learnset.Count > 0)
                LearnMove();


            HP = maxHP;
            MP = maxMP;
            Console.ReadLine();
        }
        public void LearnMove()
        {
            moves.Add(learnset[0]);
            Console.WriteLine($"{name} learned {learnset[0].name}");
            learnset.RemoveAt(0);
        }

        public string GetStats()
        {
            string output = "";
            output += $"{name} - level: {level}\ngold: {money}\nstats:\n- HP: {HP}/{maxHP}\n- ATK: {ATK}\n- DEF: {DEF}\n- SPD: {SPD}\n- MP: {MP}/{maxMP}\n- EXP:{EXP}/{maxEXP}\n";
            return output;
        }
    }
}
