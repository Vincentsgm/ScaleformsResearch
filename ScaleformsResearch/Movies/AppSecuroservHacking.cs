using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;

namespace ScaleformsResearch.Movies
{
    internal class AppSecuroservHacking : Movie
    {
        public override string MovieName => "APP_SECUROSERV_HACKING";

        private int percentage;
        public int Percentage { get => percentage; set { percentage = value.Clamp(0, 100); CallFunction("initHacking", percentage); } }

        public void InitProgress() => CallFunction("initProgress");

        public void InitComplete() => CallFunction("initComplete");

        private uint t_lastTime;
        private bool t_completed;
        private Sound hackSound;

        protected override void OnTestStart()
        {
            Percentage = 0;
            t_lastTime = Game.GameTime;
            t_completed = false;
            InitProgress(); 
            hackSound = new Sound();
            hackSound.PlayFrontend("laptop_download_loop", "dlc_xm_heists_iaa_morgue_sounds");
        }

        protected override void OnTestTick()
        {
            if (Game.GameTime > t_lastTime + 400 && Percentage < 100) Percentage++;
            else if (Percentage >= 100 && !t_completed)
            {
                InitComplete();
                t_completed = true;
                if (hackSound != null && !hackSound.HasFinished) hackSound.Stop();
                new Sound(-1).PlayFrontend("HACKING_SUCCESS", null);
            }
        }

        protected override void TestDraw()
        {
            Draw2D(0.5f, 0.5f, 0.4f, 1f);
        }
    }
}
