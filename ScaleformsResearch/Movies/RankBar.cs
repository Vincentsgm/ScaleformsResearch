using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    public class RankBar : HudMovie
    {
        public override string MovieName => "MP_RANK_BAR";

        public override int HudComponent => 19;

        public int XPStartLimit { get; set; } = 0;

        public int XPEndLimit { get; set; } = 1000;

        public int PreviousXP { get; set; } = 0;

        public int CurrentXP { get; set; } = 0;

        public int PlayerLevel { get; set; } = 1;

        private HudColor color = HudColor.Freemode;

        public HudColor RankColor { get => color; set { color = value; CallHudFunction("SET_COLOUR", (int)color); } }

        public void StayOnScreen() => CallHudFunction("STAY_ON_SCREEN");

        public void Reset() => CallHudFunction("RESET_MOVIE");

        protected override void BeforeDraw()
        {
            SetRankScores(XPStartLimit, XPEndLimit, PreviousXP, CurrentXP, PlayerLevel, 100);
            base.BeforeDraw();
        }

        public void SetRankScores(int xpStartLimit, int xpEndLimit, int previousXP, int currentXP, int playerLevel, int opacity = 100)
        {
            CallHudFunction("SET_RANK_SCORES", xpStartLimit, xpEndLimit, previousXP, currentXP, playerLevel, opacity);
        }
    }
}
