using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Rage.Native.NativeFunction;
using Rage;

namespace ScaleformsResearch
{
    internal static class Controls
    {
        public static float GetDisabledControlNormal(GameControl control)
        {
            return Natives.GET_DISABLED_CONTROL_NORMAL<float>(2, (int)control);
        }

        public static Vector2 MousePosition => new Vector2(GetDisabledControlNormal(GameControl.CursorX), GetDisabledControlNormal(GameControl.CursorY));
    }
}
