using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class MPMenuGlare : Movie
    {
        public override string MovieName => "MP_MENU_GLARE";

        public void SetDisplayConfig(int _screenWidthPixels = 1280, int _screenHeightPixels = 720, int _safeTopPercent = 0, int _safeBottomPercent = 0, int _safeLeftPercent = 0, int _safeRightPercent = 0, bool _isWideScreen = true, bool _isHiDef = true, bool _isAsian = false) => CallFunction("SET_DISPLAY_CONFIG", _screenWidthPixels, _screenHeightPixels, _safeTopPercent, _safeBottomPercent, _safeLeftPercent, _safeRightPercent, _isWideScreen, _isHiDef, _isAsian);

        protected override void TestDraw()
        {
            SetDisplayConfig(1280, 720);
            Draw2D(0.5f, 0.5f, 1f, 1f);
        }
    }
}
