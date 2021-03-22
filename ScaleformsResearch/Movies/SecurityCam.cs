using Rage;
using System;
using System.Linq;
using System.Windows.Forms;

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

        string[] t_locations = new string[] { "loc 1", "loc 2", "loc 3" };
        string[] t_details = new string[] { "detail 1", "detail 2", "detail 3" };
        int t_currentLocation = 0;
        int t_currentDetail = 0;
        protected override void OnTestStart()
        {
            base.OnTestStart();
            Layout = SecurityCamLayout.CameraLike;
            Location = t_locations[0];
            Details = t_details[0];
        }
        protected override void OnTestTick()
        {
            base.OnTestTick();
            if (Game.IsKeyDown(Keys.NumPad4))
            {
                t_currentLocation = MathHelper.Clamp(t_currentLocation + 1, 0, t_locations.Count() - 1);
                Location = t_locations[t_currentLocation];
            }
            else if (Game.IsKeyDown(Keys.NumPad1))
            {
                t_currentLocation = MathHelper.Clamp(t_currentLocation - 1, 0, t_locations.Count() - 1);
                Location = t_locations[t_currentLocation];
            }
            else if (Game.IsKeyDown(Keys.NumPad5))
            {
                t_currentDetail = MathHelper.Clamp(t_currentDetail + 1, 0, t_details.Count() - 1);
                Details = t_details[t_currentDetail];
            }
            else if (Game.IsKeyDown(Keys.NumPad2))
            {
                t_currentDetail = MathHelper.Clamp(t_currentDetail - 1, 0, t_details.Count() - 1);
                Details = t_details[t_currentDetail];
            }
        }
        protected override string TestHelpMessage => $"~y~{Keys.NumPad4}~s~ - Next Location~n~~y~{Keys.NumPad1}~s~ - Previous Location~n~~y~{Keys.NumPad5}~s~ - Next Details~n~~y~{Keys.NumPad2}~s~ - Previous Details";
    }
}