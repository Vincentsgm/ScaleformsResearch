using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMusician.Common;

namespace ScaleformsResearch.Movies
{
    internal class SubCam : Movie
    {
        public override string MovieName => "SUB_CAM";

        public float CamHeading { set => CallFunction("SET_CAM_HEADING", value); }
        public float CamFov { set => CallFunction("SET_CAM_FOV", value.Clamp(0f, 130f)); }
        public float CamAltitude { set => CallFunction("SET_CAM_ALT", value); }
        public void SetCamCursorPos(float x, float y) => CallFunction("SET_CAM_CURSOR_POS", x, y);

        AnimPostFX postFX;

        protected override void OnTestStart()
        {
            postFX = new AnimPostFX(AnimPostFXEffect.MP_OrbitalCannon, 0, true);
        }

        protected override void OnTestTick()
        {
            CamHeading = GameplayCamera.Rotation.Yaw;
            CamFov = GameplayCamera.FOV;
            CamAltitude = GameplayCamera.Position.Z;
            SetCamCursorPos(0.5f, 0.5f);
        }

        protected override void OnTestEnd()
        {
            postFX.Dispose();
        }

        protected override void TestDraw()
        {
            Draw2D(0.5f, 0.5f, 1f, 1f);
        }
    }
}
