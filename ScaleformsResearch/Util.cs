using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch
{
    internal static class Util
    {
        public static T Clamp<T>(this T x, T min, T max) where T : IComparable<T> => Rage.MathHelper.Clamp(x, min, max);

        public static Rage.Ped MainPlayer => Rage.Game.LocalPlayer.Character;
    }
}
