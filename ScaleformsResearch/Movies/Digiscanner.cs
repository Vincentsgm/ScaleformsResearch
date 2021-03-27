using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    class Digiscanner : Movie
    {
        public override string MovieName => "DIGISCANNER";

        int distance = 0;
        public int Distance { get => distance; set { distance = value.Clamp(-10, 10); CallFunction("SET_DISTANCE", distance * 10); } }

        public void SetColor() => CallFunction("SET_COLOUR");

        protected override void OnTestTick()
        {
            base.OnTestTick();
            if (Game.IsKeyDown(Keys.NumPad1))
            {
                Distance -= 1;
            }
            else
            if (Game.IsKeyDown(Keys.NumPad4))
            {
                Distance += 1;
            }
            else
            if (Game.IsKeyDown(Keys.NumPad0))
            {
                SetColor();
            }
        }

        protected override void TestDraw()
        {
            Draw2D(0.5f, 0.5f, 0.4f, 1f);
        }

        protected override string TestHelpMessage => $"~y~NumPad1/4~s~ - Edit Distance ({Distance})~n~~y~NumPad0~s~ - Set Color";
    }
}
