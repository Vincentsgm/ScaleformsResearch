using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadMusician.Common;

namespace ScaleformsResearch.Movies
{
    internal class TurretCam : Movie
    {
        public override string MovieName => "TURRET_CAM";

        float heading;
        public float Heading
        {
            get => heading;
            set
            {
                heading = value;
                CallFunction("SET_CAM_HEADING", heading);
            }
        }
        float fov;
        public float FOV
        {
            get => fov;
            set
            {
                fov = value.Clamp(0f, 130f) / 130f;
                CallFunction("SET_CAM_FOV", fov);
            }
        }
        float altitude;
        public float Altitude
        {
            get => altitude;
            set
            {
                altitude = value;
                CallFunction("SET_CAM_ALT", altitude);
            }
        }

        public void SetAltFovHeading(float alt, float fov, float heading) => CallFunction("SET_ALT_FOV_HEADING", alt, fov, heading);

        int logo;
        public int Logo
        {
            get => logo;
            set
            {
                logo = value;
                CallFunction("SET_CAM_LOGO", logo);
            }
        }

        protected override void OnTestStart()
        {
            //Logo = 1;
            TimecycleModifier.SetTimecycle("heliGunCam");
        }

        protected override void OnTestTick()
        {
            Heading = GameplayCamera.Rotation.Yaw;
            FOV = GameplayCamera.FOV;
            Altitude = GameplayCamera.Position.Z;
            //SetAltFovHeading(Altitude, FOV, Heading);
        }

        protected override void OnTestEnd()
        {
            TimecycleModifier.ClearTimecycle();
        }
    }
}
