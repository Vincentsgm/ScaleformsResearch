using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;

namespace ScaleformsResearch.Movies
{
    internal class LoadingScreenNewGame : Movie
    {
        public override string MovieName => "LOADINGSCREEN_NEWGAME";

        private int progressBarPercentage;
        public int ProgressBarPercentage { get => progressBarPercentage; set { progressBarPercentage = value.Clamp(0, 100); CallFunction("SET_PROGRESS_BAR", progressBarPercentage); } }

        public string ProgressBarText { set => CallFunction("SET_PROGRESS_TEXT", value); }

        protected override void OnTestStart()
        {
            ProgressBarText = "Progress Text";
            t_lastTime = Game.GameTime;
            t_progress = 0;
        }

        public uint t_lastTime;
        public int t_progress;

        protected override void OnTestTick()
        {
            if (Game.GameTime + 500 > t_lastTime && t_progress <= 100)
            {
                ProgressBarPercentage = t_progress++;
                ProgressBarText = $"Loading {ProgressBarPercentage}%";
            }
        }
    }
}
