using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    class BlimpText : Movie
    {
        public override string MovieName => "BLIMP_TEXT";

        string message = "";
        float scrollSpeed = 100;
        HudColor color = HudColor.PureWhite;

        public string Message { get => message; set { message = value; CallFunction("SET_MESSAGE", message); } }
        public float ScrollSpeed { get => scrollSpeed; set { scrollSpeed = value; CallFunction("SET_SCROLL_SPEED", scrollSpeed); Message = Message; } }
        public HudColor MessageColor { get => color; set { color = value; CallFunction("SET_COLOUR", (int)color); } }


        protected override void OnTestTick()
        {
            base.OnTestTick();
            if (Game.IsKeyDown(Keys.NumPad1))
            {
                Message = Util.Phrases.Random();
            }
            else
            if (Game.IsKeyDown(Keys.NumPad2))
            {
                MessageColor = Util.EnumValues<HudColor>().Random();
            }
            else
            if (Game.IsKeyDown(Keys.NumPad6))
            {
                ScrollSpeed += 100;
            }
            else
            if (Game.IsKeyDown(Keys.NumPad3))
            {
                ScrollSpeed -= 100;
            }
        }
        protected override string TestHelpMessage => $"~y~{Keys.NumPad1}~s~ - Randomize Message~n~~y~{Keys.NumPad2}~s~ - Randomize Message Color ({MessageColor})~n~~y~NumPad6/3~s~ - Scroll Speed ({ScrollSpeed})";
    }
}
