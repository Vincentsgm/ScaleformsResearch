using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class MPResultsPanel : Movie
    {
        public override string MovieName => "MP_RESULTS_PANEL";

        public string Title { set => CallFunction("SET_TITLE", value); }
        public string Subtitle { set => CallFunction("SET_SUBTITLE", value); }
        public void ClearSlot(int id) => CallFunction("CLEAR_SLOT", id);
        public void ClearAllSlots() => CallFunction("CLEAR_ALL_SLOTS");
        public void SetSlot(int id, bool state, string label) => CallFunction("SET_SLOT", id, state, label);
        public void SetSlotState(int id, bool state) => CallFunction("SET_SLOT_STATE", id, state);

        protected override void OnTestStart()
        {
            Title = "MP Results Panel";
            Subtitle = "Subtitle";
            for (int i = 0; i < 6; i++)
            {
                SetSlot(i, i % 2 == 0, $"Slot {i}");
            }
        }
    }
}
