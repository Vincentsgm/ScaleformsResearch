using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    class BreakingNews : Movie
    {
        public override string MovieName => "BREAKING_NEWS";

        private string title = "", subtitle = "";
        private StaticType staticType = StaticType.None;

        public string Title { get => title; set { title = value; CallFunction("SET_TEXT", title, subtitle); } }
        public string Subtitle { get => subtitle; set { subtitle = value; CallFunction("SET_TEXT", title, subtitle); } }
        public StaticType Static { get => staticType; set { staticType = value; CallFunction("SHOW_STATIC", (int)staticType); } }

        protected override void OnTestTick()
        {
            base.OnTestTick();
            if (Game.IsKeyDown(Keys.NumPad1))
            {
                Title = Util.Phrases.Random();
            }
            else
            if (Game.IsKeyDown(Keys.NumPad2))
            {
                Subtitle = Util.Phrases.Random();
            }
            else
            if (Game.IsKeyDown(Keys.NumPad4))
            {
                Static = StaticType.None;
            }
            else
            if (Game.IsKeyDown(Keys.NumPad5))
            {
                Static = StaticType.Noise;
            }
            else
            if (Game.IsKeyDown(Keys.NumPad6))
            {
                Static = StaticType.Blue;
            }
        }
        protected override string TestHelpMessage => $"~y~{Keys.NumPad1}~s~ - Randomize Title~n~~y~{Keys.NumPad2}~s~ - Randomize Subtitle~n~~y~NumPad4/5/6~s~ - Static [None/Noise/Blue] ({staticType})";

        public enum StaticType
        {
            None = -1,
            Noise = 0,
            Blue = 1,
        }
    }
}
