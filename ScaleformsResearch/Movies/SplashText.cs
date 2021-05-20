using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ScaleformsResearch.Movies
{
    internal class SplashText : Movie
    {
        public override string MovieName => "SPLASH_TEXT";

        public void SetSplashText(string txt, int duration, Color color) => CallFunction("SET_SPLASH_TEXT", txt, duration, color.R, color.G, color.B, color.A);
        public void TransitionIn(int duration, bool managed) => CallFunction("SPLASH_TEXT_TRANSITION_IN", duration, managed);

        protected override void OnTestStart()
        {
            SetSplashText("Splash Text", 5000, Color.LimeGreen);
            TransitionIn(5000, false);
        }
    }
}
