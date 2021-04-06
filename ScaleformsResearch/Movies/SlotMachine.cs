using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class SlotMachine : Movie
    {
        public override string MovieName => "SLOT_MACHINE";

        public enum SlotMachingTheme
        {
            Default = 0,
            Theme2 = 2,
            Theme5 = 5,
            Theme6 = 6,
            Theme7 = 7,
            Theme8 = 8
        }

        public SlotMachingTheme Theme { set => CallFunction("SET_THEME", (int)value); }

        public string Message { set => CallFunction("SET_MESSAGE", value); }

        public int Bet { set => CallFunction("SET_BET", value); }

        public int LastWin { set => CallFunction("SET_LAST_WIN", value); }

        int t_theme;

        protected override void OnTestStart()
        {
            Theme = SlotMachingTheme.Theme2;
            Message = "Welcome to the slot machine!";
            Bet = 69_666_420;
            LastWin = 420;
        }

        protected override void OnTestTick()
        {
            if (Game.IsKeyDown(Keys.NumPad1))
            {
                if (Enum.IsDefined(typeof(SlotMachingTheme), ++t_theme)) Theme = (SlotMachingTheme)t_theme;
            }
            else if (Game.IsKeyDown(Keys.NumPad2))
            {
                if (Enum.IsDefined(typeof(SlotMachingTheme), --t_theme)) Theme = (SlotMachingTheme)t_theme;
            }
        }

        protected override void TestDraw()
        {
            Draw2D(0.5f, 0.5f, 1f, 0.4f);
        }

        protected override string TestHelpMessage => "Numpad1/2: change theme";
    }
}
