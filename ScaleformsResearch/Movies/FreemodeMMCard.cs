using Rage;
using Rage.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Rage.Native.NativeFunction;

namespace ScaleformsResearch.Movies
{
    internal class FreemodeMMCard : Movie
    {
        public override string MovieName => "MP_MM_CARD_FREEMODE";

        protected override void OnTestStart()
        {
            Refresh();
            for (int i = 0; i < 8; i++)
            {
                CallFunction("SET_DATA_SLOT_EMPTY", 0, i);
                SetSlot(i, $"AI Name {i}", HudColor.Red, RightIconType.DEAD, "Test", "SWAT", false, "web_lossantospolicedept", "web_lossantospolicedept", i.ToString());
            }
            SetTitle("Los Santos S.W.A.T. Team", "Patrolling", BannerIconType.Person);
            CallFunction("DISPLAY_VIEW");
            //UpdateSlot(3, $"Updated Name", HudColor.Red, RightIconType.ACTIVE_HEADSET, "Test", "SWAT", false, "web_lossantospolicedept", "web_lossantospolicedept", 8.ToString());
        }

        public void SetTitle(string title, string subtitle, BannerIconType iconType)
        {
            CallFunction("SET_TITLE", title, subtitle, (int)iconType);
        }

        public void SetSlot(int i, string name, HudColor color, RightIconType iconType, string rightText, string crewTag, bool jobPointsVisible, string pictureTxd, string pictureTxn, string pictureNote)
        {
            CallFunction("SET_DATA_SLOT", i, "", name, (int)color, (int)iconType, "", rightText, $"123{crewTag}", jobPointsVisible, pictureTxd, pictureTxn, pictureNote);
        }

        public void UpdateSlot(int i, string name, HudColor color, RightIconType iconType, string rightText, string crewTag, bool jobPointsVisible, string pictureTxd, string pictureTxn, string pictureNote)
        {
            CallFunction("UPDATE_SLOT", i, "", name, (int)color, (int)iconType, "", rightText, $"123{crewTag}", jobPointsVisible, pictureTxd, pictureTxn, pictureNote);
        }

        protected override void TestDraw()
        {
            Natives.SET_SCRIPT_GFX_DRAW_ORDER(7);
            Draw2D(0.120f, 0.3f, 0.28f, 0.6f);
            Natives.SET_SCRIPT_GFX_DRAW_ORDER(4);
        }
    }

    public enum RightIconType
    {
        NONE = 0,
        INACTIVE_HEADSET = 48,
        MUTED_HEADSET = 49,
        ACTIVE_HEADSET = 47,
        RANK_FREEMODE = 65,
        KICK = 64,
        LOBBY_DRIVER = 79,
        LOBBY_CODRIVER = 80,
        SPECTATOR = 66,
        BOUNTY = 115,
        DEAD = 116,
        DPAD_GANG_CEO = 121,
        DPAD_GANG_BIKER = 122,
        DPAD_DOWN_TARGET = 123
    };

    public enum DisplayType
    {
        NUMBER_ONLY = 0,
        ICON = 1,
        NONE = 2
    };

    public enum BannerIconType
    {
        None = 0,
        Star = 2,
        Skull = 3,
        Race = 4,
        Survival = 5,
        TripleSkull = 6,
        Castle = 8,
        Parachute = 10,
        Car = 11,
        CarRace = 12,
        PersonRace = 13,
        BicycleRace = 14,
        BoatRace = 15,
        PlaneRace = 16,
        Person = 17,
        Briefcase = 18,
        HeistPrep = 19,
        Securoserv = 20,
        Bicycle = 21,
        Crown = 22,
        RaceStar = 31,
        RaceLS = 32,
        TimeTrial = 34,
        Mask = 35,
        TrialRace = 36
    }
}
