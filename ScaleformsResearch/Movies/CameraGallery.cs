using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    class CameraGallery : Movie
    {
        public override string MovieName => "CAMERA_GALLERY";

        bool photoFrameVisible = false, remainingPhotosVisible = false;
        int view = 0, taken = 0, remaining = 0;

        public bool PhotoFrameVisible { get => photoFrameVisible; set { photoFrameVisible = value; CallFunction("SHOW_PHOTO_FRAME", photoFrameVisible); } }

        public int View { get => view; set { view = value; CallFunction("DISPLAY_VIEW", view); } }

        public int PhotosTaken { get => taken; set { taken = value; CallFunction("SET_REMAINING_PHOTOS", taken, remaining); } }
        public int PhotosRemaining { get => remaining; set { remaining = value; CallFunction("SET_REMAINING_PHOTOS", taken, remaining); } }
        public bool RemainingPhotosVisible { get => remainingPhotosVisible; set { remainingPhotosVisible = value; CallFunction("SHOW_REMAINING_PHOTOS", remainingPhotosVisible); } }

        public void FlashPhotoFrame() => CallFunction("FLASH_PHOTO_FRAME");

        public void OpenShutter() => CallFunction("OPEN_SHUTTER");

        public void CloseShutter() => CallFunction("CLOSE_SHUTTER");

        public void CloseAndOpenShutter() => CallFunction("CLOSE_THEN_OPEN_SHUTTER");

        public void SetFocusLock(bool visible, string text, bool iconVisible)
        {
            CallFunction("SET_FOCUS_LOCK", visible, text, iconVisible);
        }

        bool t_fl = false;

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
                CloseAndOpenShutter();
            }
            else
            if (Game.IsKeyDown(Keys.NumPad4))
            {
                View++;
            }
            else
            if (Game.IsKeyDown(Keys.NumPad5))
            {
                View--;
            }
            else
            if (Game.IsKeyDown(Keys.NumPad6))
            {
                FlashPhotoFrame();
            }
            else
            if (Game.IsKeyDown(Keys.NumPad7))
            {
                PhotosTaken = MathHelper.GetRandomInteger(5, 25);
                PhotosRemaining = MathHelper.GetRandomInteger(3, 10);
            }
            else
            if (Game.IsKeyDown(Keys.NumPad8))
            {
                RemainingPhotosVisible = !RemainingPhotosVisible;
            }
            else
            if (Game.IsKeyDown(Keys.NumPad9))
            {
                t_fl = !t_fl;
                SetFocusLock(t_fl, Util.Phrases.Random(), t_fl);
            }
        }
        protected override string TestHelpMessage => $"~y~NumPad1/2/3~s~ - Shutter [Close/Open/CloseThenOpen]~n~~y~NumPad4/5~s~ - View+- ({View})~n~~y~NumPad6~s~ - FlashPhotoFrame~n~~y~NumPad7~s~ - Randomize Photos Counter~n~~y~NumPad8~s~ - Remaining Photos Toggle~n~~y~NumPad9~s~ - Randomize Focus Lock";
    }
}
