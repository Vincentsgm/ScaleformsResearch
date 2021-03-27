using static Rage.Native.NativeFunction;
using Rage;

namespace BadMusician.Common
{
    public static class GameplayCamera
    {
        public static CameraMode FollowPedMode
        {
            get { return (CameraMode)Natives.GET_FOLLOW_PED_CAM_VIEW_MODE<int>(); }
            set { Natives.SET_FOLLOW_PED_CAM_VIEW_MODE((int)value); }
        }

        public static CameraMode FollowVehicleMode
        {
            get { return (CameraMode)Natives.GET_FOLLOW_VEHICLE_CAM_VIEW_MODE<int>(); }
            set { Natives.SET_FOLLOW_VEHICLE_CAM_VIEW_MODE((int)value); }
        }

        public static float FOV { get { return Natives.GET_GAMEPLAY_CAM_FOV<float>(); } }
        public static bool IsLookingBehind { get { return Natives.IS_GAMEPLAY_CAM_LOOKING_BEHIND<bool>(); } }
        public static bool IsShaking { get { return Natives.IS_GAMEPLAY_CAM_SHAKING<bool>(); } }
        public static Vector3 Position { get { return Natives.GET_GAMEPLAY_CAM_COORD<Vector3>(); } }

        public static Rotator Rotation
        {
            get
            {
                Vector3 x = Natives.GET_GAMEPLAY_CAM_ROT<Vector3>(0);
                return new Rotator(x.X, x.Y, x.Z);
            }
        }

        public static void AnimateZoom(float fromDistance) => Natives.xDF2E1F7742402E81(1f, fromDistance);

        public static void SetShakeAmplitude(float value) => Natives.SET_GAMEPLAY_CAM_SHAKE_AMPLITUDE(value);

        public static void Shake(CameraShake shake, float intensity) => Natives.SHAKE_GAMEPLAY_CAM(shake.ToString(), intensity);

        public static void StopShaking() => Natives.STOP_GAMEPLAY_CAM_SHAKING(0);

        public static void RenderScriptCams() => Natives.RENDER_SCRIPT_CAMS(true, true, 10, true, true, true);
    }

    public enum CameraMode
    {
        ThirdPresonClose,
        ThirdPersonMid,
        ThirdPersonFar,
        FirstPerson = 4,
    }

    public enum CameraShake
    {
        DEATH_FAIL_IN_EFFECT_SHAKE,
        DRUNK_SHAKE,
        FAMILY5_DRUG_TRIP_SHAKE,
        HAND_SHAKE,
        JOLT_SHAKE,
        LARGE_EXPLOSION_SHAKE,
        MEDIUM_EXPLOSION_SHAKE,
        SMALL_EXPLOSION_SHAKE,
        ROAD_VIBRATION_SHAKE,
        SKY_DIVING_SHAKE,
        VIBRATE_SHAKE,
    }
}