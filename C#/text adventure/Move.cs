namespace text_adventure
{
    internal class Move
    {
        public string name;
        public float POW = 1;
        public int cost = 0;
        public bool attack = true;
        public bool type = true; // set to true to multiply the users ATK with POW, set to false to add POW to ATK

        public string getMove(Move move)
        {
            string stats = $"Name: {move.name}\ncost: {move.cost}\npower: {move.POW}\n{(move.attack ? "deals damage" : "heals you")}";
            return stats;
        }

        public Move Punch()
        {
            this.name = "punch";
            this.POW = 0;
            this.type = false;
            return this;
        }
        public Move Kick()
        {
            this.name = "kick";
            this.POW = 0;
            this.type = false;
            return this;
        }
        public Move Slap()
        {
            this.name = "slap";
            this.POW = 0;
            this.type = false;
            return this;
        }
        public Move Stab()
        {
            this.name = "stab";
            this.POW = 1;
            this.type = false;
            return this;
        }
        public Move Axe()
        {
            this.name = "Axe swing";
            this.POW = 3;
            this.type = false;
            return this;
        }
        public Move Fire()
        {
            this.name = "fireball";
            this.POW = 1.5f;
            this.cost = 2;
            return this;
        }
        public Move Ice()
        {
            this.name = "ice blast";
            this.POW = 1.5f;
            this.cost = 2;
            return this;
        }
        public Move Dark()
        {
            this.name = "dark blast";
            this.POW = 10;
            this.type = false;
            this.cost = 5;
            return this;
        }
        public Move Dispair()
        {
            this.name = "void blast";
            this.POW = 2;
            this.cost = 10;
            return this;
        }

        public Move Sword()
        {
            this.name = "Sword slash";
            this.POW = 5;
            this.type = false;
            return this;
        }

        public Move Heal()
        {
            this.name = "Heal";
            this.attack = false;
            this.cost = 1;
            return this;
        }

        public Move Light()
        {
            this.name = "Light blast";
            this.POW = 20;
            this.type = false;
            this.cost = 10;
            return this;
        }

        public Move Holy()
        {
            this.name = "Holy beam";
            this.POW = 5;
            this.cost = 25;
            return this;
        }
    }
}
