using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class Rampage : Movie
    {
        public override string MovieName => "RAMPAGE";

        public void ShowRampage() => CallFunction("SHOW_RAMPAGE");
        public void HideRampage() => CallFunction("HIDE_RAMPAGE");
        public void ShowRampageIntro(int duration, string rampage, string description) => CallFunction("SHOW_RAMPAGE_INTRO", duration, rampage, description);
        public void ShowRampageCountdown(int duration, string description) => CallFunction("SHOW_RAMPAGE_COUNTDOWN", duration, description);
        public void ShowRampageOutro() => CallFunction("SHOW_RAMPAGE_OUTRO");

        protected override void OnTestStart()
        {
            //ShowRampage();
            ShowRampageIntro(20000, "Rampage", "Rampage Starting!");
            Rage.Game.DisplaySubtitle(Handle.ToString());
        }
    }
}
