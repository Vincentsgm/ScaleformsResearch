using System;

namespace ScaleformsResearch.Movies
{
    public class SecurityCam : Movie
    {
        public override string MovieName => "SECURITY_CAM";

        private string details = "";
        private SecurityCamLayout layout = SecurityCamLayout.Default;
        private string location = "";
        private DateTime time = DateTime.MinValue;

        public string Details { get { return details; } set { details = value; CallFunction("SET_DETAILS", details); } }
        public SecurityCamLayout Layout { get { return layout; } set { if (layout != value) { layout = value; CallFunction("SET_LAYOUT", (int)layout); Time = Time; Location = Location; Details = Details; } } }
        public string Location { get { return location; } set { location = value; CallFunction("SET_LOCATION", location); } }
        public DateTime Time { get { return time; } set { time = value; CallFunction("SET_TIME", time.ToString("hh"), time.ToString("mm"), time.ToString("ss"), time.ToString("tt")); } }

        public enum SecurityCamLayout
        {
            Default,
            CameraLike,
        }
    }
}