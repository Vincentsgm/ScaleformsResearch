using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class LandingPage : Movie
    {
        public override string MovieName => "LANDING_PAGE";

        private int buttonSelected;
        public int ButtonSelected { get => buttonSelected; set { buttonSelected = value.Clamp(0, actions.Count - 1); CallFunction("SET_BUTTON_SELECTED", buttonSelected); } }

        public Dictionary<int, Action> actions = new Dictionary<int, Action>();

        public void PlayNavigationSound() => new Sound(-1).PlayFrontend("NAV_LEFT_RIGHT", "HUD_FRONTEND_DEFAULT_SOUNDSET");
        public void PlaySelectSound() => new Sound(-1).PlayFrontend("SELECT", "HUD_FRONTEND_DEFAULT_SOUNDSET");

        public void AddButtons(IEnumerable<Tuple<string, Action>> buttons)
        {
            string[] buttonLabels = new string[12];
            for (int i = 0; i < Math.Min(12, buttons.Count()); i++)
            {
                var button = buttons.ElementAt(i);
                buttonLabels[i] = button.Item1;
                actions.Add(i, button.Item2);
            }
            string[] labels = buttonLabels.Where(l => l != null).ToArray();
            CallFunction("INIT_LANDING_PAGE", labels);

        }

        public void Init() => CallFunction("INIT_LANDING_PAGE");

        protected override string TestHelpMessage => $"~y~Numpad4/6: ~s~Change selection ~b~{buttonSelected}\n" +
            $"~y~Numpad5: ~s~Perform binded action";

        protected override void OnTestStart()
        {
            Refresh();
            Init();            
            AddButtons(new List<Tuple<string, Action>>
            {
                new Tuple<string, Action>("Spawn cop", () => new Ped("s_m_y_cop_01", Util.MainPlayer.GetOffsetPositionFront(5f), 0f)),
                new Tuple<string, Action>("Spawn S.W.A.T.", () => new Ped("s_m_y_swat_01", Util.MainPlayer.GetOffsetPositionFront(5f), 0f)),
                new Tuple<string, Action>("Get RPG", () => Util.MainPlayer.Inventory.GiveNewWeapon(WeaponHash.RPG, 20, true))
            });
            ButtonSelected = 0;
        }

        protected override void OnTestTick()
        {
            if (Game.IsKeyDown(Keys.NumPad6))
            {
                ButtonSelected++;
                PlayNavigationSound();
            }
            else if (Game.IsKeyDown(Keys.NumPad4))
            {
                ButtonSelected--;
                PlayNavigationSound();
            }
            else if (Game.IsKeyDown(Keys.NumPad5))
            {
                PlaySelectSound();
                actions[ButtonSelected]();
            }
        }

    }
}
