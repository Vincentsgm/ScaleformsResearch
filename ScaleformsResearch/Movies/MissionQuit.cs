using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class MissionQuit : Movie
    {
        public override string MovieName => "MISSION_QUIT";

        public void SetText(string text, string copy) => CallFunction("SET_TEXT", text, copy);

        public void TransitionIn(int duration) => CallFunction("TRANSITION_IN", duration);
        public void TransitionOut(int duration) => CallFunction("TRANSITION_OUT", duration);

        protected override void OnTestStart()
        {
            SetText("Mission aborted", "We'll get em next time!");
            new Sound(-1).PlayFrontend("ScreenFlash", "MissionFailedSounds");
        }

        protected override void OnTestTick()
        {
            if (Game.IsKeyDown(Keys.NumPad1)) TransitionIn(1000);
            else if (Game.IsKeyDown(Keys.NumPad2)) TransitionOut(1000);
        }

        protected override string TestHelpMessage => "Numpad1/2: show/hide message";
    }
}
