using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class PlayerName : Movie
    {
        public override string MovieName => "PLAYER_NAME_01";

        public string PlayerNameStr { set => CallFunction("SET_PLAYER_NAME", value); }
        public ESpeakerState SpeakerState { set => CallFunction("SET_SPEAKER_STATE", (int)value); }

        protected override void OnTestStart()
        {
            PlayerNameStr = $"{MovieName}: ~b~{Game.LocalPlayer.Name}";
        }

        protected override void OnTestTick()
        {
            base.OnTestTick();
            if (Game.IsKeyDown(Keys.NumPad0)) SpeakerState = ESpeakerState.NoHeadset;
            else if (Game.IsKeyDown(Keys.NumPad1)) SpeakerState = ESpeakerState.Active;
            else if (Game.IsKeyDown(Keys.NumPad2)) SpeakerState = ESpeakerState.Speaking;
            else if (Game.IsKeyDown(Keys.NumPad3)) SpeakerState = ESpeakerState.Muted;
        }

        protected override string TestHelpMessage => $"~s~No Headset: ~y~NumPad0\n" +
            $"~s~Active Headset: ~y~NumPad1\n" +
            $"~s~Speaking Headset: ~y~NumPad2\n" +
            $"~s~Muted Headset: ~y~NumPad3\n";

        public enum ESpeakerState
        {
            NoHeadset = 1,
            Active = 2,
            Speaking = 3,
            Muted = 4
        }
    }

    internal class PlayerName02 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_02";
    }

    internal class PlayerName03 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_03";
    }
    internal class PlayerName04 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_04";
    }
    internal class PlayerName05 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_05";
    }
    internal class PlayerName06 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_06";
    }
    internal class PlayerName07 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_07";
    }
    internal class PlayerName08 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_08";
    }
    internal class PlayerName09 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_09";
    }
    internal class PlayerName10 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_10";
    }
    internal class PlayerName11 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_11";
    }
    internal class PlayerName12 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_12";
    }
    internal class PlayerName13 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_13";
    }
    internal class PlayerName14 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_14";
    }
    internal class PlayerName15 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_15";
    }
    /*
    internal class PlayerName16 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_16";
    }
    internal class PlayerName17 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_17";
    }
    internal class PlayerName18 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_18";
    }
    internal class PlayerName19 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_19";
    }
    internal class PlayerName20 : PlayerName
    {
        public override string MovieName => "PLAYER_NAME_20";
    }
    */

}
