using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class OrbitalCannonMap : Movie
    {
        public override string MovieName => "ORBITAL_CANNON_MAP";

        public void StartCharging() => CallFunction("START_CHARGING");
        public void StartCountdown() => CallFunction("START_COUNTDOWN");
        public void CancelAnimation() => CallFunction("CANCEL_ANIMATION");

        private float zoom;
        public float Zoom
        {
            get => zoom;
            set
            {
                zoom = Math.Max(0, value);
                CallFunction("ZOOM_TO", zoom);
            }
        }

        private int positionX;
        public int PositionX
        {
            get => positionX;
            set
            {
                positionX = value.Clamp(-4500, 4500);
                MoveTo(positionX, positionY);
            }
        }

        private int positionY;
        public int PositionY
        {
            get => positionY;
            set
            {
                positionY = value.Clamp(-4500, 9000);
                MoveTo(positionX, positionY);
            }
        }

        public void MoveTo(int x, int y) => CallFunction("MOVE_TO", x, y);

        private Sound t_backgroundSound;

        protected override void OnTestStart()
        {
            t_backgroundSound = new Sound();
            t_backgroundSound.PlayFrontend("background_loop", "dlc_xm_orbital_cannon_sounds");
        }

        protected override void OnTestTick()
        {
            if (Game.IsKeyDownRightNow(Keys.NumPad4)) PositionX -= 40;
            else if (Game.IsKeyDownRightNow(Keys.NumPad6)) PositionX += 40;
            else if (Game.IsKeyDownRightNow(Keys.NumPad8)) PositionY += 40;
            else if (Game.IsKeyDownRightNow(Keys.NumPad2)) PositionY -= 40;
            else if (Game.IsKeyDownRightNow(Keys.Add)) Zoom += 0.1f;
            else if (Game.IsKeyDownRightNow(Keys.Subtract)) Zoom -= 0.1f;
            else if (Game.IsKeyDown(Keys.NumPad7)) StartCharging();
            else if (Game.IsKeyDown(Keys.NumPad9)) StartCountdown();
            else if (Game.IsKeyDown(Keys.NumPad1)) CancelAnimation();
        }

        protected override void OnTestEnd()
        {
            if (!t_backgroundSound.HasFinished) t_backgroundSound.Stop();
            t_backgroundSound.ReleaseId();
            t_backgroundSound = null;
        }
    }
}
