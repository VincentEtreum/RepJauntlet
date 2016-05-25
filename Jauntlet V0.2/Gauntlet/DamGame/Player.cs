using System;

namespace DamGame
{
    class Player : Sprite
    {
        int life;
        int attack;
        int keys;

        public Player()
        {
            LoadSequence(RIGHT, new string[] { "data/Images/VAL_RIGHT1.png", "data/Images/VAL_RIGHT2.png", "data/Images/VAL_RIGHT3.png" }) ;
            LoadSequence(LEFT, new string[] { "data/Images/VAL_LEFT1.png", "data/Images/VAL_LEFT2.png", "data/Images/VAL_LEFT3.png" });
            LoadSequence(UP, new string[] { "data/Images/VAL_UP1.png", "data/Images/VAL_UP2.png", "data/Images/VAL_UP3.png" });
            LoadSequence(DOWN, new string[] { "data/Images/VAL_DOWN1.png", "data/Images/VAL_DOWN2.png", "data/Images/VAL_DOWN3.png" });
            ChangeDirection(LEFT);

            x = 138;
            y = 138;
            xSpeed = 4;
            ySpeed = 4;
            width = 14;
            height = 14;

            life = 2000;
            attack = 4;
        }

        public void LifeDown()
        {
            life--;
        }

        public void LifeDown(int Damage)
        {
            life-=Damage;
        }



        public void MoveRight()
        {
            x += xSpeed;
            ChangeDirection(RIGHT);
            NextFrame();
        }

        public void MoveLeft()
        {
            x -= xSpeed;
            ChangeDirection(LEFT);
            NextFrame();
        }

        public void MoveUp()
        {
            y -= ySpeed;
            ChangeDirection(UP);
            NextFrame();
        }

        public void MoveDown()
        {
            y += ySpeed;
            ChangeDirection(DOWN);
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

        public void SetAttack(int atack)
        {
            this.attack = atack;
        }

        public int GetAttack()
        {
            return attack;
        }

        public void SetKeys()
        {
            if(keys < 10)
                this.keys++;
        }

        public void UseKeys()
        {
                this.keys--;
        }

        public int GetKeys()
        {
            return keys;
        }
    }
}
