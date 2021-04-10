using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class AppMissionStatsView : Movie
    {
        public override string MovieName => "APP_MISSION_STATS_VIEW";

        public void Construct() => CallFunction("construct", 0, 0, "test", "test 2", "test 3");

        public void RenderContainers() => CallFunction("renderContainers", 0, 0);

        public enum NavDirection
        {
            UP,
            DOWN
        }
        public void Navigate(NavDirection direction) => CallFunction("navigate", direction.ToString());

        protected override void OnTestStart()
        {
            Construct();
            RenderContainers();
        }

        protected override void OnTestTick()
        {
            if (Game.IsKeyDown(Keys.Up)) Navigate(NavDirection.UP);
            else if (Game.IsKeyDown(Keys.Down)) Navigate(NavDirection.DOWN);
        }
    }
}
