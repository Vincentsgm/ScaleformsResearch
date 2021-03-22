using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rage;
using static Rage.Native.NativeFunction;

[assembly: Rage.Attributes.Plugin("ScaleformsResearch", Author = "BadMusician & Vincentsgm", EntryPoint = "ScaleformsResearch.EntryPoint.Main", PrefersSingleInstance = true)]

namespace ScaleformsResearch
{
    internal static class EntryPoint
    {
        public static Ped MainPlayer => Game.LocalPlayer.Character;

        public static void Main()
        {
            while (true)
            {
                GameFiber.Yield();
            }
        }

        [Rage.Attributes.ConsoleCommand("Runs the security cam scaleform example", Name = "Scaleform_SECURITY_CAM")]
        public static void RunSecurityCamExample()
        {
            GameFiber.StartNew(delegate
            {

                string[] locations = new string[] { "loc 1", "loc 2", "loc 3" };
                string[] details = new string[] { "detail 1", "detail 2", "detail 3" };
                int currentLocation = 0;
                int currentDetail = 0;

                Movies.SecurityCam securityCam = new Movies.SecurityCam();

                securityCam.LoadAndWait();

                securityCam.Layout = Movies.SecurityCam.SecurityCamLayout.CameraLike;
                securityCam.Details = details[0];

                bool aborted = false;

                while (!aborted)
                {
                    GameFiber.Yield();
                    if (Game.IsKeyDown(Keys.Add))
                    {
                        currentLocation = MathHelper.Clamp(currentLocation + 1, 0, locations.Count() - 1);
                        securityCam.Location = locations[currentLocation];
                    }
                    else if (Game.IsKeyDown(Keys.Subtract))
                    {
                        currentLocation = MathHelper.Clamp(currentLocation - 1, 0, locations.Count() - 1);
                        securityCam.Location = locations[currentLocation];
                    }
                    else if (Game.IsKeyDown(Keys.Back)) aborted = true;

                    securityCam.Time = World.DateTime;

                    securityCam.Draw();
                }

                securityCam.Release();
            });
        }

        [Rage.Attributes.ConsoleCommand("Runs the rank bar scaleform example", Name = "Scaleform_MP_RANK_BAR")]
        public static void RunRankBarExample()
        {
            GameFiber.StartNew(delegate
            {
                Movies.RankBar rankBar = new Movies.RankBar();
                rankBar.LoadHudMovie();
                rankBar.StayOnScreen();

                bool aborted = false;

                while (!aborted)
                {
                    GameFiber.Yield();
                    if (Game.IsKeyDown(Keys.Add)) rankBar.CurrentXP++;
                    else if (Game.IsKeyDown(Keys.Subtract)) rankBar.CurrentXP--;
                    else if (Game.IsKeyDown(Keys.Back)) aborted = true;
                    rankBar.Draw();
                }

                rankBar.Release();
            });
        }

        [Rage.Attributes.ConsoleCommand("Runs the rank bar scaleform example", Name = "Scaleform_OPEN_WHEEL_HEALTH_INDICATOR")]
        public static void RunOpenWheelHealthIndicatorExample()
        {
            GameFiber.StartNew(delegate
            {
                Movies.OpenWheelHealthIndicator healthIndicator = new Movies.OpenWheelHealthIndicator();
                healthIndicator.LoadAndWait();

                var wheels = (IEnumerable<Movies.OpenWheelHealthIndicator.Wheel>)Enum.GetValues(typeof(Movies.OpenWheelHealthIndicator.Wheel));

                bool aborted = false;

                while (!aborted)
                {
                    GameFiber.Yield();
                    if (Game.IsKeyDown(Keys.Back)) aborted = true;
                    if (Game.LocalPlayer.Character.IsInAnyVehicle(false))
                    {
                        //Doesn't work, tires don't seem to take damage
                        foreach (var wheel in wheels)
                        {
                            Natives.x2970EAA18FD5E42F(MainPlayer.CurrentVehicle, true);
                            healthIndicator.SetTyreWearMultiplier(MainPlayer.CurrentVehicle, wheel, 1000f);
                            healthIndicator.SetWheelDamage(wheel, healthIndicator.GetVehicleWheelDamage(MainPlayer.CurrentVehicle, wheel));
                        }
                        healthIndicator.Draw2D(0.12f, 0.12f, 0.2f, 0.2f);
                    }
                }

                healthIndicator.Release();
            });
        }

        [Rage.Attributes.ConsoleCommand("Runs the morgue laptop scaleform example", Name = "Scaleform_MORGUE_LAPTOP")]
        public static void RunMorgueLaptopExample()
        {
            GameFiber.StartNew(delegate
            {
                Movies.MorgueLaptop morgueLaptop = new Movies.MorgueLaptop();
                morgueLaptop.LoadAndWait();

                morgueLaptop.Percent = 0;

                uint lastUpdate = Game.GameTime;

                var sound = new Sound();
                sound.PlayFrontend("laptop_download_loop", "dlc_xm_heists_iaa_morgue_sounds");

                while (morgueLaptop.Percent < 100)
                {
                    GameFiber.Yield();

                    if (Game.GameTime > lastUpdate + 100)
                    {
                        morgueLaptop.Percent += 1;
                        lastUpdate = Game.GameTime;

                        if (sound.HasFinished) sound.PlayFrontend("laptop_download_loop", "dlc_xm_heists_iaa_morgue_sounds");
                    }

                    morgueLaptop.Draw();
                }

                sound.Stop();
                sound.ReleaseId();

                new Sound(-1).PlayFrontend("HACKING_SUCCESS", null);

                lastUpdate = Game.GameTime;

                while (Game.GameTime < lastUpdate + 2000)
                {
                    GameFiber.Yield();
                    morgueLaptop.Draw();
                }

                morgueLaptop.Release();
            });
        }
    }
}
