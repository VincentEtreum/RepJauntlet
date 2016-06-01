namespace DamGame
{
    class Enemy : Sprite
    {
        Game myGame;
        int life;

        public Enemy(int newX, int newY, Game game)
        {
            LoadSequence(LEFT,
                new string[] { "data/Images/GHOST_LEFT1.png", "data/Images/GHOST_LEFT2.png", "data/Images/GHOST_LEFT3.png" });

            LoadSequence(RIGHT,
                new string[] { "data/Images/GHOST_RIGHT1.png", "data/Images/GHOST_RIGHT2.png", "data/Images/GHOST_RIGHT3.png" });

            ChangeDirection(LEFT);
            x = newX;
            y = newY;
            xSpeed = 2;
            ySpeed = 2;
            width = 16;
            height = 16;
            life = 15;
            myGame = game;
        }

        public override void Move()
        {
            if ((myGame.GetPlayer().GetX() >= x + width / 2 &&
                    myGame.GetPlayer().GetX() +
                    myGame.GetPlayer().GetWidth() >= x + width / 2) &&
                    (myGame.GetPlayer().GetY() >= y + height / 2 &&
                    myGame.GetPlayer().GetY() +
                    myGame.GetPlayer().GetHeight() >= y + height / 2) &&
                    myGame.IsValidMove(x + xSpeed, y + ySpeed, x + width + xSpeed,
                    y + height + ySpeed))
            {
                ChangeDirection(RIGHT);
                x += xSpeed;
                y += ySpeed;
            }
            else if ((myGame.GetPlayer().GetX() <= x + width / 2 &&
                    myGame.GetPlayer().GetX() +
                    myGame.GetPlayer().GetWidth() <= x + width / 2) &&
                    (myGame.GetPlayer().GetY() >= y + height / 2 &&
                    myGame.GetPlayer().GetY() +
                    myGame.GetPlayer().GetHeight() >= y + height / 2) &&
                    myGame.IsValidMove(x - xSpeed, y + ySpeed, x + width - xSpeed,
                    y + height + ySpeed))
            {
                ChangeDirection(LEFT);
                x -= xSpeed;
                y += ySpeed;
            }
            else if ((myGame.GetPlayer().GetX() >= x + width / 2 &&
                    myGame.GetPlayer().GetX() +
                    myGame.GetPlayer().GetWidth() >= x + width / 2) &&
                    (myGame.GetPlayer().GetY() < y + height / 2 &&
                    myGame.GetPlayer().GetY() +
                    myGame.GetPlayer().GetHeight() < y + height / 2) &&
                    myGame.IsValidMove(x + xSpeed, y - ySpeed, x + width + xSpeed,
                    y + height - ySpeed))
            {
                ChangeDirection(RIGHT);
                x += xSpeed;
                y -= ySpeed;
            }
            else if ((myGame.GetPlayer().GetX() <= x + width / 2 &&
                    myGame.GetPlayer().GetX() +
                    myGame.GetPlayer().GetWidth() <= x + width / 2) &&
                    (myGame.GetPlayer().GetY() < y + height / 2 &&
                    myGame.GetPlayer().GetY() +
                    myGame.GetPlayer().GetHeight() < y + height / 2) &&
                    myGame.IsValidMove(x - xSpeed, y - ySpeed, x + width - xSpeed,
                    y + height - ySpeed))
            {
                ChangeDirection(LEFT);
                x -= xSpeed;
                y -= ySpeed;
            }
            else if (myGame.GetPlayer().GetX() <= x + width / 2 &&
                    myGame.GetPlayer().GetX() +
                    myGame.GetPlayer().GetWidth() <= x + width / 2 &&
                    myGame.IsValidMove(x - xSpeed, y, x + width - xSpeed,
                    y + height))
            {
                ChangeDirection(LEFT);
                x -= xSpeed;
            }
            else if (myGame.GetPlayer().GetX() >= x + width / 2 &&
                    myGame.GetPlayer().GetX() +
                    myGame.GetPlayer().GetWidth() >= x + width / 2 &&
                    myGame.IsValidMove(x + xSpeed, y, x + width + xSpeed,
                    y + height))
            {
                ChangeDirection(RIGHT);
                x += xSpeed;
            }
            else if (myGame.GetPlayer().GetY() <= y + height / 2 &&
                    myGame.GetPlayer().GetY() +
                    myGame.GetPlayer().GetHeight() <= y + height / 2 &&
                    myGame.IsValidMove(x, y - ySpeed, x + width,
                    y + height - ySpeed))
                y -= ySpeed;
            else if (myGame.GetPlayer().GetY() >= y + height / 2 &&
                    myGame.GetPlayer().GetY() +
                    myGame.GetPlayer().GetHeight() >= y + height / 2 &&
                    myGame.IsValidMove(x, y + ySpeed, x + width,
                    y + height + ySpeed))
                y += ySpeed;
            
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
