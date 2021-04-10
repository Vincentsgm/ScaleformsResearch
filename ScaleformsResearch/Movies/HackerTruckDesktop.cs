using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rage;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    internal class HackerTruckDesktop : BusinessScreen
    {
        public override string MovieName => "HACKER_TRUCK_DESKTOP";

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

        public const int MaxJobs = 9;

        public void UpdateMission(uint index, bool isAvailable, int cooldown)
        {
            if (index > MaxJobs) throw new InvalidOperationException($"The index must be smaller than MaxJobs ({MaxJobs})");
            CallFunction("UPDATE_MISSION", index, isAvailable, cooldown);
        }

        public void UpdateCooldown(uint index, int cooldown) => CallFunction("UPDATE_COOLDOWN", index, cooldown);

        public enum JobValueType
        {
            VALUE_TYPE_HIDDEN = 0,
            VALUE_TYPE_CASH = 1,
            VALUE_TYPE_SECONDS = 2
        }

        public void AddJob(int index, string title, int value, JobValueType valueType, string tooltip, bool isAvailable, int salePrice) => CallFunction("ADD_JOB", index, title, value, (int)valueType, tooltip, isAvailable, salePrice);
        public void ShowJobOverlay(int missionIndex, string title) => CallFunction("SHOW_JOB_OVERLAY", missionIndex, title);


        public void ClearJobs() => CallFunction("CLEAR_JOBS");

        protected override void OnTestStart()
        {
            ShowScreen(1);
            ClearJobs();
            for (int i = 1; i < MaxJobs; i++)
            {
                AddJob(i, $"Job {i}", 20 * i, JobValueType.VALUE_TYPE_CASH, $"Tooltip {i}", true, 10000 * i);
                //ShowJobOverlay(i, $"Job overlay {i}");
                UpdateMission((uint)i, true, 1);
                UpdateCooldown((uint)i, 1);
            }
            ShowJobOverlay(1, "Job overlay 1");
            Game.FrameRender += (s, e) => Draw();
        }

        protected override void TestDraw()
        {
        }


        protected override void OnTestTick()
        {
            DisableHUD();
            //Game.DisplayNotification($"Selection {GetCurrentSelection}; Rollover {GetCurrentRollover}");
            var mouseInput = Controls.MousePosition;
            SetMouseInput(mouseInput.X, mouseInput.Y);
            foreach (GameControl control in Inputs)
            {
                if (Game.IsControlJustPressed(0, control))
                {
                    SetInputEvent(control);
                    Game.DisplayNotification($"Selection {GetCurrentSelection}; Rollover {GetCurrentRollover}");
                    if (control == GameControl.FrontendAccept)
                    {
                        ShowJobOverlay(GetCurrentSelection, $"Job overlay");
                    }
                }
            }
        }

        protected override void OnTestEnd()
        {
            Game.FrameRender -= (s, e) => Draw();
        }
    }
}
