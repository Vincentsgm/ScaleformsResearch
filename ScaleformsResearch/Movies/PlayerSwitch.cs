using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    public class PlayerSwitch : Movie
    {
        public override string MovieName => "PLAYER_SWITCH";

        private bool visible = false;
        public bool Visible { get => visible; set { visible = value; CallFunction("SET_SWITCH_VISIBLE", visible); } }

        public string MPHead { set => CallFunction("SET_MULTIPLIER_HEAD", value); }

        public string MPLabel { set => CallFunction("SET_MP_LABEL", value); }

        public int PlayerSelected { get => GetSwitchSelected(); set => SetPlayerSelected(value); }

        public void SetSwitchSlot(int index, stateEnum stateEnum, charEnum charEnum, bool selected, string pedheadshot = null)
        {
            if (pedheadshot is null)
            {
                CallFunction("SET_SWITCH_SLOT", index, (int)stateEnum, (int)charEnum, selected);
            }
            else
            {
                CallFunction("SET_SWITCH_SLOT", index, (int)stateEnum, (int)charEnum, selected, pedheadshot);
            }
        }

        public void SetSwitchHinted(int index, bool hinted) => CallFunction("SET_SWITCH_HINTED", index, hinted);

        public void SetSwitchHintedAll(bool hinted0, bool hinted1, bool hinted2, bool hinted3) => CallFunction("SET_SWITCH_HINTED_ALL", hinted0, hinted1, hinted2, hinted3);

        public void SetSwitchCounterAll(int counter0, int counter1, int counter2, int counter3) => CallFunction("SET_SWITCH_HINTED_ALL", counter0, counter1, counter2, counter3);

        public void SetPlayerSelected(int index) => CallFunction("SET_PLAYER_SELECTED", index);

        public void SetPlayerDamage(int index, bool visible, bool flash) => CallFunction("SET_PLAYER_DAMAGE", index, visible, flash);

        public int GetSwitchSelected() => CallFunctionInt("GET_SWITCH_SELECTED");

        public enum stateEnum
        {
            Unknown = 0,
            Available = 1,
            Unavailable = 2,
            NotMet = 3
        }

        public enum charEnum
        {
            Unk1 = 0,
            Unk2 = 1,
            Unk3 = 2,
            Unk4 = 3
        }
    }
}
