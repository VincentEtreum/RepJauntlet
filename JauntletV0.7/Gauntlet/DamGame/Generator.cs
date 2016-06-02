using System.Collections.Generic;

namespace DamGame
{
    class Generator : Enemy
    {
        
        public Generator(int newX, int newY, Game game) : base (newX, newY, game)
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

        public bool ArroundGhost(List<Generator> myGenerator ,List<Enemy> myEnemies)
        {
            for (int i= 0; i < myEnemies.Count; i++)
            {
                for (int j = 0; j < myGenerator.Count; j++)
                {
                    if (myGenerator[j].CollisionsWithArround(myEnemies[i]))
                        return false;
                }
            }

            return true;
        }

    }
}
