using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    class Drilling : Movie
    {
        public override string MovieName => "DRILLING";

        private float speed = 0, depth = 0, temp = 0;

        public float Speed { get => speed; set { speed = value.Clamp(0, 1); CallFunction("SET_SPEED", speed); } }
        public float Depth { get => depth; set { depth = value.Clamp(0, 1); CallFunction("SET_DEPTH", depth); } }
        public float Temperature { get => temp; set { temp = value.Clamp(0, 1); CallFunction("SET_TEMPERATURE", temp); } }

        protected override void OnTestTick()
        {
            base.OnTestTick();
            if (Game.IsKeyDown(Keys.NumPad4))
            {
                Speed += 0.1f;
            }
            else if (Game.IsKeyDown(Keys.NumPad1))
            {
                Speed -= 0.1f;
            }
            else if (Game.IsKeyDown(Keys.NumPad5))
            {
                Depth += 0.1f;
            }
            else if (Game.IsKeyDown(Keys.NumPad2))
            {
                Depth -= 0.1f;
            }
            else if (Game.IsKeyDown(Keys.NumPad6))
            {
                Temperature += 0.1f;
            }
            else if (Game.IsKeyDown(Keys.NumPad3))
            {
                Temperature -= 0.1f;
            }
        }
        protected override string TestHelpMessage => $"~y~Num1/4~s~ - Speed ({Speed:0.0})~n~~y~Num2/5~s~ - Depth ({Depth:0.0})~n~~y~Num3/6~s~ - Temperature ({Temperature:0.0})~n~";
    }
}
