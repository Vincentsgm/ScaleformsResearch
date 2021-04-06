using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class HumPacDesktopbank : Movie
    {
        public override string MovieName => "hum_pac_desktopbank";

        int t_view;

        protected override void OnTestTick()
        {
            //if (Game.IsKeyDown(Keys.Add)) CallFunction("DISPLAY_VIEW", ++t_view);
        }
    }
}
