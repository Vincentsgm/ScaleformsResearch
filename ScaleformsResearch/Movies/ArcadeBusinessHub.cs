using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;

namespace ScaleformsResearch.Movies
{
    internal class ArcadeBusinessHub : BusinessScreen
    {
        public override string MovieName => "ARCADE_BUSINESS_HUB";

        private List<GameControl> inputs = new List<GameControl>
        {
            GameControl.FrontendLeft,
            GameControl.FrontendRight,
            GameControl.FrontendUp,
            GameControl.FrontendDown,
            GameControl.FrontendAccept,
            GameControl.FrontendCancel
        };
        public override List<GameControl> Inputs { get => inputs; set => throw new NotImplementedException(); }

        public void SetPlayer(string gamerName, string mugshot) => CallFunction("SET_PLAYER", gamerName, mugshot);
        public void AddBusiness(int id, string title, string texture, string statLabel1, string normStatLevel1, string statLabel2, string normStatLevel2, bool canResupply = true, bool isLocked = false) => CallFunction("ADD_BUSINESS", id, title, texture, statLabel1, normStatLevel1, statLabel2, normStatLevel2, canResupply, isLocked);
        public void ShowSpecialCargoOverlay(string title, string message, string button1Label, string button2Label, string button3Label, string button4Label, string button5Label) => CallFunction("SHOW_SPECIAL_CARGO_OVERLAY", title, message, button1Label, button2Label, button3Label, button4Label, button5Label);

        protected override void OnTestStart()
        {
            ShowScreen(0);
            SetPlayer("Vincentsgm", "CHAR_LESTER");
            for (int i = 0; i < 6; i++)
            {
                AddBusiness(i, $"Business {i}", "MP_ARC1", "Stat Lebel 1", "Norm Stat Lebel 1", "Stat Lebel 2", "Norm Stat Lebel 2");
            }
        }

        protected override void OnTestTick()
        {
            CheckInputs();
        }
    }
}
