using DamGame;

class Food : Sprite
{
    public Food(int newX, int newY)
    {
        LoadSequence(LEFT,
            new string[] { "data/Images/GHOST_DOWN1.png" });

        ChangeDirection(LEFT);
        x = newX;
        y = newY;
        width = 16;
        height = 16;
    }


    public void UseFood (Level myLevel, int x, int y)
    {
        int xInLevel = (x - myLevel.GetLeftMargin()) / myLevel.GetTileWidth();// operation inverse for calculate col o row in level
        int yInLevel = (y - myLevel.GetTopMargin()) / myLevel.GetTileHeight();
        
        myLevel.SetSpacePosition(yInLevel, xInLevel);
    }


     void DestroiFood()
     {

     }
 }
    