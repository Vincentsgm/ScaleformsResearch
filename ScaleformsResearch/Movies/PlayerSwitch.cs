using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rage;

namespace ScaleformsResearch.Movies
{
    public class PlayerSwitch : Movie
    {
        public override string MovieName => "PLAYER_SWITCH";

        private bool visible = false;
        public bool Visible { get => visible; set { visible = value; CallFunction("SET_SWITCH_VISIBLE", visible); } }

        public string MPHead { set => CallFunction("SET_MULTIPLIER_HEAD", value); }

        public string MPLabel { set => CallFunction("SET_MP_LABEL", value); }

        public int PlayerSelected { get => GetSwitchSelected(); set => SetPlayerSelected(value); }

        public void SetSwitchSlot(int index, stateEnum stateEnum, charEnum charEnum, bool selected, string pedheadshot = null)
        {
            if (pedheadshot is null)
            {
                CallFunction("SET_SWITCH_SLOT", index, (int)stateEnum, (int)charEnum, selected);
            }
            else
            {
                CallFunction("SET_SWITCH_SLOT", index, (int)stateEnum, (int)charEnum, selected, pedheadshot);
            }
        }

        public void SetSwitchHinted(int index, bool hinted) => CallFunction("SET_SWITCH_HINTED", index, hinted);

        public void SetSwitchHintedAll(bool hinted0, bool hinted1, bool hinted2, bool hinted3) => CallFunction("SET_SWITCH_HINTED_ALL", hinted0, hinted1, hinted2, hinted3);

        public void SetSwitchCounterAll(int counter0, int counter1, int counter2, int counter3) => CallFunction("SET_SWITCH_HINTED_ALL", counter0, counter1, counter2, counter3);

        public void SetPlayerSelected(int index) => CallFunction("SET_PLAYER_SELECTED", index);

        public void SetPlayerDamage(int index, bool visible, bool flash) => CallFunction("SET_PLAYER_DAMAGE", index, visible, flash);

        public int GetSwitchSelected() => CallFunctionInt("GET_SWITCH_SELECTED");

        public enum stateEnum
        {
            Unknown = 0,
            Available = 1,
            Unavailable = 2,
            NotMet = 3
        }

        public enum charEnum
        {
            Unk1 = 0,
            Unk2 = 1,
            Unk3 = 2,
            Unk4 = 3
        }

        protected override void OnTestStart()
        {
            Refresh();
            SetSwitchSlot(0, stateEnum.Available, charEnum.Unk1, true, "char_abigail");
            SetSwitchSlot(1, stateEnum.Available, charEnum.Unk2, false, "char_amanda");
            SetSwitchSlot(2, stateEnum.Available, charEnum.Unk3, false, "char_andreas");
            SetSwitchSlot(3, stateEnum.Available, charEnum.Unk4, false, "char_barry");

            SetPlayerDamage(0, true, true);

            MPLabel = "FR_HELP";

            Visible = true;

            MPHead = "char_barry";

            Game.FrameRender += Game_FrameRender; ;
        }

        private void Game_FrameRender(object sender, GraphicsEventArgs e)
        {
            Draw2D(0.88f, 0.88f, 0.2f, 0.2f);
        }

        protected override void OnTestTick()
        {
            Game.DisplaySubtitle($"Selected character: {PlayerSelected}");
            if (Game.IsKeyDown(Keys.NumPad8)) PlayerSelected = 2;
            else if (Game.IsKeyDown(Keys.NumPad4)) PlayerSelected = 0;
            else if (Game.IsKeyDown(Keys.NumPad6)) PlayerSelected = 1;
            else if (Game.IsKeyDown(Keys.NumPad2)) PlayerSelected = 3;
        }

        protected override string TestHelpMessage => $"~y~NumPad2/4/6/8~s~ - Select Character";

        protected override void OnTestEnd()
        {
            Game.FrameRender -= Game_FrameRender;
        }

        protected override void TestDraw()
        {
            //Not drawing on tick otherwise it flickers
        }
    }
}
