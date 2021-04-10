using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rage;

namespace ScaleformsResearch.Movies
{
    internal class LoadingscreenStartup : Movie
    {
        public override string MovieName => "LOADINGSCREEN_STARTUP";

        protected override void OnTestStart()
        {
            CallFunction("SWITCH");
            CallFunction("SET_PROGRESS_TITLE", "Run's dead");
            CallFunction("SET_PROGRESS_TEXT", "Merryweather's fleet's here bro");
        }

        protected override void OnTestTick()
        {
        }
    }
}
