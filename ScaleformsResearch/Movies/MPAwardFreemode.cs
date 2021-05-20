using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class MPAwardFreemode : MPAwardBase
    {
        public override string MovieName => "MP_AWARD_FREEMODE";

        public void Reset() => CallFunction("RESET_AWARDS_MOVIE");
        public new void ShowAwardAndMessage(string awTitle, string awDesc, string txd, string texture, string awDesc2, colEnum col, string awDesc3) => CallFunction("SHOW_AWARD_AND_MESSAGE", awTitle, awDesc, txd, texture, awDesc2, (int)col, awDesc3);

        protected override void OnTestStart()
        {
            //CallFunction("debug");
            ShowAwardAndMessage("Award title", "Award description", "", "", "Description 2", colEnum.col1, "Description 3");
        }
    }
}
