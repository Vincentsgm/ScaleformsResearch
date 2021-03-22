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
            CallFunction(bountyName, bountyValue, bountyCharacterTexture, bountyCharacterDictionary);
        }
    }
}
