using System;
using System.Windows.Forms;
using Rage;

namespace ScaleformsResearch.Movies
{
    class PopupWarning : Movie
    {
        public override string MovieName => "POPUP_WARNING";

        public void ShowPopupWarning(int msecs, string titleMsg, string warningMsg, string promptMsg, bool showBg, AlertType alertType, string errorMsg)
        {
            CallFunction("SHOW_POPUP_WARNING", msecs, titleMsg, warningMsg, promptMsg, showBg, (int)alertType, errorMsg);
        }

        public void HidePopupWarning(int msecs) => CallFunction("HIDE_POPUP_WARNING", msecs);

        public void SetListRow(int index, string name, int cash, int rp, int lvl, HudColor colour)
        {
            if (index > ListCount) ListCount = index;
            CallFunction("SET_LIST_ROW", index, name, cash, rp, lvl, (int)colour);
        }

        public void SetListItems(int highlightIndex) => CallFunction("SET_LIST_ITEMS", highlightIndex);

        public void RemoveListItems() => CallFunction("REMOVE_LIST_ITEMS");

        private void SetListHighlights(int highlightIndex) => CallFunction("SET_LIST_HIGHLIGHT", highlightIndex);

        public int ListCount { get; private set; }

        private int listHighlights;
        public int ListHighlights
        {
            get => listHighlights;
            set
            {
                listHighlights = value.Clamp(0, ListCount);
                SetListHighlights(listHighlights);
            }
        }

        public enum AlertType
        {
            Complete,
            TitleAndWarning,
            ErrorOnly
        }

        protected override void OnTestStart()
        {
            RemoveListItems();
            ListCount = 0;
            ListHighlights = 0;
            for (int i = 0; i < 5; i++)
            {
                SetListRow(i, $"row {i}", 333 * i, 50 * i, 3 * i, (HudColor)(10 * i).Clamp(0, 255));
            }
        }

        bool showBg = false;
        int alertType = 0;

        protected override void OnTestTick()
        {
            ShowPopupWarning(1000, "Title", "Warning message", "Prompt message", showBg, (AlertType)alertType, "Error message");
            if (Game.IsKeyDown(Keys.Add)) ListHighlights++;
            else if (Game.IsKeyDown(Keys.Subtract)) ListHighlights--;
            else if (Game.IsKeyDown(Keys.NumPad9)) alertType++;
            else if (Game.IsKeyDown(Keys.NumPad6)) alertType--;
            else if (Game.IsKeyDown(Keys.NumPad3)) showBg = !showBg;
            alertType = alertType.Clamp(0, Enum.GetValues(typeof(AlertType)).Length - 1);
        }

        protected override string TestHelpMessage => $"~y~Numpad9/Numpad6 ~s~Change alert type: ~b~{(AlertType)alertType}~n~" +
                $"~y~+/- ~s~Change highlight: ~b~{listHighlights}~n~" +
                $"~y~Numpad3 ~s~Show background: ~b~{showBg}";

        protected override void OnTestEnd()
        {
            HidePopupWarning(1000);
        }
    }
}
