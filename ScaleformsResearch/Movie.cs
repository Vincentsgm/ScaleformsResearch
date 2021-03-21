using static Rage.Native.NativeFunction;
using Color = System.Drawing.Color;

namespace ScaleformsResearch
{
    public abstract class Movie
    {
        public int Handle { get; private set; } = 0;
        public Color Color { get; set; } = Color.White;
        public bool IsLoaded { get { return !IsReleased && Handle != 0 && Natives.x85F01B8D5B90570E<bool>(Handle); } }

        public bool FitsRenderTarget { set => Natives.xE6A9F00D4240B519(Handle, value); }

        public bool IsReleased { get; private set; }

        public abstract string MovieName { get; }

        public bool Load()
        {
            if (IsLoaded) return true;
            IsReleased = false;
            Handle = Natives.x11FE353CF9733E6F<int>(MovieName);
            return Handle != 0;
        }

        public bool LoadAndWait()
        {
            bool x = Load();
            while (!IsLoaded) Rage.GameFiber.Sleep(1);
            return x;
        }

        public void Release()
        {
            int h = Handle;
            Natives.x1D132D614DD86811(ref h);
            IsReleased = true;
        }

        public void Refresh()
        {
            if (IsLoaded) Release();
            LoadAndWait();
        }

        public void Draw()
        {
            if (!IsLoaded) return;
            Natives.x0DF606929C105BE1(Handle, Color.R, Color.G, Color.B, Color.A);
        }

        public void Draw2D(float x, float y, float w, float h)
        {
            if (!IsLoaded) return;
            Natives.x54972ADAF0294A93(Handle, x, y, w, h, Color.R, Color.G, Color.B, Color.A);
        }

        public void Draw3D(Rage.Vector3 position, Rage.Rotator rotation, Rage.Vector3 scale, bool solid = true)
        {
            if (IsLoaded)
            {
                if (solid)
                    Natives.x1ce592fdc749d6f5(Handle, position.X, position.Y, position.Z, rotation.Pitch, rotation.Roll, rotation.Yaw, 2, 2, 1, scale.X, scale.Y, scale.Z, 2);
                else
                    Natives.x87D51D72255D4E78(Handle, position.X, position.Y, position.Z, rotation.Pitch, rotation.Roll, rotation.Yaw, 2, 2, 1, scale.X, scale.Y, scale.Z, 2);
            }
        }

        public void DrawMasked(Movie scaleform2, Color color)
        {
            if (IsLoaded && (scaleform2?.IsLoaded ?? false))
            {
                Natives.xCF537FDE4FBD4CE5(scaleform2.Handle, color.R, color.G, color.B, color.A);
            }
        }

        public void CallFunction(string name, params object[] args)
        {
            Natives.xf6e48914c7a8694e(Handle, name);
            pushArgs(args);
            Natives.xc6796a8ffa375e53();
        }
        public bool CallFunctionBool(string name, params object[] args)
        {
            Natives.xf6e48914c7a8694e(Handle, name);
            pushArgs(args);
            int ret = Natives.xC50AA39A577AF886<int>();
            while (!Natives.x768FF8961BA904D6<bool>(ret)) Rage.GameFiber.Yield();
            return Natives.xD80A80346A45D761<bool>(ret);
        }
        public bool CallFunctionInt(string name, params object[] args)
        {
            Natives.xf6e48914c7a8694e(Handle, name);
            pushArgs(args);
            int ret = Natives.xC50AA39A577AF886<int>();
            while (!Natives.x768FF8961BA904D6<bool>(ret)) Rage.GameFiber.Yield();
            return Natives.x2DE7EFA66B906036<int>(ret);
        }
        public bool CallFunctionString(string name, params object[] args)
        {
            Natives.xf6e48914c7a8694e(Handle, name);
            pushArgs(args);
            int ret = Natives.xC50AA39A577AF886<int>();
            while (!Natives.x768FF8961BA904D6<bool>(ret)) Rage.GameFiber.Yield();
            return Natives.xE1E258829A885245<string>(ret);
        }

        private void pushArgs(object[] args)
        {
            foreach (object x in args)
            {
                if (x.GetType() == typeof(int)) Natives.xc3d0841a0cc546a6((int)x);
                else if (x.GetType() == typeof(float)) Natives.xd69736aae04db51a((float)x);
                else if (x.GetType() == typeof(double)) Natives.xd69736aae04db51a((float)(double)x);
                else if (x.GetType() == typeof(bool)) Natives.xc58424ba936eb458((bool)x);
                else if (x.GetType() == typeof(TXD)) Natives.xba7148484bd90365(((TXD)x).Texture);
                else if (x.GetType() == typeof(string))
                {
                    Natives.x80338406f3475e55("STRING");
                    Natives.x6c188be134e074aa((string)x);
                    Natives.x362e2d3fe93a9959();
                }
                else if (x.GetType() == typeof(char))
                {
                    Natives.x80338406f3475e55("STRING");
                    Natives.x6c188be134e074aa(((char)x).ToString());
                    Natives.x362e2d3fe93a9959();
                }
            }
        }
    }
    public class TXD
    {
        private readonly string texture;
        public string Texture { get { return texture; } }

        public TXD(string texture)
        {
            this.texture = texture;
        }
    }
}