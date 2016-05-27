
using DamGame;

class Door : Sprite
{
    public Door(int newX, int newY, char c)//c for door orientation 
    {
        if(c == 'V')
            LoadSequence(LEFT,
                new string[] { "data/Images/DoorV.png" });
        else
            LoadSequence(LEFT,
                new string[] { "data/Images/DoorH.png" });

        ChangeDirection(LEFT);
        x = newX;
        y = newY;
        width = 16;
        height = 16;
    }


    public void OpenDoor(Level myLevel,int x, int y)
    {
        int xInLevel = (x - myLevel.GetLeftMargin()) / myLevel.GetTileWidth();// operation inverse for calculate col o row in level
        int yInLevel = (y - myLevel.GetTopMargin()) / myLevel.GetTileHeight();

        myLevel.SetSpacePosition(yInLevel, xInLevel);

        if (myLevel.GetLevelDescription(xInLevel, yInLevel + 1) == '[')
            OpenDoorRec(myLevel, xInLevel, yInLevel + 1);

        if (myLevel.GetLevelDescription(xInLevel, yInLevel - 1) == '[')
            OpenDoorRec(myLevel, xInLevel, yInLevel - 1);

        if (myLevel.GetLevelDescription(xInLevel + 1, yInLevel) == '_')
            OpenDoorRec(myLevel, xInLevel + 1, yInLevel);

        if (myLevel.GetLevelDescription(xInLevel - 1, yInLevel) == '_')
            OpenDoorRec(myLevel, xInLevel + 1, yInLevel);

    }

    void OpenDoorRec (Level myLevel, int x, int y)
    {
        myLevel.SetSpacePosition(y, x);

        if (myLevel.GetLevelDescription(x, y + 1) == '[')
            OpenDoorRec(myLevel, x, y + 1);

        if (myLevel.GetLevelDescription(x, y - 1) == '[')
            OpenDoorRec(myLevel, x, y - 1);

        if (myLevel.GetLevelDescription(x + 1, y) == '_')
            OpenDoorRec(myLevel, x + 1, y);

        if (myLevel.GetLevelDescription(x - 1, y) == '_')
            OpenDoorRec(myLevel, x - 1, y);

    }
}

    