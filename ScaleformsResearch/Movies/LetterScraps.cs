using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class LetterScraps : Movie
    {
        public override string MovieName => "LETTER_SCRAPS";

        public string Text { set => CallFunction("SET_LETTER_TEXT", value); }
        public void AddText(string text) => CallFunction("ADD_TO_LETTER_TEXT", text);
        private bool bgVisibility;
        public bool BackgroundVisibility
        {
            get => bgVisibility;
            set
            {
                bgVisibility = value;
                CallFunction("SET_BG_VISIBILITY", bgVisibility);
            }
        }

        protected override void OnTestStart()
        {
            Text = "Fill the text.";
        }

        protected override void OnTestTick()
        {
            if (Game.IsKeyDown(Keys.NumPad1)) AddText(Util.Random(Util.Phrases));
            else if (Game.IsKeyDown(Keys.NumPad2)) BackgroundVisibility = !BackgroundVisibility;
        }

        protected override string TestHelpMessage => "Numpad1: Add sentences\n" +
            "Numpad2: Invert background visibility";
    }
}
