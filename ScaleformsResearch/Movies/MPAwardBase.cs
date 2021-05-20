using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class MPAwardBase : Movie
    {
        public override string MovieName => "MP_AWARD_BASE";

        public enum colEnum
        {
            col1 = 107,
            col2 = 108,
            col3 = 109,
            col4 = 110
        };
        public void ShowAwardAndMessage(string awTitle, string awDesc, string txd, string texture, string awDesc2, colEnum col, string awDesc3 = "") => CallFunction("SHOW_AWARD_AND_MESSAGE", awTitle, awDesc, txd, texture, awDesc2, (int)col, awDesc3);
        public void ShowUnlockAndMessage(string awTitle, string awDesc, string txd, string texture, string awDesc2, colEnum col, string awDesc3 = "") => CallFunction("SHOW_UNLOCK_AND_MESSAGE", awTitle, awDesc, txd, texture, awDesc2, (int)col, awDesc3);

        public void OverrideYPosition(float newYPosition) => CallFunction("OVERRIDE_Y_POSITION", newYPosition);

        protected override void OnTestStart()
        {
            CallFunction("debug");
        }
    }
}
