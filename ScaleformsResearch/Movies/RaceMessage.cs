using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class RaceMessage : Movie
    {
        public override string MovieName => "RACE_MESSAGE";

        public void SetRaceMessage(string titleText, string strapText, int iconID) => CallFunction("SET_RACE_MESSAGE", titleText, strapText, iconID);

        private bool visibility;
        public bool Visibility
        {
            get => visibility;
            set
            {
                visibility = value;
                CallFunction("SET_MESSAGE_VISIBILITY", visibility);
            }
        }

        public int Duration { set => CallFunction("OVERRIDE_DURATION", Math.Max(0, value)); }

        public void RemoveMessage() => CallFunction("REMOVE_MESSAGE");

        protected override void OnTestStart()
        {
            Visibility = true;
            Duration = 3000;
            SetRaceMessage("Race Message Title", "Strap text", 0);
        }

        protected override void OnTestTick()
        {
            if (Game.IsKeyDown(Keys.NumPad1)) Visibility = !Visibility;
            else if (Game.IsKeyDown(Keys.NumPad2)) RemoveMessage();
        }

        protected override string TestHelpMessage => "Numpad1: invert visibility\n" +
            "Numpad2: remove message";

    }
}
