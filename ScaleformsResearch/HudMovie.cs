using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Rage.Native.NativeFunction;

namespace ScaleformsResearch
{
    public abstract class HudMovie : Movie
    {
        public override string MovieName => throw new NotImplementedException();

        public abstract int HudComponent { get; }

        public bool HudMovieLoaded { get => Natives.xDF6E5987D2B4D140<bool>(HudComponent); }

        public void LoadHudMovie()
        {
            if (!HudMovieLoaded)
            {
                Natives.x9304881D6F6537EA(HudComponent);
                while (!HudMovieLoaded) Rage.GameFiber.Sleep(1);
                LoadAndWait();
            }
        }

        public void CallHudFunction(string name, params object[] args)
        {
            Natives.x98C494FD5BDFBFD5(HudComponent, name);
            pushArgs(args);
            Natives.xc6796a8ffa375e53();
        }

        protected override void BeforeDraw()
        {
            //Doesn't seem to work
            Natives.x0B4DF1FA60C0E664(HudComponent);
        }
    }
}
