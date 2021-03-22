using System;
using Rage;
using static Rage.Native.NativeFunction;


#pragma warning disable CS0659, CS0661

namespace ScaleformsResearch
{
    public enum AnimPostFXEffect
    {
        CamPushInNeutral,
        FocusIn,
        FocusOut,
        BulletTime,
        BulletTimeOut,
        DrivingFocus,
        DrivingFocusOut,
        REDMIST,
        REDMISTOut,
        SwitchShortMichaelIn,
        SwitchShortFranklinMid,
        CamPushInFranklin,
        CamPushInMichael,
        CamPushInTrevor,
        SwitchHUDOut,
        MP_job_load,
        MenuMGTrevorIn,
        MenuMGMichaelIn,
        MenuMGFranklinIn,
        MenuMGTrevorOut,
        MenuMGMichaelOut,
        MenuMGFranklinOut,
        MenuMGIn,
        MenuMGSelectionIn,
        MenuMGSelectionTint,
        MenuMGTournamentIn,
        MenuMGHeistIn,
        MenuMGHeistTint,
        MenuMGHeistIntro,
        MenuMGTournamentTint,
        MenuMGRemixIn,
        MenuSurvivalAlienIn,
        MP_race_crash,
        DeathFailMPDark,
        DeathFailMPIn,
        CrossLine,
        SuccessFranklin,
        SuccessTrevor,
        SuccessMichael,
        MinigameTransitionIn,
        MP_Celeb_Preload_Fade,
        MP_Celeb_Win,
        MP_Celeb_Lose,
        MinigameTransitionOut,
        MinigameEndNeutral,
        RaceTurbo,
        MP_corona_switch_supermod,
        WeaponUpgrade,
        MinigameEndMichael,
        MinigameEndFranklin,
        MinigameEndTrevor,
        Rampage,
        RampageOut,
        MP_TransformRaceFlash,
        DeathFailOut,
        HeistCelebPass,
        HeistCelebPassBW,
        HeistCelebFail,
        HeistCelebFailBW,
        SuccessNeutral,
        HeistCelebEnd,
        SwitchSceneMichael,
        SwitchSceneFranklin,
        SwitchSceneTrevor,
        SwitchOpenNeutralOutHeist,
        ArenaWheelPurple,
        CarDamageHit,
        MenuMGHeistOut,
        CrossLineOut,
        MP_SmugglerCheckpoint,
        MP_Celeb_Win_Out,
        MP_Celeb_Lose_Out,
        MP_WarpCheckpoint,
        MP_intro_logo,
        InchPickup,
        PPOrange,
        PPPurple,
        PPGreen,
        PPPink,
        DeadlineNeon,
        MP_Celeb_Preload,
        HeistTripSkipFade,
        InchPickupOut,
        PPOrangeOut,
        PPPurpleOut,
        PPGreenOut,
        PPPinkOut,
        HeistLocate,
        BeastIntroScene,
        BeastTransition,
        BeastLaunch,
        MP_OrbitalCannon,
        RemixDrone,
        pennedIn,
        PennedInOut,
        PeyoteEndIn,
        PeyoteEndOut,
        PeyoteIn,
        PeyoteOut,
        DefaultBlinkOutro,
        SwitchShortFranklinIn,
        SwitchShortMichaelMid,
        SwitchShortTrevorIn,
        SwitchShortTrevorMid,
        ChopVision,
        DMT_flight,
        DrugsDrivingOut,
        DMT_flight_intro,
        DrugsDrivingIn,
        SwitchOpenNeutralFIB5,
        SwitchOpenMichaelMid,
        SwitchOpenMichaelIn,
        MP_corona_switch,
        InchPurple,
        DeathFailNeutralIn,
        SwitchShortNeutralIn,
        CarPitstopHealth,
        InchOrange,
        LostTimeDay,
        LostTimeNight,
        MP_Bull_tost,
        PPFilter,
        PPFilterOut,
        TinyRacerPink,
        TinyRacerGreen,
        TinyRacerGreenOut,
        TinyRacerPinkOut,
        InchOrangeOut,
        InchPurpleOut,
        TinyRacerIntroCam,
        SurvivalAlien,
        BikerFormation,
        BikerFormationOut,
        ArenaEMP,
        ArenaEMPOut,
        SwitchOpenFranklin,
        ExplosionJosh3,
        SwitchSceneNeutral,
        SniperOverlay,
        SwitchSceneNetural,
        Dont_tazeme_bro,
        SwitchHUDMichaelIn,
        SwitchHUDFranklinIn,
        SwitchHUDTrevorIn,
        SwitchHUDIn,
        SwitchHUDMichaelOut,
        SwitchHUDFranklinOut,
        SwitchHUDTrevorOut,
        PokerCamTransition
    }

    public class AnimPostFX : IDeletable, IDisposable, IEquatable<AnimPostFX>
    {
        public AnimPostFXEffect FXEffect;
        internal int Duration;
        internal bool Looped;

        public AnimPostFX(AnimPostFXEffect fXEffect, int duration, bool looped)
        {
            FXEffect = fXEffect;
            Duration = duration;
            Looped = looped;
            Play();
        }

        public void Play()
        {
            Natives.x2206BF9A37B7F724(FXEffect.ToString(), Duration, Looped); //ANIMPOSTFX_PLAY
        }

        public bool IsRunning => Natives.x36AD3E690DA5ACEB<bool>(FXEffect.ToString()); //ANIMPOSTFX_IS_RUNNING

        public void Delete()
        {
            Dispose();
        }

        public void Dispose()
        {
            Natives.x068E835A1D0DC0E3(FXEffect.ToString()); //ANIMPOSTFX_STOP
        }

        public override bool Equals(object obj)
        {
            if (obj is AnimPostFX)
            {
                var right = obj as AnimPostFX;
                return right.FXEffect == FXEffect;
            }
            return obj.ToString() == FXEffect.ToString();
        }

        public bool Equals(AnimPostFX other)
        {
            return FXEffect == other.FXEffect;
        }

        public static bool operator ==(AnimPostFX left, AnimPostFX right)
        {
            return left?.Equals(right) ?? false;
        }

        public static bool operator !=(AnimPostFX left, AnimPostFX right)
        {
            return !(left == right);
        }

        ~AnimPostFX() => Delete();
    }
}
