using System;
using System.Collections.Generic;

namespace DamGame
{
    class Game
    {
        private Font font18;
        private Player player;
        private List<Enemy> enemies = new List<Enemy>();
        private List<Key> keys = new List<Key>();
        private List<Door> doors = new List<Door>();
        private List<Food> foods = new List<Food>();
        private Level currentLevel;
        private bool finished;
        private int numEnemies;
        private Shot myShot;
        private char direction;
        private DateTime start;
        private DateTime current;
        private int time;
        byte countLife = 0;
        int score;

        public Game()
        {
            font18 = new Font("data/Joystix.ttf", 18);
            player = new Player();

            Hardware.ScrollTo((short) (512 - (player.GetX())), (short)(384 - player.GetY()));
            //Centering scroll to the character

            Random rnd = new Random();

            numEnemies = 2;

            Enemy enemy;

            for (int i = 0; i < numEnemies; i++)
            {
                enemy = new Enemy(rnd.Next(200, 800), rnd.Next(50, 600), this);
                enemies.Add(enemy);
            }
            
            currentLevel = new Level();
            finished = false;

            myShot = new Shot(currentLevel, player.GetX(), player.GetY(), 0, 0);
            myShot.Hide();
            direction = 'R';
            score = 0;

            //create object into level
            Door newDoor;
            Key newKey;
            Food newFood;


             for (int row = 0; row < currentLevel.GetlevelHeight(); row++)
                  for (int col = 0; col < currentLevel.GetLevelWidth(); col++)
                  {
                      int xPos = currentLevel.GetLeftMargin() + col * currentLevel.GetTileWidth();
                      int yPos = currentLevel.GetTopMargin()+ row * currentLevel.GetTileHeight();

                      switch (currentLevel.GetLevelDescription(col, row))
                      {
          
                          // Q = key

                          case 'Q':
                            newKey = new Key(xPos, yPos);
                            currentLevel.SetSpacePosition(row, col);
                            keys.Add(newKey);
                            break;
                          case '[':
                            newDoor = new Door(xPos, yPos, 'V');
                            doors.Add(newDoor);
                            break;
                        case '_':
                            newDoor = new Door(xPos, yPos, 'H');
                            doors.Add(newDoor);
                            break;
                        case 'F':
                            newFood = new Food(xPos, yPos);
                            foods.Add(newFood);
                            break;

                    }
                }

            start = DateTime.Now;
            }

            // Update screen
            public void DrawElements()
            {
                Hardware.ClearScreen();

                currentLevel.DrawOnHiddenScreen();
                Hardware.WriteHiddenText("Score: " + score,
                    40, 10,
                    0xCC, 0xCC, 0xCC,
                    font18);
                Hardware.WriteHiddenText("Life: " + Convert.ToString(player.GetLife()),
                    260, 10,
                    0xCC, 0xCC, 0xCC,
                    font18);
                Hardware.WriteHiddenText("Keys: " + Convert.ToString(player.GetKeys()),
                    480, 10,
                    0xCC, 0xCC, 0xCC,
                    font18);

                player.DrawOnHiddenScreen();
                for (int i = 0; i < enemies.Count; i++)
                    enemies[i].DrawOnHiddenScreen();
                for (int i = 0; i < keys.Count; i++)
                    keys[i].DrawOnHiddenScreen();
                for (int i = 0; i < doors.Count; i++)
                    doors[i].DrawOnHiddenScreen();

            myShot.DrawOnHiddenScreen();
                Hardware.ShowHiddenScreen();
            }


