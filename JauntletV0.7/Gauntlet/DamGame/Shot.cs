/// <summary>
/// Part of DamGame (Princess of Sanvi: a game by students of
/// Multiplaftorm Applications Development at IES San Vicente)
/// 
///  Shot.cs: a shot by the player
///  @author Nacho Cabanes
/// </summary>

/* --------------------------------------------------         
   Versions history
   
   Num.   Date        By / Changes
   ---------------------------------------------------
   0.09  15-Apr-2016  Miguel Moya and Gonzalo García Soler, minor corrections by Nacho: 
                        Added a new class Shot for shooting
 ---------------------------------------------------- */

namespace DamGame
{

    class Shot : Sprite
    {
        
        protected Level myLevel;

        public Shot(Level l, int x, int y, int xSpeed, int ySpeed)
        {
            LoadSequence(LEFT,
                new string[] { "data/Images/arrowL.png" });
            LoadSequence(RIGHT,
                new string[] { "data/Images/arrowR.png" });
            LoadSequence(DOWN,
               new string[] { "data/Images/arrowD.png" });
            LoadSequence(UP,
                new string[] { "data/Images/arrowU.png" });


            this.x = x;
            this.y = y;
            this.xSpeed = xSpeed;
            this.ySpeed = ySpeed;

            if (xSpeed > 0)
                currentDirection = RIGHT;
            else if (xSpeed < 0)
                currentDirection = LEFT;
            else if (ySpeed > 0)
                currentDirection = DOWN;
            else
                currentDirection = UP;

            width = 16;
            height = 16;
            myLevel = l;
        }

        public override void Move()
        {
            if (!visible)
                return;

            if ((myLevel.IsValidMove(x + xSpeed, y, x + width + xSpeed, y + height))
                && (x > 0) && (x< 1024))
                // TO DO: Avoid magic number 1024
            {
                x += xSpeed;
                y += ySpeed;
            }
            else
                Hide();
        }
    }
}