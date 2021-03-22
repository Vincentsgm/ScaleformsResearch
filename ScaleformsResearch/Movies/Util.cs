using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal static class Util
    {
        public static T Clamp<T>(this T x, T min, T max) where T : IComparable<T> => Rage.MathHelper.Clamp(x, min, max);
    }
}
