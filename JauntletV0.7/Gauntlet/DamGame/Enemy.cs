namespace DamGame
{
    class Enemy : Sprite
    {

        protected int life;

        public Enemy(int newX, int newY)
        {
            LoadSequence(LEFT,
                new string[] { "data/Images/GHOST_LEFT1.png", "data/Images/GHOST_LEFT2.png", "data/Images/GHOST_LEFT3.png" });

            LoadSequence(RIGHT,
                new string[] { "data/Images/GHOST_RIGHT1.png", "data/Images/GHOST_RIGHT2.png", "data/Images/GHOST_RIGHT3.png" });

            ChangeDirection(LEFT);
            x = newX;
            y = newY;
            xSpeed = 3;
            ySpeed = 3;
            width = 16;
            height = 16;
            life = 15;
        }

        public override void Move()
        {
            // TO DO: Avoid magic numbers
            if ((x > 1024 - width) || (x < 0))
                xSpeed = -xSpeed;
            x = (short)(x + xSpeed);
            if (xSpeed < 0)
                ChangeDirection(LEFT);
            else
                ChangeDirection(RIGHT);

            NextFrame();
        }

        public void SetLife(int life)
        {
            this.life = life;
        }

        public int GetLife()
        {
            return life;
        }
    }
}
