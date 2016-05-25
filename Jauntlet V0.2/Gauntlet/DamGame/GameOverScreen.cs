namespace DamGame
{
    class GameOverScreen
    {
        public void Run()
        {
            Font font18 = new Font("data/Joystix.ttf", 18);
            Image player = new Image("data/Images/VAL_LEFT1.png");

            do
            {
                Hardware.ScrollTo(0 , 0);
                //Centering scroll to the character

                Hardware.ClearScreen();
                Hardware.WriteHiddenText("Bye! Press Q to return to Operating System...",
                    40, 10,
                    0xCC, 0xCC, 0xCC,
                    font18);
                Hardware.DrawHiddenImage(player, 512, 384);
                Hardware.ShowHiddenScreen();

                Hardware.Pause(50);
            }
            while (!Hardware.KeyPressed(Hardware.KEY_Q) );
        }
    }
}
