using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    public class Stage : Movie
    {
        public override string MovieName => "STAGE";

        private string text = "";

        public string Text { get { return text; } set { text = value; CallFunction("SET_STAGE_TEXT", text); } }

        protected override void OnTestTick()
        {
            base.OnTestTick();
            if (Game.IsKeyDown(Keys.NumPad1))
            {
                Text = Util.Phrases.Random();
            }
        }
        protected override string TestHelpMessage => $"~y~{Keys.NumPad1}~s~ - Randomize Text";
    }
}