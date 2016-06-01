namespace DamGame
{
    class Generator : Enemy
    {
        
        public Generator(int newX, int newY) : base (newX, newY)
        {
            LoadSequence(LEFT,
                new string[] { "data/Images/GENERADOR_GHOST.png" });
            x = newX;
            y = newY;

            width = 16;
            height = 16;
            life = 5;
        }

        public void GenerateGhost()
        {
            //TODO
        }

        public void DestroiGenerator(Level myLevel, int x, int y)
        {
            int xInLevel = (x - myLevel.GetLeftMargin()) / myLevel.GetTileWidth();// operation inverse for calculate col o row in level
            int yInLevel = (y - myLevel.GetTopMargin()) / myLevel.GetTileHeight();

            myLevel.SetSpacePosition(yInLevel, xInLevel);
        }

    }
}
