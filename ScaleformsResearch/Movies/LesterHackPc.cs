using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class LesterHackPc : Movie
    {
        public override string MovieName => "LESTER_HACK_PC";

        private bool iFinderPopupVisible;
        public bool IFinderPopupVisible
        {
            get => iFinderPopupVisible;
            set
            {
                iFinderPopupVisible = value;
                if (iFinderPopupVisible)
                {
                    CallFunction("SHOW_IFINDER_POPUP");
                }
                else
                {
                    CallFunction("HIDE_IFINDER_POPUP");
                }
            }
        }

        protected override void OnTestTick()
        {
            if (Game.IsKeyDown(Keys.NumPad1)) IFinderPopupVisible = !IFinderPopupVisible;
        }

        protected override string TestHelpMessage => "Numpad1: hide/show eyefinder popup";
    }
}
