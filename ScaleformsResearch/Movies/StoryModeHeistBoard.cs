using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class StoryModeHeistBoard : Movie
    {
        public override string MovieName => "HEIST_DOCKS";

        public enum ViewType
        {
            viewCrewMember = 0,
            viewGameplay = 1, 
            viewTodo = 2
        }



        public void CreateView(int viewIndex, ViewType viewType, int xp, int yp) => CallFunction("CREATE_VIEW", viewIndex, (int)viewType, xp, yp);
        public void RepositionView(int viewIndex, int xp, int yp) => CallFunction("REPOSITION_VIEW", viewIndex, xp, yp);
        public void SetLabels(string weaponname, int jobcut, int accuracy) => CallFunction("SET_LABELS", weaponname, jobcut, accuracy);
        public void ShowView(int viewIndex, bool show) => CallFunction("SHOW_VIEW", viewIndex, show);
        public void SetTodo(int viewIndex, int itemIndex, bool check) => CallFunction("SET_TODO", viewIndex, itemIndex, check);
        public void ShowHeistAsset(string enum1, bool visible, int frame, int x, int y) => CallFunction("SHOW_HEIST_ASSET", enum1, visible, frame, x, y);

        protected override void OnTestStart()
        {
            CreateView(0, ViewType.viewCrewMember, 0, 0);
            SetLabels("Carbine Rifle", 50, 10);
            ShowView(0, true);
            SetTodo(0, 0, true);
            ShowHeistAsset("gay", true, 1, 0, 0);
        }
    }
}
