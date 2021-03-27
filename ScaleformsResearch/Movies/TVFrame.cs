using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class TVFrame : Movie
    {
        public override string MovieName => "TV_FRAME";

        protected override void OnTestStart()
        {
            TimecycleModifier.SetTimecycle("CCTV_overlay01");
            TimecycleModifier.SetTimecycleStrength(1f);
        }

        protected override void OnTestEnd()
        {
            TimecycleModifier.ClearTimecycle();
        }
    }
}
