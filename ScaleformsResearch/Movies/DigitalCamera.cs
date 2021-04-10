using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rage;

namespace ScaleformsResearch.Movies
{
    internal class DigitalCamera : Movie
    {
        public override string MovieName => "DIGITAL_CAMERA";

        public bool ShowRemainingPhotos { set => CallFunction("SHOW_REMAINING_PHOTOS", value); }

        public bool ShowPhotoFrame { set => CallFunction("SHOW_PHOTO_FRAME", value); }

        public void ShowFocusLock(bool visible, string str) => CallFunction("SHOW_FOCUS_LOCK", visible, str);

        public void SetRemainingPhotos(int photosTaken, int photosLeft) => CallFunction("SET_REMAINING_PHOTOS", photosTaken, photosLeft);

        public void ShowPhotoBorder(bool vis, float rotation, float xpos, float ypos, int xscale, int yscale) => CallFunction("SHOW_PHOTO_BORDER", vis, rotation, xpos, ypos, xscale, yscale);

        public void OpenShutter(float shutterSpeed) => CallFunction("OPEN_SHUTTER", shutterSpeed);

        public void CloseShutter(float shutterSpeed) => CallFunction("CLOSE_SHUTTER", shutterSpeed);

        public void CloseAndOpenShutter() => CallFunction("CLOSE_THEN_OPEN_SHUTTER");

        protected override void OnTestStart()
        {
            ShowRemainingPhotos = true;
            SetRemainingPhotos(6, 9);
        }

        protected override void OnTestTick()
        {
            if (Game.IsKeyDown(Keys.NumPad1))
            {
                CloseShutter(0.1f);
            }
            else
            if (Game.IsKeyDown(Keys.NumPad2))
            {
                OpenShutter(0.1f);
            }
            else
            if (Game.IsKeyDown(Keys.NumPad3))
            {
                new Sound(-1).PlayFrontend("Camera_Shoot", "Phone_Soundset_Franklin");
                CloseAndOpenShutter();
            }
            else if (Game.IsKeyDown(Keys.NumPad4)) ShowPhotoFrame = false;
            else if (Game.IsKeyDown(Keys.NumPad5)) ShowPhotoFrame = true;
        }
    }
}
