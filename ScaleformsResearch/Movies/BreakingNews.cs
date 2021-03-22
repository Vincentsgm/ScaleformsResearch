using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    class BreakingNews : Movie
    {
        public override string MovieName => "BREAKING_NEWS";

        private string title = "", subtitle = "";
        private StaticType staticType = StaticType.None;
        private int stTop = 0, stBottom = 0;

        public string Title { get => title; set { title = value; CallFunction("SET_TEXT", title, subtitle); } }
        public string Subtitle { get => subtitle; set { subtitle = value; CallFunction("SET_TEXT", title, subtitle); } }
        public StaticType Static { get => staticType; set { staticType = value; CallFunction("SHOW_STATIC", (int)staticType); } }

        public int AddScrollText(ScrollTextSlot slot, string text)
        {
            int id = slot == ScrollTextSlot.Top ? stTop : stBottom;
            CallFunction("SET_SCROLL_TEXT", (int)slot, id, text);
            if (slot == ScrollTextSlot.Top) stTop++; else stBottom++;
            return id;
        }
        public void DisplayScrollText(ScrollTextSlot slot, int id, float scrollSpeed)
        {
            CallFunction("DISPLAY_SCROLL_TEXT", (int)slot, id, scrollSpeed);
        }
        public void ClearScrollText(ScrollTextSlot slot)
        {
            CallFunction("CLEAR_SCROLL_TEXT", (int)slot);
            if (slot == ScrollTextSlot.Top) stTop = 0; else stBottom = 0;
        }
        public void ClearScrollText()
        {
            ClearScrollText(ScrollTextSlot.Top);
            ClearScrollText(ScrollTextSlot.Bottom);
        }

        protected override void OnTestTick()
        {
            base.OnTestTick();
            if (Game.IsKeyDown(Keys.NumPad1))
            {
                Title = Util.Phrases.Random();
            }
            else
            if (Game.IsKeyDown(Keys.NumPad2))
            {
                Subtitle = Util.Phrases.Random();
            }
            else
            if (Game.IsKeyDown(Keys.NumPad4))
            {
                Static = StaticType.None;
            }
            else
            if (Game.IsKeyDown(Keys.NumPad5))
            {
                Static = StaticType.Noise;
            }
            else
            if (Game.IsKeyDown(Keys.NumPad6))
            {
                Static = StaticType.Blue;
            }
            else
            if (Game.IsKeyDown(Keys.NumPad7))
            {
                int id = AddScrollText(ScrollTextSlot.Top, Util.Phrases.Random());
                DisplayScrollText(ScrollTextSlot.Top, id, 10000);
            }
            else
            if (Game.IsKeyDown(Keys.NumPad8))
            {
                int id = AddScrollText(ScrollTextSlot.Bottom, Util.Phrases.Random());
                DisplayScrollText(ScrollTextSlot.Bottom, id, 10000);
            }
            else
            if (Game.IsKeyDown(Keys.NumPad9))
            {
                ClearScrollText();
            }
            else
            if (Game.IsKeyDown(Keys.NumPad3))
            {
                DisplayScrollText(ScrollTextSlot.Top, 0, 1);
            }
        }
        protected override string TestHelpMessage => $"~y~{Keys.NumPad1}~s~ - Randomize Title~n~~y~{Keys.NumPad2}~s~ - Randomize Subtitle~n~~y~NumPad4/5/6~s~ - Static [None/Noise/Blue] ({staticType})~n~~y~NumPad7/8~s~ - Add Scroll Text [Top/Bottom]~n~~y~{Keys.NumPad9}~s~ - Clear Scroll Text";

        public enum StaticType
        {
            None = -1,
            Noise = 0,
            Blue = 1,
        }
        public enum ScrollTextSlot
        {
            Top,
            Bottom
        }
    }
}
