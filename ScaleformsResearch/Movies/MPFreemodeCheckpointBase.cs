using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class MPFreemodeCheckpointBase : Movie
    {
        public override string MovieName => "MP_FREEMODE_CHECKPOINT_BASE";

        public string CheckpointText { set => CallFunction("SET_CHECKPOINT_TEXT", value); }

        protected override void OnTestStart()
        {
            CheckpointText = "Checkpoint Text";
        }
    }
}
