using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class MPMissionNameFreemode : Movie
    {
        public override string MovieName => "MP_MISSION_NAME_FREEMODE";

        public void SetMissionInfo(string missionName, int missionType, string playerInfo, float percentage, string debugValue, bool isRockstarVerified, int playersRequired, int RP, int cash, int time)
            => CallFunction("SET_MISSION_INFO", missionName, missionType, playerInfo, percentage, debugValue, isRockstarVerified, playersRequired, RP, cash, time);

        protected override void OnTestStart()
        {
            SetMissionInfo("Mission name", 0, "Vincentsgm", 69.69f, "debug", true, 4, 69, 420, 666);
        }
    }

    internal class MPMissionNameFreemode1: MPMissionNameFreemode
    {
        public override string MovieName => "MP_MISSION_NAME_FREEMODE_1";
    }

    internal class MPMissionNameFreemode2 : MPMissionNameFreemode
    {
        public override string MovieName => "MP_MISSION_NAME_FREEMODE_2";
    }
}
