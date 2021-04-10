using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rage;

namespace ScaleformsResearch.Movies
{
    internal class ArcadeManagement : BusinessScreen
    {
        public override string MovieName => "ARCADE_MANAGEMENT";

        private List<GameControl> inputs = new List<GameControl>
        {
            GameControl.FrontendLeft,
            GameControl.FrontendRight,
            GameControl.FrontendUp,
            GameControl.FrontendDown,
            GameControl.FrontendAccept,
            GameControl.FrontendCancel,
            /*GameControl.FrontendX,
            GameControl.FrontendY,
            GameControl.FrontendLb,
            GameControl.FrontendRb,
            GameControl.FrontendLt,
            GameControl.FrontendRt,
            GameControl.CursorAccept,
            GameControl.CursorCancel,
            GameControl.CursorScrollUp,
            GameControl.CursorScrollDown*/
        };
        public override List<GameControl> Inputs { get => inputs; set => throw new NotImplementedException(); }

        //Compatible textures: https://badmusician.ru/gta/textures/?q=_ext&r=scaleform_web
        public void SetPlayerData(string gamername, string mugshot, string location, string arcadeTexture, int totalEarnings) => CallFunction("SET_PLAYER_DATA", gamername, mugshot, location, arcadeTexture, totalEarnings);
        public void AddCabinet(int id, string name, string description, CabinetTexture texture, int price, int salePrice, bool owned) => CallFunction("ADD_CABINET", id, name, description, texture.ToString(), price, salePrice, owned);

        public enum CabinetTexture
        {
            cabinet_1 = 1,
            cabinet_2,
            cabinet_3,
            cabinet_4,
            cabinet_5,
            cabinet_6,
            cabinet_7,
            cabinet_8,
            cabinet_9,
            cabinet_10,
            cabinet_11,
            cabinet_12,
            cabinet_13,
            cabinet_14,
            cabinet_15,
            cabinet_16
        }

        public void AddUpgrade(int id, string name, string description, ArcadeUpgrade texture, int price, int salePrice, bool owned) => CallFunction("ADD_UPGRADE", id, name, description, texture.ToString(), price, salePrice, owned);

        public enum ArcadeUpgrade
        {
            upgrade_1,
            upgrade_2
        }

        public bool IsHistoryEmpty => CallFunctionBool("IS_HISTORY_EMPTY");

        protected override void OnTestStart()
        {
            SetPlayerData("Vincentsgm", "CHAR_ABIGAIL", "France", "MP_ARC1", 666);
            AddCabinet(0, "Cabinet Name 1", "Cabinet Description", CabinetTexture.cabinet_1, 420, 69, true);
            AddCabinet(1, "Cabinet Name 2", "Cabinet Description", CabinetTexture.cabinet_2, 666, 420, false);
            AddCabinet(2, "Cabinet Name 3", "Cabinet Description", CabinetTexture.cabinet_3, 666, 420, false);
            AddUpgrade(0, "Upgrade 1", "Upgrade description", ArcadeUpgrade.upgrade_1, 420, 69, true);
            AddUpgrade(1, "Upgrade 2", "Upgrade description", ArcadeUpgrade.upgrade_2, 666, 420, true);

            ShowScreen(0);            
        }

        protected override void OnTestTick()
        {
            CheckInputs();
            if (Game.IsKeyDown(Keys.NumPad0)) ShowScreen(0);
            else if (Game.IsKeyDown(Keys.NumPad1)) ShowScreen(1);
            else if (Game.IsKeyDown(Keys.NumPad2)) ShowScreen(2);
            else if (Game.IsKeyDown(Keys.NumPad3)) ShowScreen(3);
        }
    }
}
