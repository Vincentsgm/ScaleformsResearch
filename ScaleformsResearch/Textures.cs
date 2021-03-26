using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Rage.Native.NativeFunction;

namespace ScaleformsResearch
{
    internal static class Textures
    {
        public static void LoadTextureDictionnary(string textureDictionnary)
        {
            Natives.xDFA2EF8E04127DD5(textureDictionnary, false);
        }
    }
}
