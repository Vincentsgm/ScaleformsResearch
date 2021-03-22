using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using static Rage.Native.NativeFunction;

namespace ScaleformsResearch.Movies
{
    public class OpenWheelHealthIndicator : Movie
    {
        public override string MovieName => "OPEN_WHEEL_HEALTH_INDICATOR";

        public enum Wheel
        {
            LeftFront = 3,
            RightFront = 4,
            LeftRear = 5,
            RightRear = 6
        }

        public void SetWheelDamage(Wheel wheel, float damage)
        {
            CallFunction("SET_WHEEL_DAMAGE", (int)wheel, damage);
        }

        public void SetTyreWearMultiplier(Vehicle vehicle, Wheel wheel, float multipler)
        {
            Natives.x01894E2EDE923CA2(vehicle, (int)wheel, multipler);
        }

        public float GetTyreWearMultiplier(Vehicle vehicle, Wheel wheel)
        {
            return Natives.x6E387895952F4F71<float>(vehicle, (int)wheel);
        }

        public void SetVehicleWheelDamage(Vehicle vehicle, Wheel wheel, float health)
        {
            Natives.xx74C68EF97645E79D(vehicle, (int)wheel, health);
        }

        public float GetVehicleWheelDamage(Vehicle vehicle, Wheel wheel)
        {
            return Natives.x55EAB010FAEE9380<float>(vehicle, (int)wheel);
        }

        IEnumerable<Wheel> t_wheels = (IEnumerable<Wheel>)Enum.GetValues(typeof(Wheel));

        protected override void OnTestStart()
        {
            if (Game.LocalPlayer.Character.IsInAnyVehicle(false))
            {
                //Doesn't work, tires don't seem to take damage
                foreach (var wheel in t_wheels)
                {
                    // Natives.x2970EAA18FD5E42F(MainPlayer.CurrentVehicle, true);
                    // healthIndicator.SetTyreWearMultiplier(MainPlayer.CurrentVehicle, wheel, 1000f);
                    //  healthIndicator.SetWheelDamage(wheel, healthIndicator.GetVehicleWheelDamage(MainPlayer.CurrentVehicle, wheel));
                }//
                //healthIndicator.Draw2D(0.12f, 0.12f, 0.2f, 0.2f);
            }
        }
    }
}
