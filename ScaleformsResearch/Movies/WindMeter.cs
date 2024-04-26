using BadMusician.Common;
using Rage;
using System.Drawing;
using static Rage.Native.NativeFunction;

namespace ScaleformsResearch.Movies
{
    public class WindMeter : Movie
    {
        public override string MovieName => "WIND_METER";

        public void SetWindDirection(float windDirection, float strength) => CallFunction("SET_WIND_DIRECTION", windDirection, strength);
        public float CompassDirection { set => CallFunction("SET_COMPASS_DIRECTION", value); }
        public Color ArrowColor { set => CallFunction("TINT_WIND_POINTER", 0, value.R, value.G, value.B); }
        public Color BackgroundColor { set => CallFunction("TINT_WIND_POINTER", 1, value.R, value.G, value.B); }
        public int ArrowRotation { get => CallFunctionInt("__get__arrowRotation"); set => CallFunctionInt("__set__arrowRotation", value); }
        public int Strength { get => CallFunctionInt("__get__strength"); set => CallFunctionInt("__set__strength", value); }

        protected override void OnTestTick()
        {
            base.OnTestTick();

            Vector3 windDirection = Natives.GET_WIND_DIRECTION<Vector3>();
            float windHeading = MathHelper.ConvertDirectionToHeading(windDirection);
            float cameraDirection = GameplayCamera.Rotation.Yaw;
            float windSpeed = Natives.GET_WIND_SPEED<float>();
            float relativeWindDirection = cameraDirection - windHeading;
            SetWindDirection(relativeWindDirection, windSpeed);
            //BackgroundColor = windSpeed > 8 ? Color.Red : Color.Green;
        }
    }
}
