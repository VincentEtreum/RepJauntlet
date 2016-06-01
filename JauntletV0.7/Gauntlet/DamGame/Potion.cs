namespace DamGame
{
    class Potion : Sprite
    {
        Potion(int newX, int newY)
        {
            LoadSequence(LEFT,
                new string[] { "data/Images/GHOST_LEFT1.png" });
            
            ChangeDirection(LEFT);
            x = newX;
            y = newY;
            width = 16;
            height = 16;
        }

        void UsePotion()
        {

        }


        void DestroiPotion()
        {

        }
    }
}
