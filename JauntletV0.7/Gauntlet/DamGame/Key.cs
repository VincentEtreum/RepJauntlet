﻿class Key : Sprite
{
    public Key(int newX, int newY)
    {
        LoadSequence(LEFT,
            new string[] { "data/Images/ONEKEY.png"});
            
        ChangeDirection(LEFT);
        x = newX;
        y = newY;
        width = 16;
        height = 16;
    }
}

    