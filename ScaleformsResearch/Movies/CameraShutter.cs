using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    class CameraShutter : Movie
    {
        public override string MovieName => "CAMERA_SHUTTER";

        public void OpenShutter() => CallFunction("OPEN_SHUTTER");

        public void CloseShutter() => CallFunction("CLOSE_SHUTTER");

        public void CloseAndOpenShutter() => CallFunction("CLOSE_THEN_OPEN_SHUTTER");

        protected override void OnTestTick()
        {
            base.OnTestTick();
            if (Game.IsKeyDown(Keys.NumPad1))
            {
                CloseShutter();
            }
            else
            if (Game.IsKeyDown(Keys.NumPad2))
            {
                OpenShutter();
            }
            else
            if (Game.IsKeyDown(Keys.NumPad3))
            {
                new Sound(-1).PlayFrontend("Camera_Shoot", "Phone_Soundset_Franklin");
                CloseAndOpenShutter();
            }
        }
        protected override string TestHelpMessage => $"~y~NumPad1/2/3~s~ - Shutter [Close/Open/CloseThenOpen]";
    }
}
