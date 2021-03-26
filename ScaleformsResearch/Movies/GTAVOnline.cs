using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rage;

namespace ScaleformsResearch.Movies
{
    internal class GTAVOnline : Movie
    {
        public override string MovieName => "GTAV_ONLINE";

        public void SetBigLogoVisible(bool isBig, bool playFromStart) => CallFunction("SET_BIG_LOGO_VISIBLE", isBig, playFromStart);

        public void SetUpBigFeed(bool alignRight) => CallFunction("SETUP_BIG_FEED", alignRight);

        public string BigFeedBodyText { set => CallFunction("SET_BIGFEED_BODY_TEXT", value); }

        public void FadeInBigFeed() => CallFunction("FADE_IN_BIGFEED");

        public void FadeOutBigFeed() => CallFunction("FADE_OUT_BIGFEED");

        public void SetBigFeedImage(string txd, string image)
        {
            Textures.LoadTextureDictionnary(txd);
            CallFunction("SET_BIGFEED_IMAGE", txd, image);
        }

        public void SetBigFeedProgress(HudColor color, int progress) => CallFunction("SET_BIGFEED_PROGRESS", (int)color, progress);

        public void SetUpTabs(int count, bool alignRight) => CallFunction("SETUP_TABS", count, alignRight);

        public void SetBigFeedInfo(string footerStr, string bodyStr, int whichTab, string textureDict, string textureName, string subtitle, string urlDeprecated, string title, int newsItemType)
        {
            Textures.LoadTextureDictionnary(textureDict);
            CallFunction("SET_BIGFEED_INFO", footerStr, bodyStr, whichTab, textureDict, textureName, subtitle, urlDeprecated, title, newsItemType);
        }

        public void EndBigFeed() => CallFunction("END_BIGFEED");

        public void DisplayView(int viewIndex, int itemIndex) => CallFunction("DISPLAY_VIEW", viewIndex, itemIndex);

        private int newsContext;
        public int NewsContext
        {
            get => newsContext; set { newsContext = Math.Max(0, value); CallFunction("SET_NEWS_CONTEXT", newsContext); }
        }

        protected override string TestHelpMessage => $"~y~NumPad4/6: ~s~Change News Context: ~b~{NewsContext}\n" +
            $"~y~NumPad9/3: ~s~Fade in/Fade out\n" +
            $"~y~NumPad8: ~s~Big/Small logo\n";

        protected override void OnTestStart()
        {
            Refresh();
            NewsContext = 0;
            SetBigLogoVisible(true, true);
            SetUpBigFeed(true);
            SetUpTabs(2, true);
            SetBigFeedImage("horse_racing_wall", "background_left");
            SetBigFeedInfo(Util.Random(Util.Phrases), Util.Random(Util.Phrases), 0, "horse_racing_wall", "background_left", Util.Random(Util.Phrases), "URL", Util.Random(Util.Phrases), 0);
            SetBigFeedInfo(Util.Random(Util.Phrases), Util.Random(Util.Phrases), 1, "www_suemurry_com", "suemurry_background_right", Util.Random(Util.Phrases), "URL", Util.Random(Util.Phrases), 0);
            BigFeedBodyText = "Big Feed Body Text";
            DisplayView(0, 0);
            t_lastTime = Game.GameTime;
            t_progress = 0;
            currentTab = 0;
            currentView = 0;
            FadeInBigFeed();
        }

        public uint t_lastTime;
        public int t_progress;
        public int currentTab;
        public int currentView;
        public bool bigLogo;

        protected override void OnTestTick()
        {
            if (Game.GameTime + 300 > t_lastTime && t_progress <= 100) SetBigFeedProgress(HudColor.BlueLight, t_progress++);
            else if (Game.IsKeyDown(Keys.NumPad6)) NewsContext++;
            else if (Game.IsKeyDown(Keys.NumPad4)) NewsContext--;
            else if (Game.IsKeyDown(Keys.NumPad9)) FadeInBigFeed();
            else if (Game.IsKeyDown(Keys.NumPad3)) FadeOutBigFeed();
            else if (Game.IsKeyDown(Keys.NumPad7)) DisplayView(++currentTab, currentView);
            else if (Game.IsKeyDown(Keys.NumPad1)) DisplayView(--currentTab, currentView);
            else if (Game.IsKeyDown(Keys.NumPad8)) { bigLogo = !bigLogo; SetBigLogoVisible(bigLogo, true); }
        }
    }
}
