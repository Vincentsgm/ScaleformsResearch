using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class RemoteSniperLoading : Movie
    {
        public override string MovieName => "REMOTE_SNIPER_LOADING";

        public void StartLoading() => CallFunction("START_LOADING");

        protected override void OnTestStart()
        {
            StartLoading();
        }

        protected override void OnTestTick()
        {
            if (Game.IsKeyDown(Keys.NumPad1)) StartLoading();  
        }

        protected override string TestHelpMessage => "Numpad1: start loading";
    }
}
