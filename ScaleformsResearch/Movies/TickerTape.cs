using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    //This scaleform does not seem to do anything
    internal class TickerTape : Movie
    {
        public override string MovieName => "TICKERTAPE";

        public string TickerText { set => CallFunction("SET_TICKER_TEXT", 1f, value); }

        protected override void OnTestStart()
        {
            base.OnTestStart();
            TickerText = "Test";
        }
    }
}
