namespace DamGame
{
    class WelcomeScreen
    {
        public enum options { Play, Credits, Quit };
        private options optionChosen;

        public void Run()
        {
            Font font18 = new Font("data/Joystix.ttf", 18);
            Image player = new Image("data/Images/VAL_LEFT1.png");

            bool validOptionChosen = false;

            do
            {
                Hardware.ScrollTo(0 , 0);
                //Centering scroll to the character

                Hardware.ClearScreen();
                Hardware.WriteHiddenText("P to Play, Q to Quit",
                    40, 10,
                    0xCC, 0xCC, 0xCC,
                    font18);
                Hardware.DrawHiddenImage(player, 512, 384);
                Hardware.ShowHiddenScreen();
            
                if (Hardware.KeyPressed(Hardware.KEY_P))
                {
                    validOptionChosen = true;
                    optionChosen = options.Play;
                }
                if (Hardware.KeyPressed(Hardware.KEY_Q))
                {
                    validOptionChosen = true;
                    optionChosen = options.Quit;
                }
                Hardware.Pause(50);
            }
            while (!validOptionChosen);
        }

        public options GetOptionChosen()
        {
            return optionChosen;
        }


    }
}
