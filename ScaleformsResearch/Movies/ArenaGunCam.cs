using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rage;

namespace ScaleformsResearch.Movies
{
    internal abstract class ArenaGunCam : TurretCam
    {
        public int WeaponType { set => CallFunction("SET_WEAPON_TYPE", value); }
        public void SetWeaponValues(int machineGunVal, int missileVal, int pilotMissileVal) => CallFunction("SET_WEAPON_VALUES", machineGunVal, missileVal, pilotMissileVal);
        public bool ZoomVisible { set => CallFunction("SET_ZOOM_VISIBLE", value); }

        int t_weaponType;
        Random t_random;

        protected override void OnTestStart()
        {
            base.OnTestStart();
            t_random = new Random(DateTime.Now.Millisecond);
        }

        protected override void OnTestTick()
        {
            base.OnTestTick();
            if (Game.IsKeyDown(Keys.NumPad7)) WeaponType = t_weaponType++;
            else if (Game.IsKeyDown(Keys.NumPad4)) WeaponType = t_weaponType--;
            SetWeaponValues(t_random.Next(0, 100), t_random.Next(0, 100), t_random.Next(0, 100));
        }
    }

    internal class ArenaGunCamApocalypse : ArenaGunCam
    {
        public override string MovieName => "ARENA_GUN_CAM_APOCALYPSE";
    }

    internal class ArenaGunCamConsumer : ArenaGunCam
    {
        public override string MovieName => "ARENA_GUN_CAM_CONSUMER";
    }

    internal class ArenaGunCamScifi: ArenaGunCam
    {
        public override string MovieName => "ARENA_GUN_CAM_SCIFI";
    }
}
