using static Rage.Native.NativeFunction;

namespace ScaleformsResearch
{
    public static class TimecycleModifier
    {
        public static void SetTimecycle(string timecycle) => Natives.x2C933ABF17A1DF41(timecycle);

        public static void SetTimecycleStrength(float strength) => Natives.x82E7FFCD5B2326B3(strength);

        public static void SetTimecycle(string timecycle, float strength)
        {
            SetTimecycle(timecycle);
            SetTimecycleStrength(strength);
        }

        public static void ClearTimecycle() => Natives.x0F07E7745A236711();
    }
}
