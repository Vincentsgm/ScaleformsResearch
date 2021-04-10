using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class CovertOps : BusinessScreen
    {
        public override string MovieName => "COVERT_OPS";

        private List<GameControl> inputs = new List<GameControl>
        {
            GameControl.FrontendLeft,
            GameControl.FrontendRight,
            GameControl.FrontendUp,
            GameControl.FrontendDown,
            GameControl.FrontendAccept,
            GameControl.FrontendCancel
        };
        public override List<GameControl> Inputs { get => inputs; set => throw new NotImplementedException(); }

        public string PlayerData { set => CallFunction("SET_PLAYER_DATA", value); }

        public void AddMission(int id, string name, string description, string txd, int lockNum, bool enabled, int cashBonus, int rpBonus) => CallFunction("ADD_MISSION", id, name, description, txd, lockNum, enabled, cashBonus, rpBonus);

        int cooldown;
        public int Cooldown
        {
            get => cooldown;
            set
            {
                cooldown = Math.Max(0, value);
                CallFunction("UPDATE_COOLDOWN", cooldown);
            }
        }

        protected override void ProcessControl(GameControl control)
        {
            if (control == GameControl.FrontendAccept && GetCurrentScreenID != 0)
            {
                ShowOverlay("Alert", "Do you want to start the mission?", "Yes", "No");
            }
            else if (control == GameControl.FrontendCancel)
            {
                HideOverlay();
            }
        }

        protected override void OnTestStart()
        {
            ShowScreen(0);
            PlayerData = "Vincentsgm";
            string[] textures = new string[] {
                "arcadeui_love_prof",
                "arcadeui_monkeys_paradise",
                "arcadeui_nazar",
                "arcadeui_penetrator",
                "arcadeui_race_bike",
                "arcadeui_race_car"
            };
            for (int i = 0; i < 6; i++)
            {
                AddMission(i, $"Mission {i}", $"Mission Description {i}", textures[i], i, i % 2 == 0, 10_000 * i, 69 * i);
            }
        }

        protected override void OnTestTick()
        {
            DisableHUD();
            CheckInputs();            
            if (Game.IsKeyDown(Keys.NumPad1)) Cooldown += 10;
        }

    }
}
