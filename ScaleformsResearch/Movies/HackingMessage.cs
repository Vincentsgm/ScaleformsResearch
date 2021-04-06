using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class HackingMessage : Movie
    {
        public override string MovieName => "HACKING_MESSAGE";

        public void SetDisplay(int unlockId, string title, string message, Color color, bool stagePassed) => CallFunction("SET_DISPLAY", unlockId, title, message, color.R, color.G, color.B, stagePassed);

        int t_stage;
        protected override void OnTestStart()
        {
            SetDisplay(0, "Title", "Message", Color.Blue, false);
        }

        protected override void OnTestTick()
        {
            if (Game.IsKeyDown(Keys.NumPad1))
            {
                SetDisplay(1, "Stage passed", "Stage 1 complete", Color.Blue, true);
                new Sound(-1).PlayFrontend("Goal", "DLC_HEIST_HACKING_SNAKE_SOUNDS", true);
            }
            else if (Game.IsKeyDown(Keys.NumPad2))
            {
                SetDisplay(2, "Stage passed", "Stage 2 complete", Color.Blue, true);
                new Sound(-1).PlayFrontend("Goal", "DLC_HEIST_HACKING_SNAKE_SOUNDS", true);
            }
            else if (Game.IsKeyDown(Keys.NumPad3))
            {
                SetDisplay(3, "Stage passed", "Stage 3 complete", Color.Blue, true);
                new Sound(-1).PlayFrontend("Goal", "DLC_HEIST_HACKING_SNAKE_SOUNDS", true);
            }
            else if (Game.IsKeyDown(Keys.NumPad4))
            {
                SetDisplay(4, "SUCCESS", "Hack complete", Color.Green, true);
                new Sound(-1).PlayFrontend("Success", "DLC_HEIST_HACKING_SNAKE_SOUNDS", true);
            }
        }

        protected override string TestHelpMessage => "Numpad1/2/3/4: unlock stage";
    }

}
