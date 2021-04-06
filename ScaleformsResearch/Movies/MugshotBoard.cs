using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class MugshotBoard01 : Movie
    {
        public override string MovieName => "MUGSHOT_BOARD_01";

        public void SetBoard(string headerStr, string numStr, string footerStr, string importedStr, int importCol, int rankNum, int rankCol) => CallFunction("SET_BOARD", headerStr, numStr, footerStr, importedStr, importCol, rankNum, rankCol);

        protected override void OnTestStart()
        {
            SetBoard("Header", "NumStr", "Footer", "ImportedStr", 0, 69, 0);
        }
    }

    internal class MugshotBoard02 : MugshotBoard01
    {
        public override string MovieName => "MUGSHOT_BOARD_02";
    }
}
