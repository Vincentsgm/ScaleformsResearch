using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class MPSpectatorOverlay : Movie
    {
        public override string MovieName => "MP_SPECTATOR_OVERLAY";

        bool showTicker;
        public bool ShowTicker
        {
            get => showTicker;
            set
            {
                showTicker = value;
                CallFunction("SHOW_TICKER", showTicker);
            }
        }

        bool showPositions;
        public bool ShowPositions
        {
            get => showPositions;
            set
            {
                showPositions = value;
                CallFunction("SHOW_POSITIONS", showPositions);
            }
        }
        public void SetTitle(string missionType, string missionName, string missionDesc) => CallFunction("SET_TITLE", missionType, missionName, missionDesc);
        public void SetNextTitle(string missionType, string missionName, string missionDesc) => CallFunction("SET_NEXT_TITLE", missionType, missionName, missionDesc);
        public void AnimNextTitleIn() => CallFunction("ANIM_NEXT_TITLE_IN");
        public void AnimNextTitleOut() => CallFunction("ANIM_NEXT_TITLE_OUT");
        public void AnimNextTitle() => CallFunction("ANIM_NEXT_TITLE");

        const int TYPE_FEED = 0;
        const int TYPE_TWITTER = 1;
        const int TYPE_SOCIAL = 2;
        const int TYPE_JOB = 3;
        public void AddFeedText(params object[] arguments) => CallFunction("ADD_FEED_TEXT", arguments);
        public void AddJobText(params object[] arguments) => CallFunction("ADD_JOB_TEXT", arguments);
        public void InitScore() => CallFunction("INIT_SCORE");
        public void SetPlayerScore(int index, bool show, int position, string gamertag, int score) => CallFunction("SET_PLAYER_SCORE", index, show, position, gamertag, score);

        protected override void OnTestStart()
        {
            SetTitle("Mission type", "Mission name", "Mission desc");
            ShowTicker = true;
            ShowPositions = true;
            AddFeedText("Feed text 1", TYPE_FEED, "Feed text 2", TYPE_SOCIAL);
            AddFeedText("Feed text 3", TYPE_TWITTER, "Feed text 4", TYPE_JOB);
            AddJobText("Job text 1", TYPE_FEED, "Job text 2", TYPE_SOCIAL);
            AddJobText("Job text 3", TYPE_TWITTER, "Job text 4", TYPE_JOB);
            SetNextTitle("Next mission type", "Next mission name", "Next mission desc");
            InitScore();
            for (int i = 0; i < 6; i++)
            {
                SetPlayerScore(i, i % 2 == 0, i * i, $"Gamertag {i}", i * i * i);
            }
            AnimNextTitleIn();
        }

        protected override void OnTestTick()
        {
            CallFunction("update");

        }
    }
}
