using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Rage;

namespace ScaleformsResearch.Movies
{
    internal class EGCMonitor : Movie
    {
        public override string MovieName => "EGC_MONITOR";

        int heartRate;
        public int HeartRate
        {
            get => heartRate;
            set
            {
                heartRate = Math.Max(0, value);
                CallFunction("SET_HEART_RATE", heartRate);
            }
        }
        int heartSpeed;
        public int HeartSpeed
        {
            get => heartSpeed;
            set
            {
                heartSpeed = Math.Max(0, value);
                CallFunction("SET_HEART_SPEED", heartSpeed);
            }
        }
        int health;
        public int Health
        {
            get => health;
            set
            {
                health = Math.Max(0, value);
                CallFunction("SET_HEART_RATE", health);
            }
        }
        int egcHealth;
        public int EGCHealth
        {
            get => egcHealth;
            set
            {
                egcHealth = Math.Max(0, value);
                CallFunction("SET_HEART_RATE", egcHealth);
            }
        }
        Color monitorColor;
        public Color MonitorColor
        {
            get => monitorColor;
            set 
            {
                monitorColor = value;
                CallFunction("SET_COLOUR", value.R, value.G, value.B);
            }
        }

        protected override void OnTestStart()
        {
            HeartRate = 130;
            HeartSpeed = 80;
            Health = 100;
            EGCHealth = 69;
        }

        protected override void OnTestTick()
        {
            if (Game.IsKeyDown(Keys.NumPad7)) HeartRate+=5;
            else if (Game.IsKeyDown(Keys.NumPad4)) HeartRate-=5;
            else if (Game.IsKeyDown(Keys.NumPad8)) HeartSpeed+=5;
            else if (Game.IsKeyDown(Keys.NumPad5)) HeartSpeed-=5;
            else if (Game.IsKeyDown(Keys.NumPad9)) Health+=5;
            else if (Game.IsKeyDown(Keys.NumPad6)) Health-=5;
            else if (Game.IsKeyDown(Keys.NumPad1)) EGCHealth+=5;
            else if (Game.IsKeyDown(Keys.NumPad2)) EGCHealth-=5;

            if (Health > 80) MonitorColor = Color.Green;
            else if (Health > 60) MonitorColor = Color.Orange;
            else if (Health > 40) MonitorColor = Color.Yellow;
            else MonitorColor = Color.Red;
        }
    }
}
