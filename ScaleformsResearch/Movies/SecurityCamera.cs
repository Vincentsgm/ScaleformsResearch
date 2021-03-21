namespace ScaleformsResearch.Movies
{
    public class SecurityCamera : Movie
    {
        public override string MovieName => "SECURITY_CAMERA";

        public void ShowCameraOverlay() => CallFunction("SHOW_CAMERA_OVERLAY");

        public void ShowStatic() => CallFunction("SHOW_STATIC");
    }
}