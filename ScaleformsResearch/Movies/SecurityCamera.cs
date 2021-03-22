using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    public class SecurityCamera : Movie
    {
        public override string MovieName => "SECURITY_CAMERA";

        public void ShowCameraOverlay() => CallFunction("SHOW_CAMERA_OVERLAY");

        public void ShowStatic() => CallFunction("SHOW_STATIC");

        protected override void OnTestTick()
        {
            base.OnTestTick();
            if (Game.IsKeyDown(Keys.NumPad1))
            {
                ShowCameraOverlay();
            }
            else if (Game.IsKeyDown(Keys.NumPad2))
            {
                ShowStatic();
            }
        }
        protected override string TestHelpMessage => $"~y~{Keys.NumPad1}~s~ - Show Camera Overlay~n~~y~{Keys.NumPad2}~s~ - Show Static";
    }
}