using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class DigitalSafeDisplay : Movie
    {
        public override string MovieName => "DIGITAL_SAFE_DISPLAY";

        public enum StateEnum
        {
            STATE_OFF = 0,
            STATE_NORMAL = 1,
            STATE_ERROR = 2,
            STATE_OPEN = 3
        }

        public StateEnum State
        {
            set => CallFunction("SET_STATE", (int)value);
        }

        int cursorPosition;
        public int CursorPosition
        {
            get => cursorPosition;
            set
            {
                cursorPosition = value.Clamp(0, 3);
                CallFunction("SET_CURSOR_POSITION", cursorPosition);
            }
        }

        public void ClearValue(int index) => CallFunction("CLEAR_VALUE", index);

        public void SoundDown() => new Sound(-1).PlayFrontend("Input_Code_Down", "Safe_Minigame_Sounds");
        public void SoundUp() => new Sound(-1).PlayFrontend("Input_Code_Up", "Safe_Minigame_Sounds");
        public void SoundOpen() => new Sound(-1).PlayFrontend("Safe_Door_Open", "DLC_Biker_Cracked_Sounds");

        int[] values = new int[3] { 0, 0, 0 };
        public int Value1
        {
            get => values[0];
            set
            {
                if (value < 0) value = 100 + value;
                values[0] = value % 100;
                SetValue(0, values[0]);
            }
        }
        public int Value2
        {
            get => values[1];
            set
            {
                if (value < 0) value = 100 + value;
                values[1] = value % 100;
                SetValue(1, values[1]);
            }
        }
        public int Value3
        {
            get => values[2];
            set
            {
                if (value < 0) value = 100 + value;
                values[2] = value % 100;
                SetValue(2, values[2]);
            }
        }
        private void SetValue(int index, int value) => CallFunction("SET_VALUE", index, value);

        int[] Code = new int[3];

        public bool Success
        {
            get => Value1 == Code[0] && Value2 == Code[1] && Value3 == Code[2];
        }

        public void SetCode(int val1, int val2, int val3)
        {
            Code[0] = val1;
            Code[1] = val2;
            Code[2] = val3;
        }

        protected override string TestHelpMessage => $"~y~Numpad4/6: ~s~Change selection\n" +
            $"~y~Numpad8/2: ~s~Change value\n" +
            $"Code: ~b~{Code[0]} {Code[1]} {Code[2]}";

        bool t_success;
        int t_scrollDelay = 20;

        protected override void OnTestStart()
        {
            Refresh();
            CursorPosition = 0;
            t_success = false;
            SetCode(33, 66, 99);
            Game.FrameRender += (s, e) => Draw();
        }

        protected override void OnTestTick()
        {
            if (!t_success)
            {
                if (Game.IsKeyDown(Keys.NumPad4)) CursorPosition--;
                else if (Game.IsKeyDown(Keys.NumPad6)) CursorPosition++;

                if (Game.IsKeyDownRightNow(Keys.NumPad8))
                {
                    SoundUp();
                    switch (CursorPosition)
                    {
                        case 0:
                            Value1++;
                            break;
                        case 1:
                            Value2++;
                            break;
                        case 2:
                            Value3++;
                            break;
                    }
                    GameFiber.Sleep(t_scrollDelay);
                }
                else if (Game.IsKeyDownRightNow(Keys.NumPad2))
                {
                    SoundDown();
                    switch (CursorPosition)
                    {
                        case 0:
                            Value1--;
                            break;
                        case 1:
                            Value2--;
                            break;
                        case 2:
                            Value3--;
                            break;
                    }
                    GameFiber.Sleep(t_scrollDelay);
                }

                if (Success)
                {
                    t_success = true;
                    SoundOpen();
                }                
            }            
        }

        protected override void OnTestEnd()
        {
            Game.FrameRender -= (s, e) => Draw();
        }

        protected override void TestDraw()
        {
            
        }
    }
}
