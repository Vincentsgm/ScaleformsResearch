using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class RemoteSniperHud : Movie
    {
        public override string MovieName => "REMOTE_SNIPER_HUD";

        private int zoomLevel;
        public int ZoomLevel
        {
            get => zoomLevel;
            set
            {
                zoomLevel = Math.Max(0, value);
                CallFunction("SET_ZOOM_LEVEL", zoomLevel);
            }
        }
        public void SetWind(float windValue, bool directionIsRight) => CallFunction("SET_WIND", windValue, directionIsRight);

        private float compass;
        public float Compass
        {
            get => compass;
            set
            {
                compass = value;//value.Clamp(0f, 360f);
                CallFunction("SET_COMPASS", compass);
            }
        }

        RemoteSniperLoading sniperLoading;
        AnimPostFX sniperPostFx;

        protected override void OnTestStart()
        {
            sniperLoading = new RemoteSniperLoading();
            sniperLoading.LoadAndWait();
            sniperPostFx = new AnimPostFX(AnimPostFXEffect.SniperOverlay, 0, true);
        }

        protected override void OnTestTick()
        {
            Compass = BadMusician.Common.GameplayCamera.Rotation.Yaw;
            ZoomLevel = (int)BadMusician.Common.GameplayCamera.FOV;
            SetWind(Rage.Native.NativeFunction.Natives.GET_WIND_SPEED<float>(), true);
        }

        protected override void OnTestEnd()
        {
            if (sniperLoading != null && sniperLoading.IsLoaded) sniperLoading.Release();
            if (sniperPostFx.IsRunning) sniperPostFx.Dispose();
        }

        protected override void TestDraw()
        {
            //DrawMasked(sniperLoading, Color);
            //sniperLoading.DrawMasked(this, Color);
            Rage.Native.NativeFunction.Natives.SET_WIDESCREEN_FORMAT(0);
            //base.TestDraw();
            Draw2D(0.5f, 0.5f, 1f, 1f);
        }
    }
}
