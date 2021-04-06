using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class PsychologyReport : LetterScraps
    {
        public override string MovieName => "PSYCHOLOGY_REPORT";

        public void SetPlayerName(string gamerTitle, string gamerTag, string crewtag)
        {
            CallFunction("SET_PLAYER_NAME", gamerTitle, gamerTag, crewtag);
        }

        protected override void OnTestStart()
        {
            base.OnTestStart();
            SetPlayerName("Gamer Title", "Vincentsgm", "SWAT");
        }
    }
}
