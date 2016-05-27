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


                Hardware.WriteHiddenText(" Key:           Action:",
                    40, 40,
                    0xCC, 0xCC, 0xCC,
                    font18);
                Hardware.WriteHiddenText("W or UP         Move Up",
                    40, 60,
                    0xCC, 0xCC, 0xCC,
                    font18);
                Hardware.WriteHiddenText("S or Down       Move Down",
                    40, 80,
                    0xCC, 0xCC, 0xCC,
                    font18);
                Hardware.WriteHiddenText("D  or Right     Move Right",
                    40, 100,
                    0xCC, 0xCC, 0xCC,
                    font18);
                Hardware.WriteHiddenText("A or Left       Move Left",
                    40, 120,
                    0xCC, 0xCC, 0xCC,
                    font18);
                Hardware.WriteHiddenText("Space           Shot",
                    40, 140,
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
