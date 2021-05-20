using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class MPUnlocksFreemode : MPAwardBase
    {
        public override string MovieName => "MP_UNLOCK_FREEMODE";

        public void Reset() => CallFunction("RESET_AWARDS_MOVIE");
        public void ShowCollectionProgress(string title, bool completed, int totalToDo, string message, string info) =>CallFunction("SHOW_COLLECTION_PROGRESS", title, completed, totalToDo, message, info);
        public void ShowBridgeKnivesProgress(string title, int totalToDo, string message, string info, bool completed) => CallFunction("SHOW_BRIDGES_KNIVES_PROGRESS", title, totalToDo, message, info, completed);

        protected override void OnTestStart()
        {
            //ShowUnlockAndMessage("Award title", "Award description", "", "", "Description 2", colEnum.col1, "Description 3");
            //ShowCollectionProgress("Title", true, 69, "Message", "Info");
            ShowBridgeKnivesProgress("Title", 69, "Message", "Info", true);
        }
    }
}
