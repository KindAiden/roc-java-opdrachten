namespace text_adventure
{
    internal static class Randomizer
    {
        public static byte seed = 0b00000000;

        public static int RandInt()
        {
            byte rand = seed;

            rand = (byte)((rand * 5 + 1) % 256);
            seed = rand;
            return rand;
        }

        public static int RandomRange(int min, int max) //min is inclusive max is exclusive
        {
            if (min >= max)
            {
                int temp = min;
                min = max;
                max = temp;
            }

            int range = max - min;
            int rand = RandInt();

            return min + (rand % range);
        }

        public static float RandomRange(float min, float max)
        {
            if (min >= max)
            {
                float temp = min;
                min = max;
                max = temp;
            }

            float range = max - min;
            int intRand = RandomRange(0, 1000);
            float floatRand = intRand / 1000.0f;

            return min + floatRand * range;
        }
    }
}
