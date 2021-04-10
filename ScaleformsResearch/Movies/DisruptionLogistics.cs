using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Rage;

namespace ScaleformsResearch.Movies
{
    internal class DisruptionLogistics : BusinessScreen
    {
        public override string MovieName => "DISRUPTION_LOGISTICS";

        private List<GameControl> inputs = new List<GameControl>
        {
            GameControl.FrontendLeft,
            GameControl.FrontendRight,
            GameControl.FrontendUp,
            GameControl.FrontendDown,
            GameControl.FrontendAccept,
            GameControl.FrontendCancel
        };
        public override List<GameControl> Inputs
        {
            get => inputs; set => throw new NotImplementedException();
        }

        protected override void ProcessControl(GameControl control)
        {
            switch (control)
            {
                case GameControl.FrontendAccept:
                    if (GetCurrentScreenID != 0) ShowOverlay("Alert", "Do you want to start the mission?", "Yes", "No");
                    break;
                case GameControl.FrontendCancel:
                    HideOverlay();
                    break;
                case GameControl.FrontendUp:
                case GameControl.FrontendDown:
                case GameControl.FrontendLeft:
                case GameControl.FrontendRight:
                    Game.DisplayNotification($"Current selection: {GetCurrentSelection}");
                    break;
            }
        }

        protected override void OnTestStart()
        {
            ShowScreen(0);
        }

        protected override void OnTestTick()
        {
            DisableHUD();
            CheckInputs();
        }

    }
}
