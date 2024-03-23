using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rage;
using Rage.Native;
using static Rage.Native.NativeFunction;

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

        float playerSwitchY = 0.087f;
        float playerSwitchW = 0.098f;
        float playerSwitchH = 0.175f;
        float playerSwitchScaleW = 1.0f;
        float playerSwitchScaleH = 1.0f;
        float playerSwitchWideScale = 1.3333f;

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

        //The game keeps messing with this scaleform, so we terminate the script associated with it
        public void TerminateGameScript() => Game.TerminateAllScriptsWithName("selector");

        public enum stateEnum
        {
            Unknown = 0,
            Available = 1,
            Unavailable = 2,
            NotMet = 3
        }

        public enum charEnum
        {
            Unknown = -1,
            Michael = 0,
            Trevor = 1,
            Franklin = 2,
            Multiplayer = 3
        }

        protected override void OnTestStart()
        {
            Refresh();
            TerminateGameScript();
            Natives.SET_SCALEFORM_MOVIE_TO_USE_SYSTEM_TIME(Handle, true);
            Natives.REQUEST_STREAMED_TEXTURE_DICT("char_abigail");
            Natives.REQUEST_STREAMED_TEXTURE_DICT("char_amanda");
            Natives.REQUEST_STREAMED_TEXTURE_DICT("char_andreas");
            Natives.REQUEST_STREAMED_TEXTURE_DICT("char_barry");
            SetSwitchSlot(0, stateEnum.Available, charEnum.Michael, true, "char_abigail");
            SetSwitchSlot(1, stateEnum.Available, charEnum.Franklin, false, "char_amanda");
            SetSwitchSlot(2, stateEnum.Available, charEnum.Trevor, false, "char_andreas");
            SetSwitchSlot(3, stateEnum.Available, charEnum.Multiplayer, false, "director");

            SetPlayerDamage(0, true, true);

            MPLabel = "Test";

            Visible = true;

            MPHead = "director";

            Game.FrameRender += Game_FrameRender;
        }

        private void Game_FrameRender(object sender, GraphicsEventArgs e)
        {
            Natives.SET_WIDESCREEN_FORMAT(3);
            Natives.SET_SCRIPT_GFX_ALIGN(82, 66);
            Natives.SET_SCRIPT_GFX_ALIGN_PARAMS(0f, 0f, 0f, 0f);
            Draw2D(((playerSwitchW * playerSwitchScaleW) * playerSwitchWideScale) * 0.5f, playerSwitchY, playerSwitchW * playerSwitchScaleW * playerSwitchWideScale, playerSwitchH * playerSwitchScaleH);
            Natives.RESET_SCRIPT_GFX_ALIGN();
        }

        protected override void OnTestTick()
        {
            TerminateGameScript();
            Game.DisplaySubtitle($"Selected character: {PlayerSelected}");
            if (Game.IsKeyDown(Keys.NumPad8)) PlayerSelected = 1;
            else if (Game.IsKeyDown(Keys.NumPad4)) PlayerSelected = 0;
            else if (Game.IsKeyDown(Keys.NumPad6)) PlayerSelected = 2;
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
