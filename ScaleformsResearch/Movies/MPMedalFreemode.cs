using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class MPMedalFreemode : MPAwardBase
    {
        public override string MovieName => "MP_MEDAL_FREEMODE";

        protected override void OnTestStart()
        {
            //CallFunction("debug");
            ShowAwardAndMessage("Award title", "Award description", "", "", "Description 2", colEnum.col1, "Description 3");
        }
    }
}
