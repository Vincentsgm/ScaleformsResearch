using Rage;
using Rage.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class Drilling : Movie
    {
        public override string MovieName => "DRILLING";

        private float speed = 0f, depth = 0f, drillPosition = 0f, temp = 0f;
        private float furthestPosition = 0f;

        public float Speed { get => speed; set { speed = value.Clamp(0f, 1f); CallFunction("SET_SPEED", speed); } }
        public float Depth { get => depth; set { depth = value.Clamp(0f, 1f); CallFunction("SET_HOLE_DEPTH", depth); } }
        public float DrillPosition { get => drillPosition; set 
            { 
                drillPosition = value.Clamp(0f, 1f); 
                CallFunction("SET_DRILL_POSITION", drillPosition); 
                ProcessPins(); 
                if (drillPosition > furthestPosition) furthestPosition = drillPosition;
            } 
        }
        public float Temperature { get => temp; set { temp = value.Clamp(0f, 1.02f); CallFunction("SET_TEMPERATURE", temp); ProcessTemperature(); } }
        public bool[] PinsBroken = new bool[4];
        public bool Pin1Broken = false, Pin2Broken = false, Pin3Broken = false, Pin4Broken = false;
        public readonly float[] PinsLevel = new float[] { 0.34f, 0.49f, 0.64f, 0.79f };
        private Sound DrillSound;

        private void ProcessPins()
        {
            for (int i = 0; i < PinsBroken.Length; i++) 
            {
                if (!PinsBroken[i] && DrillPosition > PinsLevel[i])
                {
                    PinsBroken[i] = true;
                    PlayBrokenPinSound();
                }
            }
        }

        private void ProcessTemperature()
        {
            if (Temperature > 1f)
            {
                temp = 1f;
                //does not seem to work
                new Sound(-1).PlayFromEntity("Drill_Jam", "DLC_HEIST_FLEECA_SOUNDSET", Util.MainPlayer, true, 0);
            }
        }

        private void PlayBrokenPinSound() => new Sound(-1).PlayFrontend("Drill_Pin_Break", "DLC_HEIST_FLEECA_SOUNDSET", true);

        protected override void OnTestStart()
        {
            Sound.RequestScriptAudioBank("DLC_MPHEIST/HEIST_FLEECA_DRILL");
            Sound.RequestScriptAudioBank("DLC_MPHEIST/HEIST_FLEECA_DRILL_2");
            DrillPosition = 0f;
            DrillSound = new Sound();
            //If you don't set p4 to true, the sound will not play!
            DrillSound.PlayFromEntity("Drill", "DLC_HEIST_FLEECA_SOUNDSET", Util.MainPlayer, true, 0);
            base.OnTestStart();
        }

        protected override void OnTestTick()
        {
            base.OnTestTick();
            if (DrillPosition > furthestPosition)
            {
                DrillSound.SetVariable("DrillState", 1f);
            }
            else
            {
                DrillSound.SetVariable("DrillState", 0f);
            }
            DrillSound.SetVariable("DrillHeat", Temperature);
            if (Game.IsKeyDown(Keys.NumPad4))
            {
                Speed += 0.1f;
            }
            else if (Game.IsKeyDown(Keys.NumPad1))
            {
                Speed -= 0.1f;
            }
            else if (Game.IsKeyDown(Keys.NumPad5))
            {
                DrillPosition += 0.01f;
            }
            else if (Game.IsKeyDown(Keys.NumPad2))
            {
                DrillPosition -= 0.01f;
            }
            else if (Game.IsKeyDown(Keys.NumPad6))
            {
                Temperature += 0.1f;
            }
            else if (Game.IsKeyDown(Keys.NumPad3))
            {
                Temperature -= 0.1f;
            }
        }

        protected override void OnTestEnd()
        {
            DrillSound.Stop();
            DrillSound.ReleaseId();
            
            base.OnTestEnd();
        }
        protected override string TestHelpMessage => $"~y~Num1/4~s~ - Speed ({Speed:0.0})~n~~y~Num2/5~s~ - Depth ({Depth:0.0})~n~~y~Num3/6~s~ - Temperature ({Temperature:0.0})~n~";
    }
}
