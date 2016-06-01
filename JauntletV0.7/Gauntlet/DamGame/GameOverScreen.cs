using System;
using System.Collections.Generic;
using System.IO;

namespace DamGame
{
    class GameOverScreen
    {
        public void Run()
        {
            Font font18 = new Font("data/Joystix.ttf", 18);
            Image player = new Image("data/Images/VAL_LEFT1.png");
            string[] scores = new string[10];

            if (File.Exists("score.txt"))
            {
                try
                    {
                        StreamReader file = File.OpenText("score.txt");
                    string line;
                    int count = 0; ;

                    do
                    {

                        line = file.ReadLine();
                    
                        if (line != null && count < 10)
                        {
                            scores[count] = line;
                        }

                        count++;

                    } while (line != null);

                }
                catch (PathTooLongException)
                {
                    
                        Hardware.WriteHiddenText("ERROR WITH SCORES",
                        40, 50,
                        0xCC, 0xCC, 0xCC,
                        font18);

                        
                }
                catch (IOException ex)
                {
                    Hardware.WriteHiddenText("ERROR WITH SCORES",
                        40, 50,
                        0xCC, 0xCC, 0xCC,
                        font18);
                }
                catch (Exception ex)
                {
                    Hardware.WriteHiddenText("ERROR WITH SCORES",
                         40, 50,
                         0xCC, 0xCC, 0xCC,
                         font18);
                }



        }
            else
            {
                StreamWriter file = File.CreateText("score.txt");

                file.WriteLine("--NAME-- --SCORE--");
                file.WriteLine("-VINCENT ----10000");
                file.WriteLine("-VINCENT ----10000");
                file.WriteLine("-VINCENT ----10000");
                file.WriteLine("-VINCENT ----10000");
                file.WriteLine("-VINCENT ----10000");
                file.WriteLine("-VINCENT ----10000");
                file.WriteLine("-VINCENT ----10000");
                file.WriteLine("-VINCENT ----10000");
                file.WriteLine("-VINCENT ----10000");


                file.Close();
            }

            
            
            do
            {
                short positionScore = 50;

                Hardware.ScrollTo(0 , 0);
                //Centering scroll to the character

                Hardware.ClearScreen();
                Hardware.WriteHiddenText("Bye! Press Q to return to Operating System...",
                    40, 10,
                    0xCC, 0xCC, 0xCC,
                    font18);

                

                for (int i = 0; i < scores.Length; i++)
                {
                    Hardware.WriteHiddenText(scores[i],
                    40, positionScore,
                    0xCC, 0xCC, 0xCC,
                    font18);

                    positionScore += 20;
                }


                Hardware.DrawHiddenImage(player, 512, 384);
                Hardware.ShowHiddenScreen();

                Hardware.Pause(50);
            }
            while (!Hardware.KeyPressed(Hardware.KEY_Q) );
        }
    }
}
