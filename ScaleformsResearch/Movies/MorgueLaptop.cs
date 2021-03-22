using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;

namespace ScaleformsResearch.Movies
{
    public class MorgueLaptop : Movie
    {
        public override string MovieName => "MORGUE_LAPTOP";

        private int percent = 0;

        public int Percent
        {
            get => percent;
            set
            {
                percent = MathHelper.Clamp(value, 0, 100);
                CallFunction("SET_PROGRESS_PERCENT", percent);
            }
        }
        private uint t_lastUpdate;
        private bool t_finished;
        private Sound sound;

        protected override void OnTestStart()
        {
            Percent = 0;
            t_lastUpdate = Game.GameTime;
            t_finished = false;
            sound = new Sound();
            sound.PlayFrontend("laptop_download_loop", "dlc_xm_heists_iaa_morgue_sounds");
        }

        protected override void OnTestTick()
        {
            if (Percent < 100)
            {
                if (Game.GameTime > t_lastUpdate + 100)
                {
                    Percent += 1;
                    t_lastUpdate = Game.GameTime;

                    if (sound.HasFinished) sound.PlayFrontend("laptop_download_loop", "dlc_xm_heists_iaa_morgue_sounds");
                }
            }
            else
            {
                if (!t_finished)
                {
                    sound.Stop();
                    sound.ReleaseId();
                    sound = null;
                    new Sound(-1).PlayFrontend("HACKING_SUCCESS", null);
                    t_finished = true;
                }
            }
        }

        protected override void OnTestEnd()
        {
            if (sound != null) return;
            sound.Stop();
            sound.ReleaseId();
            sound = null;
        }
    }
}
