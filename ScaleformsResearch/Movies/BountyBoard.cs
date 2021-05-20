using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Rage.Native.NativeFunction;

namespace ScaleformsResearch.Movies
{
    public class BountyBoard : Movie
    {
        public override string MovieName => "MP_BOUNTY_BOARD";

        public void SetBounty(string bountyName, int bountyValue, string bountyCharacterTexture, string bountyCharacterDictionary)
        {
            Natives.xDFA2EF8E04127DD5(bountyCharacterDictionary, true); //REQUEST_STREAMED_TEXTURE_DICT
            CallFunction("SET_BOUNTY", bountyName, bountyValue, bountyCharacterTexture, bountyCharacterDictionary); ;
        }

        protected override void OnTestStart()
        {
            Refresh();
            SetBounty("Vincentsgm", 333, "hc_michael", "heisthud");
            SetBounty("BadMusician", 666, "hc_n_gus", "heisthud");
            SetBounty("LMS", 999, "hc_n_hug", "heisthud");
            Rage.Game.DisplayNotification($"Bounty board handle: {Handle}");
        }

        protected override void TestDraw()
        {
            Draw2D(0.5f, 0.5f, 1f, 1f);
        }
    }
}
