﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SwinGameSDK;

namespace MyGame.src
{

    internal static partial class EndingGameController
    {

        /// <summary>
        /// Draw the end of the game screen, shows the win/lose state
        /// </summary>
        public static void DrawEndOfGame()
        {
            var toDraw = default(Rectangle);
            string whatShouldIPrint;
            UtilityFunctions.DrawField(GameController.ComputerPlayer.PlayerGrid, GameController.ComputerPlayer, true);
            UtilityFunctions.DrawSmallField(GameController.HumanPlayer.PlayerGrid, GameController.HumanPlayer);
            toDraw.X = 0;
            toDraw.Y = 250;
            toDraw.Width = SwinGame.ScreenWidth();
            toDraw.Height = SwinGame.ScreenHeight();
            if ((int)SwinGame.TimerTicks(GameController.GameTimer) <= 5500)
            {
                whatShouldIPrint = "OUT OF TIME!";
            }
            else if (GameController.HumanPlayer.IsDestroyed)
            {
                whatShouldIPrint = "YOU LOSE!";
            }
            else
            {
                whatShouldIPrint = "-- WINNER --";
            }

            SwinGame.DrawText(whatShouldIPrint, Color.White, Color.Transparent, GameResources.GameFont("ArialLarge"), FontAlignment.AlignCenter, toDraw);
        }

        /// <summary>
        /// Handle the input during the end of the game. Any interaction
        /// will result in it reading in the highsSwinGame.
        /// </summary>
        public static void HandleEndOfGameInput()
        {
            if (SwinGame.MouseClicked(MouseButton.LeftButton) || SwinGame.KeyTyped(KeyCode.ReturnKey) || SwinGame.KeyTyped(KeyCode.EscapeKey))

            {
                HighScoreController.ReadHighScore(GameController.HumanPlayer.Score);
               GameController.EndCurrentState();
            }
        }
    }
}