        // Check input by the user
        public void CheckKeys()
        {
            if ((Hardware.KeyPressed(Hardware.KEY_RIGHT))
                    && (currentLevel.IsValidMove(
                        player.GetX() + player.GetSpeedX(), 
                        player.GetY(), 
                        player.GetX() + player.GetWidth() + player.GetSpeedX(), 
                        player.GetY() + player.GetHeight())))
            {
                player.MoveRight();
                Hardware.ScrollHorizontally((short)-player.GetSpeedX());
                direction = 'R';

            }
               

            if ((Hardware.KeyPressed(Hardware.KEY_LEFT))
                && (currentLevel.IsValidMove(
                        player.GetX() - player.GetSpeedX(),
                        player.GetY(),
                        player.GetX() + player.GetWidth() - player.GetSpeedX(),
                        player.GetY() + player.GetHeight())))
            {
                player.MoveLeft();
                Hardware.ScrollHorizontally((short)player.GetSpeedX());
                direction = 'L';
            }
                

            if ((Hardware.KeyPressed(Hardware.KEY_DOWN))
                 && (currentLevel.IsValidMove(
                        player.GetX(),
                        player.GetY() + player.GetSpeedY(),
                        player.GetX() + player.GetWidth(),
                        player.GetY() + player.GetHeight() + player.GetSpeedY())))
            {
                player.MoveDown();
                Hardware.ScrollVertically((short)-player.GetSpeedY());
                direction = 'D';
            }
                

            if ((Hardware.KeyPressed(Hardware.KEY_UP))
                && (currentLevel.IsValidMove(
                        player.GetX(),
                        player.GetY() - player.GetSpeedY(),
                        player.GetX() + player.GetWidth(),
                        player.GetY() + player.GetHeight() - player.GetSpeedY())))
            {
                player.MoveUp();
                Hardware.ScrollVertically((short)player.GetSpeedY());
                direction = 'U';
            }

            if ((Hardware.KeyPressed(Hardware.KEY_SPC)) && (!myShot.IsVisible()))
            {
                if (direction == 'R')
                    myShot = new Shot(currentLevel, player.GetX(), player.GetY(), 10, 0);
                if (direction == 'L')
                    myShot = new Shot(currentLevel, player.GetX(), player.GetY(), -10, 0);
                if (direction == 'U')
                    myShot = new Shot(currentLevel, player.GetX(), player.GetY(), 0, -10);
                if (direction == 'D')
                    myShot = new Shot(currentLevel, player.GetX(), player.GetY(), 0, 10);

            }


            if (Hardware.KeyPressed(Hardware.KEY_ESC))
                finished = true;
        }


        // Move enemies, animate background, etc 
        public void MoveElements()
        {
            myShot.Move();
            for (int i = 0; i < numEnemies; i++)
                enemies[i].Move();
        }

        // Check collisions and apply game logic
        public void CheckCollisions()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].CollisionsWith(myShot))
                {
                    enemies[i].SetLife(enemies[i].GetLife() - player.GetAttack());

                    if(enemies[i].GetLife() < 0)
                    {
                        enemies[i].Hide();
                        score += 100;
                    }
                    myShot.Hide();
                }
            }

            for (int i = 0; i < keys.Count; i++)
            {
                if (keys[i].CollisionsWithArround(player))
                {
                    player.SetKeys();                    
                    keys[i].Hide();
                }
            }

            for (int i = 0; i < foods.Count; i++)
            {
                if (foods[i].CollisionsWithArround(player))
                {
                    player.SetLife(player.GetLife() + 100);
                    foods[i].UseFood(currentLevel, foods[i].GetX(), foods[i].GetY());
                    foods[i].Hide();
                }
               
            }

            for (int i = 0; i < doors.Count; i++)
            {
                int xInLevel = (doors[i].GetX() - currentLevel.GetLeftMargin()) / currentLevel.GetTileWidth();
                int yInLevel = (doors[i].GetY() - currentLevel.GetTopMargin()) / currentLevel.GetTileHeight();

                if (doors[i].CollisionsWithArround(player))
                {
                    doors[i].Hide();
                    if (player.GetKeys() > 0)
                    {
                        player.UseKeys();

                        doors[i].OpenDoor(currentLevel, doors[i].GetX(), doors[i].GetY());

                        doors[i].Hide();

                        score += 100;     
                    }                    
                }
            }
        }

        // Generates enemies
        public void GenerateEnemy()
        {
            Enemy enemy;
            Random rnd = new Random();
            if (time % 5 == 0 && time != 0)
            {
                enemy = new Enemy(rnd.Next(200, 800), rnd.Next(50, 600), this);
                enemies.Add(enemy);
            }
        }
        
        // This method returns player
        public Player GetPlayer()
        {
            return player;
        }

        public void CheckLife()
        {
            //cheking life player

            if (player.GetLife() < 0)
            {
                finished = true;
            }


            // lose life for enemy
            for (int i = 0; i < numEnemies; i++)
                if (enemies[i].CollisionsWith(player))
                    player.SetLife(player.GetLife() - 100);

            //lose life for second
            if (countLife % 30 == 0)
            {
                player.SetLife(player.GetLife() - 1);
                countLife = 0;
            }
            countLife++;
        }

        public void PauseTillNextFrame()
        {
            // Pause till next frame (20 ms = 50 fps)
            Hardware.Pause(20);
        }

        // Check for valid move
        public bool IsValidMove(int xMin, int yMin, int xMax, int yMax)
        {
            return currentLevel.IsValidMove(xMin, yMin, xMax, yMax);
        }

        // Calculate the current time
        public void Timer()
        {
            current = DateTime.Now;
            TimeSpan dif = current - start;
            time = dif.Seconds;
            //Console.WriteLine(time);
        }

        public void Run()
        {

            // Game Loop
            while (!finished)
            {
                DrawElements();
                GenerateEnemy();
                CheckKeys();
                MoveElements();
                CheckCollisions();
                Timer();
                CheckLife();
                PauseTillNextFrame();
            }
        }
    }
}
