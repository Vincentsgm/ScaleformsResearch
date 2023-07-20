using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class TextField : Movie
    {
        public override string MovieName => "TEXTFIELD";
        public string Text { set => CallFunction("SET_TEXT", value); } 
        public float TextPointSize { set => CallFunction("SET_TEXT_POINT_SIZE", value); }
        public void SetBackgroundImage(string txd, string txn, float alpha) => CallFunction("SET_BACKGROUND_IMAGE", txd, txn, alpha);
        public void ClearBackgroundImage() => CallFunction("CLEAR_BACKGROUND_IMAGE");

        protected override void OnTestStart()
        {
            base.OnTestStart();
            Text = "Test text";
            //SetBackgroundImage("www_stoppayingyourmortgage_net", "image_background_header", 255f);
            ClearBackgroundImage();
            TextPointSize = 10f;
        }
    }
}
