using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class MPGamerInfo : Movie
    {
        public override string MovieName => "MP_GAMER_INFO";

        public void SetGamerNameAndCrewTag(string gamerName, string crewTag) => CallFunction("SET_GAMERNAME_AND_PACKED_CREW_TAG", gamerName, crewTag);

        protected override void OnTestStart()
        {
            SetGamerNameAndCrewTag("Vincentsgm", "SWAT");
        }
    }
}
