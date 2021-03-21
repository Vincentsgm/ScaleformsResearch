namespace ScaleformsResearch.Movies
{
    public class Stage : Movie
    {
        public override string MovieName => "STAGE";

        private string text = "";

        public string Text { get { return text; } set { text = value; CallFunction("SET_STAGE_TEXT", text); } }
    }
}