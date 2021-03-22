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
    }
}
