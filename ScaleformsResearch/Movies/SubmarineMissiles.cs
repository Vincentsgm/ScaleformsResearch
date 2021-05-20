using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;
using static Rage.Native.NativeFunction;
using BadMusician.Common;

namespace ScaleformsResearch.Movies
{
    internal class SubmarineMissiles : TurretCam
    {
        public override string MovieName => "SUBMARINE_MISSILES";

        bool zoomVisible;
        public bool ZoomVisible
        {
            get => zoomVisible;
            set
            {
                zoomVisible = value;
                CallFunction("SET_ZOOM_VISIBLE", zoomVisible);
            }
        }
        bool warningVisible;
        public bool WarningVisible
        {
            get => warningVisible;
            set
            {
                warningVisible = value;
                CallFunction("SET_WARNING_FLASH_RATE", WarningVisible);
            }
        }
        float warningFlashRate;
        public float WarningFlashRate
        {
            get => warningFlashRate;
            set
            {
                warningFlashRate = value.Clamp(0f, 1f);
                CallFunction("SET_WARNING_VISIBLE", warningFlashRate);
            }
        }

        protected override string TestHelpMessage => $"~y~Numpad4: ~s~Toggle zoom on/off\n" +
            $"~y~Numpad5: ~s~Toggle warning on/off\n" +
            $"~y~Numpad8/2: ~s~Change warning flash rate\n";

        private Rage.Object t_missile;
        private Camera t_camera;
        private bool t_landed;

        protected override void OnTestStart()
        {
            Refresh();
            t_missile = new Rage.Object("w_battle_airmissile_01", Util.MainPlayer.GetOffsetPositionFront(5f) + 5 * Vector3.WorldUp, Util.MainPlayer.Heading) { IsPersistent = true };
            t_camera = new Camera(true);
            t_camera.AttachToEntity(t_missile, 5 * Vector3.WorldSouth + Vector3.WorldNorth, true);
            t_missile.Velocity = 200 * t_missile.ForwardVector + 100 * Vector3.WorldUp;
            t_missile.Rotation = new Rotator(90f, 0f, 0f);
            WarningVisible = false;
        }

        protected override void OnTestTick()
        {
            base.OnTestTick();
            if (WarningVisible) { TimecycleModifier.ClearTimecycle(); }
            else TimecycleModifier.SetTimecycle("CAMERA_secuirity");
            
            if (!t_landed && t_missile && t_camera)
            {
                Game.DisplaySubtitle($"Height above ground: {(int)t_missile.HeightAboveGround}\n Warning visible: {warningVisible}\n Distance to player: {(int)t_missile.DistanceTo(Util.MainPlayer)}");
                WarningVisible = t_missile.DistanceTo(Util.MainPlayer) > 2000f;
                if (WarningVisible) WarningFlashRate = t_missile.DistanceTo(Util.MainPlayer) / 4000;
                t_missile.Velocity = 200f * GameplayCamera.Rotation.ToQuaternion().ToVector();
                t_missile.Rotation = t_missile.Velocity.ToQuaternion().ToRotation();
                Natives.SET_FOCUS_POS_AND_VEL(t_missile.Position, 0f, 0f, 0f);
                var rotation = t_missile.Rotation;
                rotation.Pitch += 20f;
                t_camera.Rotation = rotation;
                HitResult detectImpact = World.TraceLine(t_missile.Position, t_missile.GetOffsetPositionFront(1f), TraceFlags.IntersectEverything, t_missile);
                if (detectImpact.Hit || t_missile.HeightAboveGround < 1f)
                {
                    t_landed = true;
                    World.SpawnExplosion(t_missile.Position, 0, 50f, true, false, 10f);
                    t_missile.Delete();
                }
            }
            if (Game.IsKeyDown(Keys.NumPad4)) ZoomVisible = !ZoomVisible;
            else if (Game.IsKeyDown(Keys.NumPad5)) WarningVisible = !WarningVisible;
            else if (Game.IsKeyDown(Keys.NumPad8)) WarningFlashRate += 0.1f;
            else if (Game.IsKeyDown(Keys.NumPad2)) WarningFlashRate -= 0.1f;
        }

        protected override void OnTestEnd()
        {
            Game.FadeScreenOut(2000, false);            
            Camera.DeleteAllCameras();
            TimecycleModifier.ClearTimecycle();            
            Natives.CLEAR_FOCUS();
            GameFiber.Sleep(3000);
            Game.FadeScreenIn(2000, false);
        }
    }
}
