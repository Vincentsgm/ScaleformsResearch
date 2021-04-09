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
    internal class ECGMonitor : Movie
    {
        public override string MovieName => "ECG_MONITOR";

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
        int heartBeat;
        public int HeartBeat
        {
            get => heartBeat;
            set
            {
                heartBeat = Math.Max(0, value);
                CallFunction("SET_HEART_BEAT", heartBeat);
            }
        }
        int health;
        public int Health
        {
            get => health;
            set
            {
                health = Math.Max(0, value);
                CallFunction("SET_HEALTH", health);
            }
        }
        int ecgHealth;
        public int ECGHealth
        {
            get => ecgHealth;
            set
            {
                ecgHealth = Math.Max(0, value);
                CallFunction("SET_ECG_HEALTH", ecgHealth);
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
        bool widescreen;
        public bool Widescreen { get => widescreen; set { widescreen = value; CallFunction("SET_WIDESCREEN", widescreen); } }

        protected override void OnTestStart()
        {
            HeartRate = 130;
            HeartBeat = 80;
            Health = 100;
            ECGHealth = 69;
        }

        protected override void TestDraw()
        {
            //Draw2D(0.5f, 0.5f, 1f, 1f);
            Draw();
        }

        protected override void OnTestTick()
        {
            if (Game.IsKeyDown(Keys.NumPad7)) HeartRate += 5;
            else if (Game.IsKeyDown(Keys.NumPad4)) HeartRate -= 5;
            else if (Game.IsKeyDown(Keys.NumPad8)) HeartBeat += 5;
            else if (Game.IsKeyDown(Keys.NumPad5)) HeartBeat -= 5;
            else if (Game.IsKeyDown(Keys.NumPad9)) Health += 5;
            else if (Game.IsKeyDown(Keys.NumPad6)) Health -= 5;
            else if (Game.IsKeyDown(Keys.NumPad1)) ECGHealth += 5;
            else if (Game.IsKeyDown(Keys.NumPad2)) ECGHealth -= 5;
            else if (Game.IsKeyDown(Keys.NumPad3)) Widescreen = !Widescreen;

            if (Health > 80) MonitorColor = Color.Green;
            else if (Health > 60) MonitorColor = Color.Orange;
            else if (Health > 40) MonitorColor = Color.Yellow;
            else MonitorColor = Color.Red;
        }
    }
}
