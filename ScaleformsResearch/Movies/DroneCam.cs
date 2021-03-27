using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class DroneCam : Movie
    {
        public override string MovieName => "DRONE_CAM";

        #region TOGGLES
        bool reticleIsVisible;
        public bool ReticleIsVisible { get => reticleIsVisible; set { reticleIsVisible = value; CallFunction("SET_RETICLE_IS_VISIBLE", value); } }
        bool zoomMeterVisible;
        public bool ZoomMeterVisible { get => zoomMeterVisible; set { zoomMeterVisible = value; CallFunction("SET_ZOOM_METER_IS_VISIBLE", value); } }
        bool headingMeterVisible;
        public bool HeadingMeterVisible { get => headingMeterVisible; set { headingMeterVisible = value; CallFunction("SET_HEADING_METER_IS_VISIBLE", value); } }
        bool shockMeterVisible;
        public bool ShockMeterVisible { get => shockMeterVisible; set { shockMeterVisible = value; CallFunction("SET_SHOCK_METER_IS_VISIBLE", value); } }
        bool detonateMeterVisible;
        public bool DetonateMeterVisible { get => detonateMeterVisible; set { detonateMeterVisible = value; CallFunction("SET_DETONATE_METER_IS_VISIBLE", value); } }
        bool tranquilizeMeterVisible;
        public bool TranquilizeMeterVisible { get => tranquilizeMeterVisible; set { tranquilizeMeterVisible = value; CallFunction("SET_TRANQUILIZE_METER_IS_VISIBLE", value); } }
        bool boostMeterVisible;
        public bool BoostMeterVisible { get => boostMeterVisible; set { boostMeterVisible = value; CallFunction("SET_BOOST_METER_IS_VISIBLE", value); } }
        bool missileMeterVisible;
        public bool MissileMeterVisible { get => missileMeterVisible; set { missileMeterVisible = value; CallFunction("SET_MISSILE_METER_IS_VISIBLE", value); } }
        bool empMeterVisible;
        public bool EMPMeterVisible { get => empMeterVisible; set { empMeterVisible = value; CallFunction("SET_EMP_METER_IS_VISIBLE", value); } }
        bool infoListVisible;
        public bool InfoListVisible { get => infoListVisible; set { infoListVisible = value; CallFunction("SET_INFO_LIST_IS_VISIBLE", value); } }
        bool soundWaveVisible;
        public bool SoundWaveVisible { get => soundWaveVisible; set { soundWaveVisible = value; CallFunction("SET_SOUND_WAVE_IS_VISIBLE", value); } }
        bool leftCornerVisible;
        public bool LeftCornerVisible { get => leftCornerVisible; set { leftCornerVisible = value; CallFunction("SET_BOTTOM_LEFT_CORNER_IS_VISIBLE", value); } }
        bool warningVisible;
        public bool WarningVisible { get => warningVisible; set { warningVisible = value; CallFunction("SET_WARNING_IS_VISIBLE", value); } }
        public void SetZoomLabel(int index, string label) => CallFunction("SET_ZOOM_LABEL", index, label);
        #endregion

        #region VALUES
        int zoom;
        public int Zoom
        {
            get => zoom;
            set
            {
                zoom = value.Clamp(0, 100);
                CallFunction("SET_ZOOM", zoom);
            }
        }
        int heading;
        public int Heading
        {
            get => heading;
            set
            {
                heading = value % 360;
                CallFunction("SET_HEADING", heading);
            }
        }
        int shockPercentage;
        public int ShockPercentage
        {
            get => shockPercentage;
            set
            {
                shockPercentage = value.Clamp(0, 100);
                CallFunction("SET_SHOCK_PERCENTAGE", shockPercentage);
            }
        }
        int detonatePercentage;
        public int DetonatePercentage
        {
            get => detonatePercentage;
            set
            {
                detonatePercentage = value.Clamp(0, 100);
                CallFunction("SET_DETONATE_PERCENTAGE", detonatePercentage);
            }
        }
        int tranquilizePercentage;
        public int TranquilizePercentage
        {
            get => tranquilizePercentage;
            set
            {
                tranquilizePercentage = value.Clamp(0, 100);
                CallFunction("SET_TRANQUILIZE_PERCENTAGE", tranquilizePercentage);
            }
        }
        int boostPercentage;
        public int BoostPercentage
        {
            get => boostPercentage;
            set
            {
                boostPercentage = value.Clamp(0, 100);
                CallFunction("SET_BOOST_PERCENTAGE", boostPercentage);
            }
        }
        int missilePercentage;
        public int MissilePercentage
        {
            get => missilePercentage;
            set
            {
                missilePercentage = value.Clamp(0, 100);
                CallFunction("SET_MISSILE_PERCENTAGE", missilePercentage);
            }
        }
        int empPercentage;
        public int EMPPercentage
        {
            get => empPercentage;
            set
            {
                empPercentage = value.Clamp(0, 100);
                CallFunction("SET_EMP_PERCENTAGE", empPercentage);
            }
        }
        public void SetInfoListData(int rank, int earnings, int kills, int deaths, string vehicle, float accuracy, string radioStation, string weapon, int privateDances, int numHoes, string gamertag) => CallFunction("SET_INFO_LIST_DATA", rank, earnings, kills, deaths, vehicle, accuracy, radioStation, weapon, privateDances, numHoes, gamertag);
        float attenuateSoundWave;
        public float AttenuateSoundWave
        {
            get => attenuateSoundWave;
            set
            {
                attenuateSoundWave = value.Clamp(0f, 1f);
                CallFunction("ATTENUATE_SOUND_WAVE", attenuateSoundWave);
            }
        }
        int reticlePercentage;
        public int ReticlePercentage
        {
            get => reticlePercentage;
            set
            {
                reticlePercentage = value.Clamp(0, 100);
                CallFunction("SET_RETICLE_PERCENTAGE", reticlePercentage);
            }
        }
        bool reticleOnTarget;
        public bool ReticleOnTarget
        {
            get => reticleOnTarget;
            set
            {
                reticleOnTarget = value;
                CallFunction("SET_RETICLE_ON_TARGET", reticleOnTarget);
            }
        }
        public enum EnumReticleState
        {
            STATE_NORMAL = 0,
            STATE_FIRE = 1,
            STATE_CHARGING = 2
        }
        EnumReticleState reticleState;
        public EnumReticleState ReticleState
        {
            get => reticleState;
            set
            {
                reticleState = value;
                CallFunction("SET_RETICLE_STATE", (int)reticleState);
            }
        }
        float warningFlashRate;
        public float WarningFlashRate
        {
            get => warningFlashRate;
            set
            {
                warningFlashRate = value.Clamp(0f, 1f);
                CallFunction("SET_WARNING_FLASH_RATE", warningFlashRate);
            }
        }
        #endregion

        protected override void OnTestStart()
        {
            Refresh();

            HeadingMeterVisible = true;
            SetInfoListData(999, 10000, 69, 420, "Vehicle", 10f, "Radio Station", "RPG", 0, 1, "Vincentsgm");
            SetZoomLabel(0, "Zoom Label");
        }

        protected override void OnTestTick()
        {
            Heading = (int)Util.MainPlayer.Heading;
            if (Game.IsKeyDown(Keys.NumPad1)) ReticleIsVisible = !ReticleIsVisible;
            else if (Game.IsKeyDown(Keys.NumPad2)) ZoomMeterVisible = !ZoomMeterVisible;
            else if (Game.IsKeyDown(Keys.NumPad3)) HeadingMeterVisible = !HeadingMeterVisible;
            else if (Game.IsKeyDown(Keys.NumPad4)) ShockMeterVisible = !ShockMeterVisible;
            else if (Game.IsKeyDown(Keys.NumPad5)) DetonateMeterVisible = !DetonateMeterVisible;
            else if (Game.IsKeyDown(Keys.NumPad6)) TranquilizeMeterVisible = !TranquilizeMeterVisible;
            else if (Game.IsKeyDown(Keys.NumPad7)) MissileMeterVisible = !MissileMeterVisible;
            else if (Game.IsKeyDown(Keys.NumPad8)) EMPMeterVisible = !EMPMeterVisible;
            else if (Game.IsKeyDown(Keys.NumPad9)) SoundWaveVisible = !SoundWaveVisible;
            else if (Game.IsKeyDown(Keys.NumPad0)) LeftCornerVisible = !LeftCornerVisible;
            else if (Game.IsKeyDown(Keys.Add)) WarningVisible = !WarningVisible;
            else if (Game.IsKeyDown(Keys.Subtract)) InfoListVisible = !InfoListVisible;
        }
    }
}
