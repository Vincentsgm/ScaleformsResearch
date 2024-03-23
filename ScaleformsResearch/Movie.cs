using Rage;
using static Rage.Native.NativeFunction;
using Color = System.Drawing.Color;

namespace ScaleformsResearch
{
    public abstract class Movie
    {
        public int Handle { get; private set; } = 0;
        public Color Color { get; set; } = Color.White;
        public bool IsLoaded { get { return !IsReleased && Handle != 0 && Natives.HAS_SCALEFORM_MOVIE_LOADED<bool>(Handle); } }

        public bool FitsRenderTarget { set => Natives.SET_SCALEFORM_MOVIE_TO_USE_SUPER_LARGE_RT(Handle, value); }

        public bool IsReleased { get; private set; }

        public abstract string MovieName { get; }

        protected virtual string TestHelpMessage => "";

        public bool Load()
        {
            if (IsLoaded) return true;
            IsReleased = false;
            Handle = Natives.REQUEST_SCALEFORM_MOVIE<int>(MovieName);
            return Handle != 0;
        }

        public bool LoadAndWait()
        {
            bool x = Load();
            while (!IsLoaded) GameFiber.Sleep(1);
            return x;
        }

        public void Release()
        {
            int h = Handle;
            Natives.SET_SCALEFORM_MOVIE_AS_NO_LONGER_NEEDED(ref h);
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
            BeforeDraw();
            Natives.DRAW_SCALEFORM_MOVIE_FULLSCREEN(Handle, Color.R, Color.G, Color.B, Color.A);
        }

        public void Draw2D(float x, float y, float w, float h)
        {
            if (!IsLoaded) return;
            BeforeDraw();
            Natives.DRAW_SCALEFORM_MOVIE(Handle, x, y, w, h, Color.R, Color.G, Color.B, Color.A);
        }

        public void Draw3D(Vector3 position, Rotator rotation, Vector3 scale, bool solid = true)
        {
            if (IsLoaded)
            {
                BeforeDraw();
                if (solid)
                    Natives.DRAW_SCALEFORM_MOVIE_3D_SOLID(Handle, position.X, position.Y, position.Z, rotation.Pitch, rotation.Roll, rotation.Yaw, 2, 2, 1, scale.X, scale.Y, scale.Z, 2);
                else
                    Natives.DRAW_SCALEFORM_MOVIE_3D(Handle, position.X, position.Y, position.Z, rotation.Pitch, rotation.Roll, rotation.Yaw, 2, 2, 1, scale.X, scale.Y, scale.Z, 2);
            }
        }

        public void DrawMasked(Movie scaleform2, Color color)
        {
            if (IsLoaded && (scaleform2?.IsLoaded ?? false))
            {
                BeforeDraw();
                scaleform2.BeforeDraw();
                Natives.DRAW_SCALEFORM_MOVIE_FULLSCREEN_MASKED(Handle, scaleform2.Handle, color.R, color.G, color.B, color.A);
            }
        }

        protected virtual void BeforeDraw()
        {

        }

        internal void TestStart()
        {
            OnTestStart();
        }
        internal void TestTick()
        {
            if (TestHelpMessage != "")
            {
                Game.DisplayHelp(TestHelpMessage);
            }
            TestDraw();
            OnTestTick();
        }
        internal void TestEnd()
        {
            OnTestEnd();
        }
        protected virtual void TestDraw()
        {
            Draw();
        }
        protected virtual void OnTestStart()
        {

        }
        protected virtual void OnTestTick()
        {

        }
        protected virtual void OnTestEnd()
        {

        }

        public void CallFunction(string name, params object[] args)
        {
            Natives.BEGIN_SCALEFORM_MOVIE_METHOD(Handle, name);
            pushArgs(args);
            Natives.END_SCALEFORM_MOVIE_METHOD();
        }
        public bool CallFunctionBool(string name, params object[] args)
        {
            Natives.BEGIN_SCALEFORM_MOVIE_METHOD(Handle, name);
            pushArgs(args);
            int ret = Natives.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE<int>();
            while (!Natives.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY<bool>(ret)) GameFiber.Yield();
            return Natives.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_BOOL<bool>(ret);
        }
        public int CallFunctionInt(string name, params object[] args)
        {
            Natives.BEGIN_SCALEFORM_MOVIE_METHOD(Handle, name);
            pushArgs(args);
            int ret = Natives.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE<int>();
            while (!Natives.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY<bool>(ret)) GameFiber.Yield();
            return Natives.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_INT<int>(ret);
        }
        public string CallFunctionString(string name, params object[] args)
        {
            Natives.BEGIN_SCALEFORM_MOVIE_METHOD(Handle, name);
            pushArgs(args);
            int ret = Natives.END_SCALEFORM_MOVIE_METHOD_RETURN_VALUE<int>();
            while (!Natives.IS_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_READY<bool>(ret)) GameFiber.Yield();
            return Natives.GET_SCALEFORM_MOVIE_METHOD_RETURN_VALUE_STRING<string>(ret);
        }

        protected void pushArgs(object[] args)
        {
            foreach (object x in args)
            {
                if (x.GetType() == typeof(int)) Natives.SCALEFORM_MOVIE_METHOD_ADD_PARAM_INT((int)x);
                else if (x.GetType() == typeof(float)) Natives.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT((float)x);
                else if (x.GetType() == typeof(double)) Natives.SCALEFORM_MOVIE_METHOD_ADD_PARAM_FLOAT((float)(double)x);
                else if (x.GetType() == typeof(bool)) Natives.SCALEFORM_MOVIE_METHOD_ADD_PARAM_BOOL((bool)x);
                else if (x.GetType() == typeof(TXD)) Natives.SCALEFORM_MOVIE_METHOD_ADD_PARAM_TEXTURE_NAME_STRING(((TXD)x).Texture);
                else if (x.GetType() == typeof(string))
                {
                    Natives.BEGIN_TEXT_COMMAND_SCALEFORM_STRING("STRING");
                    Natives.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME((string)x);
                    Natives.END_TEXT_COMMAND_SCALEFORM_STRING();
                }
                else if (x.GetType() == typeof(char))
                {
                    Natives.BEGIN_TEXT_COMMAND_SCALEFORM_STRING("STRING");
                    Natives.ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME(((char)x).ToString());
                    Natives.END_TEXT_COMMAND_SCALEFORM_STRING();
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