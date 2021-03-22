using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    class Drilling : Movie
    {
        public override string MovieName => "DRILLING";

        private float speed = 0, depth = 0, temp = 0;

        public float Speed { get => speed; set { speed = value.Clamp(0, 1); CallFunction("SET_SPEED", speed); } }
        public float Depth { get => depth; set { depth = value.Clamp(0, 1); CallFunction("SET_DEPTH", depth); } }
        public float Temperature { get => temp; set { temp = value.Clamp(0, 1); CallFunction("SET_TEMPERATURE", temp); } }
    }
}
