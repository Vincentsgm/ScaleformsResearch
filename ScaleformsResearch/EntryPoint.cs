using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rage;
using static Rage.Native.NativeFunction;

[assembly: Rage.Attributes.Plugin("ScaleformsResearch", Author = "BadMusician & Vincentsgm", EntryPoint = "ScaleformsResearch.EntryPoint.OnLoad", ExitPoint = "ScaleformsResearch.EntryPoint.OnUnload", PrefersSingleInstance = true)]

namespace ScaleformsResearch
{
    internal static class EntryPoint
    {
        public static void OnLoad()
        {
            while (true)
            {
                GameFiber.Yield();
            }
        }
        public static void OnUnload(bool isTerminating)
        {
            Test.Stop();
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



                bool aborted = false;

                while (!aborted)
                {
                    GameFiber.Yield();
                    if (Game.IsKeyDown(Keys.Back)) aborted = true;

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

        [Rage.Attributes.ConsoleCommand("Runs the bounty board scaleform example", Name = "Scaleform_BOUNTY_BOARD")]
        public static void RunBountyBoardExample()
        {
            GameFiber.StartNew(delegate
            {
                Movies.BountyBoard bountyBoard = new Movies.BountyBoard();
                bountyBoard.Refresh();
                Game.DisplayNotification(bountyBoard.Handle.ToString());

                bountyBoard.SetBounty("Vincentsgm", 666, "heisthud", "hc_michael");
                bountyBoard.SetBounty("BadMusician", 999, "heisthud", "hc_n_gus");
                bountyBoard.SetBounty("LMS", 999, "heisthud", "hc_n_hug");

                bool aborted = false;

                while (!aborted)
                {
                    GameFiber.Yield();
                    if (Game.IsKeyDown(Keys.Back)) aborted = true;
                    //Doesn't work
                    bountyBoard.Draw();
                }

                bountyBoard.Release();
            });
        }

        [Rage.Attributes.ConsoleCommand("Runs the player switch scaleform example", Name = "Scaleform_PLAYER_SWITCH")]
        public static void RunPlayerSwitchExample()
        {
            GameFiber.StartNew(delegate
            {
                Movies.PlayerSwitch playerSwitch = new Movies.PlayerSwitch();
                playerSwitch.Refresh();

                playerSwitch.SetSwitchSlot(0, Movies.PlayerSwitch.stateEnum.Available, Movies.PlayerSwitch.charEnum.Unk1, true, "char_abigail");
                playerSwitch.SetSwitchSlot(1, Movies.PlayerSwitch.stateEnum.Available, Movies.PlayerSwitch.charEnum.Unk2, false, "char_amanda");
                playerSwitch.SetSwitchSlot(2, Movies.PlayerSwitch.stateEnum.Available, Movies.PlayerSwitch.charEnum.Unk3, false, "char_andreas");
                playerSwitch.SetSwitchSlot(3, Movies.PlayerSwitch.stateEnum.Available, Movies.PlayerSwitch.charEnum.Unk4, false, "char_barry");

                playerSwitch.SetPlayerDamage(0, true, true);

                playerSwitch.MPLabel = "FR_HELP";

                playerSwitch.Visible = true;

                playerSwitch.MPHead = "char_barry";

                bool aborted = false;

                Game.FrameRender += (s, e) => playerSwitch.Draw2D(0.88f, 0.88f, 0.2f, 0.2f);

                while (!aborted)
                {
                    GameFiber.Yield();

                    Game.DisplaySubtitle($"Selected character: {playerSwitch.GetSwitchSelected()}");
                    if (Game.IsKeyDown(Keys.Back)) aborted = true;
                    else if (Game.IsKeyDownRightNow(Keys.NumPad8)) playerSwitch.PlayerSelected = 2;
                    else if (Game.IsKeyDownRightNow(Keys.NumPad4)) playerSwitch.PlayerSelected = 0;
                    else if (Game.IsKeyDownRightNow(Keys.NumPad6)) playerSwitch.PlayerSelected = 1;
                    else if (Game.IsKeyDownRightNow(Keys.NumPad2)) playerSwitch.PlayerSelected = 3;
                    else if (Game.IsKeyDown(Keys.NumPad8)) playerSwitch.PlayerSelected = 2;
                    else if (Game.IsKeyDown(Keys.NumPad4)) playerSwitch.PlayerSelected = 0;
                    else if (Game.IsKeyDown(Keys.NumPad6)) playerSwitch.PlayerSelected = 1;
                    else if (Game.IsKeyDown(Keys.NumPad2)) playerSwitch.PlayerSelected = 3;

                }
                Game.FrameRender -= (s, e) => playerSwitch.Draw2D(0.88f, 0.88f, 0.2f, 0.2f);
                playerSwitch.Release();
            });
        }
    }
}
