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
        public static void Main()
        {
            while (true)
            {
                GameFiber.Yield();
            }
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
    }
}
