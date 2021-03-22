using Rage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScaleformsResearch.Movies
{
    class ClubhouseName : Movie
    {
        public override string MovieName => "CLUBHOUSE_NAME";

        string text = "";
        ClubhouseFont font = ClubhouseFont.Font2;
        ClubhouseColor color = ClubhouseColor.x000000;

        public string Text { get => text; set { text = value; Update(); } }
        public ClubhouseFont Font { get => font; set { font = value; Update(); } }
        public ClubhouseColor TextColor { get => color; set { color = value; Update(); } }

        void Update() => CallFunction("SET_CLUBHOUSE_NAME", text, (int)color, (int)font);

        protected override void OnTestTick()
        {
            base.OnTestTick();
            if (Game.IsKeyDown(Keys.NumPad1))
            {
                Text = Util.Phrases.Random();
            }
            else
            if (Game.IsKeyDown(Keys.NumPad2))
            {
                Font = Util.EnumValues<ClubhouseFont>().Random();
            }
            else
            if (Game.IsKeyDown(Keys.NumPad3))
            {
                TextColor = Util.EnumValues<ClubhouseColor>().Random();
            }
        }
        protected override string TestHelpMessage => $"~y~NumPad1~s~ - Randomize Text~n~~y~NumPad2~s~ - Randomize Font ({Font})~n~~y~NumPad3~s~ - Randomize Text Color ({TextColor})";

        public enum ClubhouseColor
        {
            x000000,
            x9B9B9B,
            xF0F0F0,
            xEA991C,
            xE03232,
            x359A47,
            xF0C850,
            x2D6EB9,
        }
        public enum ClubhouseFont
        {
            Font2 = -1,
            Machine,
            Stencil,
            Lubalin,
            Bookman,
            Stenberg,
            Mistral,
            HelveticaBLK,
            HelveticaBLKI,
            Times,
            TradeGothic,
            AnnaSC,
            EngraversOldEnglish,
            Bauhaus
        }
    }
}
