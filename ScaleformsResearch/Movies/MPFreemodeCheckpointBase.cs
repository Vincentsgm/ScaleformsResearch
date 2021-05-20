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
            CheckpointText = MovieName;
        }
    }

    internal class MPFreemodeCheckpoint : MPFreemodeCheckpointBase
    {
        public override string MovieName => "MP_FREEMODE_CHECKPOINT";
    }
    internal class MPFreemodeCheckpoint1 : MPFreemodeCheckpointBase
    {
        public override string MovieName => "MP_FREEMODE_CHECKPOINT_1";
    }
    internal class MPFreemodeCheckpoint2 : MPFreemodeCheckpointBase
    {
        public override string MovieName => "MP_FREEMODE_CHECKPOINT_2";
    }
    internal class MPFreemodeCheckpoint3 : MPFreemodeCheckpointBase
    {
        public override string MovieName => "MP_FREEMODE_CHECKPOINT_3";
    }
    internal class MPFreemodeCheckpoint4 : MPFreemodeCheckpointBase
    {
        public override string MovieName => "MP_FREEMODE_CHECKPOINT_4";
    }
    internal class MPFreemodeCheckpoint5 : MPFreemodeCheckpointBase
    {
        public override string MovieName => "MP_FREEMODE_CHECKPOINT_5";
    }
    internal class MPFreemodeCheckpoint6 : MPFreemodeCheckpointBase
    {
        public override string MovieName => "MP_FREEMODE_CHECKPOINT_6";
    }
    internal class MPFreemodeCheckpoint7 : MPFreemodeCheckpointBase
    {
        public override string MovieName => "MP_FREEMODE_CHECKPOINT_7";
    }
    internal class MPFreemodeCheckpoint8 : MPFreemodeCheckpointBase
    {
        public override string MovieName => "MP_FREEMODE_CHECKPOINT_8";
    }
    internal class MPFreemodeCheckpoint9 : MPFreemodeCheckpointBase
    {
        public override string MovieName => "MP_FREEMODE_CHECKPOINT_9";
    }
    internal class MPFreemodeCheckpoint10 : MPFreemodeCheckpointBase
    {
        public override string MovieName => "MP_FREEMODE_CHECKPOINT_10";
    }

}
