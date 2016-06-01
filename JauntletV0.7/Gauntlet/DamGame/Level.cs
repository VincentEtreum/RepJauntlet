namespace DamGame
{
    class Level
    {
        byte tileWidth, tileHeight;
        byte levelWidth, levelHeight;
        byte leftMargin, topMargin;
        string[] levelDescription;

        Image floor, wallEndDown, wallEndLeft, wallEndRight, wallEndUp, 
                wallHorizontal, wallVertical, endScreen, key, doorVertical, doorHorizontal,
                food, generator;

        public Level()
        {
            tileWidth = 16;
            tileHeight = 16;
            levelWidth = 50;
            levelHeight = 40;
            leftMargin = 80;
            topMargin = 50;

            // 0 = Empty, 1 = floor, 2 = wallEndDown, 3 = wallEndLeft, 4 = wallEndRight
            // 5 = wallEndUp, 6= wallHorizontal, 7 = wallVertical, Q = key , [ = doorVertical
            // _ = doorHorzontal F= food, G= Generator

            levelDescription = new string[40]
            {
                "--------------------------------------------------",
                "|           Q                                    |",
                "|  <--->   <--->   <--->   <--->   <--->   <---> |",
                "|                                                |",
                "|    ^  Q    ^      Q^       ^       ^       ^   |",
                "|    |       |       |       |       |       |   |",
                "|____v       v       v       v       v       v   |",
                "|F   [                                           |",
                "|F   [                          G                |",
                "|    [                   Q                       |",
                "|    [                                           |",
                "|    [                                           |",
                "|__<--->   <--->   <--->   <--->   <--->   <---> |",
                "|                                                |",
                "|    ^       ^       ^       ^       ^       ^   |",
                "|    |       |       |       |    G  |       |   |",
                "|    v       v       v       v       v       v   |",
                "|                                                |",
                "|                                                |",
                "|        G               G                       |",
                "|                                                |",
                "|                                                |",
                "|  <--->   <--->   <--->   <--->   <--->   <---> |",
                "|                                                |",
                "|    ^       ^       ^       ^       ^       ^   |",
                "|    |       |       |       |       |       |   |",
                "|    v       v       v       v       v       v   |",
                "|                                                |",
                "|                                                |",
                "|                                                |",
                "|                                                |",
                "|                                                |",
                "|  <--->   <--->   <--->   <--->   <--->   <---> |",
                "|                                                |",
                "|    ^       ^       ^       ^       ^       ^   |",
                "|    |       |       |       |       |       |   |",
                "|    v       v       v       v       v       v   |",
                "|                                                |",
                "|                                                |",
                "--------------------------------------------------",
            };

            floor = new Image("data\\images\\FLOOR.png");
            wallEndDown= new Image("data\\images\\WALL_END_DOWN.png");
            wallEndLeft = new Image("data\\images\\WALL_END_LEFT.png");
            wallEndRight = new Image("data\\images\\WALL_END_RIGHT.png");
            wallEndUp = new Image("data\\images\\WALL_END_UP.png");
            wallHorizontal = new Image("data\\images\\WALL_HORIZONTAL.png");
            wallVertical = new Image("data\\images\\WALL_VERTICAL.png");
            doorVertical = new Image("data\\images\\DoorV.png");
            doorHorizontal = new Image("data\\images\\DoorH.png");
            key = new Image("data\\images\\ONEKEY.png");
            food = new Image("data\\images\\FOOD.png");
            generator = new Image("data\\images\\GENERADOR_GHOST.png");
        }
        
        public void DrawOnHiddenScreen()
        {
            for (int row = 0; row < levelHeight; row++)
                for (int col = 0; col < levelWidth; col++)
                {
                    int xPos = leftMargin + col * tileWidth;
                    int yPos = topMargin + row * tileHeight;
                    switch (levelDescription[row][col])
                    {

                        // 0 = Empty, " " = floor, v = wallEndDown, < = wallEndLeft, > = wallEndRight
                        // ^ = wallEndUp, - = wallHorizontal, | = wallVertical Q = key, [ = doorVertical
                        // _ = doorHorzontal F= food

                        case ' ': Hardware.DrawHiddenImage(floor, xPos, yPos); break;
                        case 'v': Hardware.DrawHiddenImage(wallEndDown, xPos, yPos); break;
                        case '<': Hardware.DrawHiddenImage(wallEndLeft, xPos, yPos); break;
                        case '>': Hardware.DrawHiddenImage(wallEndRight, xPos, yPos); break;
                        case '^': Hardware.DrawHiddenImage(wallEndUp, xPos, yPos); break;
                        case '-': Hardware.DrawHiddenImage(wallHorizontal, xPos, yPos); break;
                        case '|': Hardware.DrawHiddenImage(wallVertical, xPos, yPos); break;
                        case 'Q': Hardware.DrawHiddenImage(key, xPos, yPos); break;
                        case '[': Hardware.DrawHiddenImage(doorVertical, xPos, yPos); break;
                        case '_': Hardware.DrawHiddenImage(doorHorizontal, xPos, yPos); break;
                        case 'F': Hardware.DrawHiddenImage(food, xPos, yPos); break;
                        case 'G': Hardware.DrawHiddenImage(generator, xPos, yPos); break;


                    }
                }
        }

        public bool IsValidMove(int xMin, int yMin, int xMax, int yMax)
        {
            for (int row = 0; row < levelHeight; row++)
                for (int col = 0; col < levelWidth; col++)
                {
                    char tileType = levelDescription[row][col];
                    // If we don't need to check collisions with this tile, we skip it
                    if (tileType == ' ' || tileType == 'F')  // Empty space or Food
                        continue;
                    // Otherwise, lets calculate its corners and check rectangular collisions
                    int xPos = leftMargin + col * tileWidth;
                    int yPos = topMargin + row * tileHeight;
                    int xLimit = leftMargin + (col+1) * tileWidth;
                    int yLimit = topMargin + (row+1) * tileHeight;

                    if (Sprite.CheckCollisions(
                            xMin, yMin, xMax, yMax,  // Coords of the sprite
                            xPos, yPos, xLimit, yLimit)) // Coords of current tile
                        return false;
                    }
            // If we have not collided with anything... then we can move
            return true;
        }


        public int GetTileWidth()
        {
            return tileWidth;
        }

        public int GetTileHeight()
        {
            return tileHeight;
        }

        public int GetLevelWidth()
        {
            return levelWidth;
        }

        public int GetlevelHeight()
        {
            return levelHeight;
        }

        public int GetLeftMargin()
        {
            return leftMargin;
        }

        public int GetTopMargin()
        {
            return topMargin;
        }

        public char GetLevelDescription(int x, int y)
        {
            return levelDescription[y][x];
        }

        public string[] GetLevelDescription()
        {
            return levelDescription;
        }

        public void SetSpacePosition(int x, int y)
        {
            levelDescription[x] = levelDescription[x].Remove(y, 1).Insert(y, " ");
        }

    }
}
