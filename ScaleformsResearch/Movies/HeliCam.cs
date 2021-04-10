using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class HeliCam : TurretCam
    {
        public override string MovieName => "HELI_CAM";

        public int LSPDLogo = 1;

        public void SetAudioStates(float smallLine, float mediumLine, float largeLine) => CallFunction("SET_AUDIO_STATES", smallLine, mediumLine, largeLine);

        Random t_random;
        protected override void OnTestStart()
        {
            base.OnTestStart();
            Logo = LSPDLogo;
            t_random = new Random(DateTime.Now.Millisecond);
        }
        
        protected override void OnTestTick()
        {
            base.OnTestTick();
            SetAudioStates((float)t_random.NextDouble(), (float)t_random.NextDouble(), (float)t_random.NextDouble());
        }
    }
}
