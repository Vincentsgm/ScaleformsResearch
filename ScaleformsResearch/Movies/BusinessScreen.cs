using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;

namespace ScaleformsResearch.Movies
{
    internal abstract class BusinessScreen : Movie
    {
        public abstract List<GameControl> Inputs { get; set; }

        protected virtual void CheckInputs()
        {
            foreach (GameControl input in Inputs)
            {
                if (Game.IsControlJustReleased(0, input))
                {
                    SetInputEvent(input);
                    ProcessControl(input);
                    break;
                }
            }
        }

        protected virtual void ProcessControl(GameControl control)
        {

        }

        protected virtual void DisableHUD()
        {
            Game.DisableControlAction(0, GameControl.Phone, true);
            Game.DisableControlAction(0, GameControl.SelectWeapon, true);
            Game.DisableControlAction(0, GameControl.CharacterWheel, true);
            Rage.Native.NativeFunction.Natives.HIDE_HUD_AND_RADAR_THIS_FRAME();
        }

        public void ShowScreen(int screenID) => CallFunction("SHOW_SCREEN", screenID);

        public void ShowOverlay(string title, string message, string acceptButtonLabel, string cancelButtonLabel) => CallFunction("SHOW_OVERLAY", title, message, acceptButtonLabel, cancelButtonLabel);
        public void HideOverlay() => CallFunction("HIDE_OVERLAY");

        public void SetInputEvent(GameControl control) => CallFunction("SET_INPUT_EVENT", (int)control);
        public void SetInputReleaseEvent(GameControl control) => CallFunction("SET_INPUT_RELEASE_EVENT", (int)control);
        public void SetAnalogStickInput(bool isLeftStick, float x, float y, bool isMouseWheel) => CallFunction("SET_ANALOG_STICK_INPUT", isLeftStick, x, y, isMouseWheel);
        public void SetMouseInput(float x, float y) => CallFunction("SET_MOUSE_INPUT", x, y);

        public int GetCurrentSelection { get => CallFunctionInt("GET_CURRENT_SELECTION"); }
        public int GetCurrentRollover { get => CallFunctionInt("GET_CURRENT_ROLLOVER"); }
        public int GetCurrentScreenID { get => CallFunctionInt("GET_CURRENT_SCREEN_ID"); }
    }
}
