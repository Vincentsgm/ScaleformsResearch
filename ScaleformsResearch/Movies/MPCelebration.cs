using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleformsResearch.Movies
{
    internal class MPCelebrationBG : MPCelebration
    {
        public override string MovieName => "MP_CELEBRATION_BG";
    }

    internal class MPCelebrationFG : MPCelebration
    {
        public override string MovieName => "MP_CELEBRATION_FG";
    }

    internal class MPCelebration : Movie
    {
        public override string MovieName => "MP_CELEBRATION";

        public enum TextureID : int
        {
            SHARD_TEXTURE = 1,
            SHARD_RACE_FLAG = 3,
            VERTICAL_RACE_FLAG = 4,
            TRANSFORM_RACE_FLAG = 5,
            SHARD_GRID = 6,
            VERTICAL_GRID = 7,
            SHARD_TARGET_ASSAULT = 8,
            VERTICAL_TARGET_ASSAULT = 9,
            SHARD_REMIX_1 = 10,
            VERTICAL_REMIX_1 = 11,
            SHARD_REMIX_2 = 12,
            VERTICAL_REMIX_2 = 13,
            SHARD_REMIX_3 = 14,
            VERTICAL_REMIX_3 = 15,
            SHARD_REMIX_4 = 16,
            VERTICAL_REMIX_4 = 17,
            SHARD_REMIX_5 = 18,
            VERTICAL_REMIX_5 = 19,
            SHARD_ARENA_WARS = 20,
            VERTICAL_BANNER_ARENA_WARS = 21
        }

        public void CleanUp(string wallID) => CallFunction("CLEANUP", wallID);
        public void CreateStateWall(string wallID, string hudColor, int alpha) => CallFunction("CREATE_STAT_WALL", wallID, hudColor, alpha);
        public void AddIntroToWall(string wallID, string modeLabel, string jobName, string challengeTextLabel, string challengePartsText, string targetTypeTextLabel, int targetValue, int delay, char targetValuePrefix, bool modeLabelIsStringLiteral, string textColourName)
            => CallFunction("ADD_INTRO_TO_WALL", wallID, modeLabel, jobName, challengeTextLabel, challengePartsText, targetTypeTextLabel, targetValue, delay, targetValuePrefix, modeLabelIsStringLiteral, textColourName);
        public void AddBackgroundToWall(string wallID, int alpha, TextureID textureID) => CallFunction("ADD_BACKGROUND_TO_WALL", wallID, alpha, (int)textureID);
        public void ShowStatWall(string wallID) => CallFunction("SHOW_STAT_WALL", wallID);
        public void AddPositionToWall(string wallID, int position, string positionLabel, bool isPositionLabelRawText, bool isScore) => CallFunction("ADD_POSITION_TO_WALL", wallID, position, positionLabel, isPositionLabelRawText, isScore);
        public void AddScoreToWall(string wallID, string textLabel, int score) => CallFunction("ADD_SCORE_TO_WALL", wallID, textLabel, score);
        public void AddJobPointsToWall(string wallID, int points, int xAlign) => CallFunction("ADD_JOB_POINTS_TO_WALL", wallID, points, xAlign);
        public void AddArenaPointsToWall(string wallID, int points, int xAlign) => CallFunction("ADD_ARENA_POINTS_TO_WALL", wallID, points, xAlign);
        public void AddPointsToWall(string wallID, int points, int type, string prefix, int xAlign, int marginTop, bool noAnims) => CallFunction("ADD_POINTS_TO_WALL", wallID, points, type, prefix, xAlign, marginTop, noAnims);
        public void AddRepPointsAndRankBarToWall(string wallID, int repPointsGained, int startRepPoints, int minRepPointsForRank, int maxRepPointsForRank, int currentRank, int nextRank, string rank1Txt, string rank2Txt) => CallFunction("ADD_REP_POINTS_AND_RANK_BAR_TO_WALL", wallID, repPointsGained, startRepPoints, minRepPointsForRank, maxRepPointsForRank, currentRank, nextRank, rank1Txt, rank2Txt);
        public void AddArenaPointsAndRankBarToWall(string wallID, int repPointsGained, int startRepPoints, int minRepPointsForRank, int maxRepPointsForRank, int currentRank, int nextRank, string rank1Txt, string rank2Txt) => CallFunction("ADD_ARENA_POINTS_AND_RANK_BAR_TO_WALL", wallID, repPointsGained, startRepPoints, minRepPointsForRank, maxRepPointsForRank, currentRank, nextRank, rank1Txt, rank2Txt);
        public void AddWinnerToWall(string wallID, string winLoseTextLabel, string gamerName, string crewName, int betAmount, bool isInFlow, string teamName, bool gamerNameIsLabel) => CallFunction("ADD_WINNER_TO_WALL", wallID, winLoseTextLabel, gamerName, crewName, betAmount, isInFlow, teamName, gamerNameIsLabel);
        public void AddObjectiveToWall(string wallID, string objectiveTitleLabel, string objectiveText, bool isObjectiveTitleRawText = true) => CallFunction("ADD_OBJECTIVE_TO_WALL", wallID, objectiveTitleLabel, objectiveText, isObjectiveTitleRawText);
        public void AddArenaUnlockToWall(string wallID, string objectiveTitleLabel, string objectiveText, bool isObjectiveTitleRawText = true) => CallFunction("ADD_ARENA_UNLOCK_TO_WALL", wallID, objectiveTitleLabel, objectiveText, isObjectiveTitleRawText);
        public void AddMissionResultToWall(string wallID, string missionTextLabel, string passFailTextLabel, string missionReasonString, bool isReasonRawText, bool isPassFailRawText, bool isMissionTextRawText, int forcedAlpha, HudColor hudColourId) => CallFunction("ADD_MISSION_RESULT_TO_WALL", wallID, missionTextLabel, passFailTextLabel, missionReasonString, isReasonRawText, isPassFailRawText, isMissionTextRawText, forcedAlpha, (int)hudColourId);
        public void AddTimeToWall(string wallID, int time, string timeTitleLabel, int timeDifference) => CallFunction("ADD_TIME_TO_WALL", wallID, time, timeTitleLabel, timeDifference);
        public void AddChallengeSetToWall(string wallID, int score, int time, string setTextLabel, string challengeName, int alpha) => CallFunction("ADD_CHALLENGE_SET_TO_WALL", wallID, score, time, setTextLabel, challengeName, alpha);
        public void AddStatNumericToWall(string wallID, string statLabel, int statValue, int xAlign = 0, bool isRawText = true) => CallFunction("ADD_STAT_NUMERIC_TO_WALL", wallID, statLabel, statValue, xAlign, isRawText);
        public void AddCashWonToWall(string wallID, string statLabel, int statValue, int potentialValue, int xAlign = 0, bool isRawText = true) => CallFunction("ADD_CASH_WON_TO_WALL", wallID, statLabel, statValue, potentialValue, xAlign, isRawText);
        //TODO: cash increments
        public void AddWaveReachedToWall(string wallID, string waveText, string reachedLabel) => CallFunction("ADD_WAVE_REACHED_TO_WALL", wallID, waveText, reachedLabel);
        public void AddWorldRecordToWall(string wallID, int time) => CallFunction("ADD_WORLD_RECORD_TO_WALL", wallID, time);
        public void AddTournamentToWall(string wallID, string playlistName, string qualificationLabel, string resultText, bool isResultTextRawText, int resultValue) => CallFunction("ADD_TOURNAMENT_TO_WALL", wallID, playlistName, qualificationLabel, resultText, isResultTextRawText, resultValue);
        public void AddReadyToWall(string wallID, string readyLabel) => CallFunction("ADD_READY_TO_WALL", wallID, readyLabel);
        public void AddCashToWall(string wallID, int cashAmount, int xAlign = 0) => CallFunction("ADD_CASH_TO_WALL", wallID, cashAmount, xAlign);
        public void AddPostUnlockCashToWall(string wallID, int cashAmount, int xAlign = 0) => CallFunction("ADD_POST_UNLOCK_CASH_TO_WALL", wallID, cashAmount, xAlign);
        public void AddChallengePartToWall(string wallID, string winLoseTextLabel, string challengePartsText) => CallFunction("ADD_CHALLENGE_PART_TO_WALL", wallID, winLoseTextLabel, challengePartsText);

        MPCelebrationBG mpCelebrationBG;
        MPCelebrationFG mpCelebrationFG;
        AnimPostFX t_animPostFX;

        protected override void OnTestStart()
        {
            mpCelebrationBG = new MPCelebrationBG();
            mpCelebrationFG = new MPCelebrationFG();

            string wallID = "intro";
            int alpha1 = 75;
            int alpha2 = 75;
            string color = "HUD_COLOUR_BLUE";
            string color1 = "HUD_COLOR_FACEBOOK_BLUE";            
            TextureID textureID = TextureID.SHARD_REMIX_3;

            t_animPostFX = new AnimPostFX(AnimPostFXEffect.HeistCelebPass, 0, true, true);

            List<MPCelebration> scaleforms = new List<MPCelebration> { this, mpCelebrationBG, mpCelebrationFG };
            foreach (MPCelebration scaleform in scaleforms)
            {
                scaleform.LoadAndWait();
                scaleform.CleanUp(wallID);
                scaleform.CreateStateWall(wallID, color, alpha1);
                scaleform.AddBackgroundToWall(wallID, alpha2, textureID);
                //scaleform.AddIntroToWall(wallID, "Mode Label", "Job Name", "Challenge Text Label", "Challenge Parts Text", "Target Type Text Label", 69_666_420, 100, '$', true, color1);
                scaleform.AddPositionToWall(wallID, 2, "Position Label", true, true);
                scaleform.AddScoreToWall(wallID, "Score Label", 69);
                scaleform.AddJobPointsToWall(wallID, 420, 100);
                scaleform.AddArenaPointsToWall(wallID, 666, 500);
                scaleform.AddPointsToWall(wallID, 69_666, 0, "+", 0, 50, false);
                scaleform.AddRepPointsAndRankBarToWall(wallID, 900, 100, 50, 800, 69, 70, "Rank 1 Text", "Rank 2 Text");
                scaleform.AddArenaPointsAndRankBarToWall(wallID, 900, 100, 50, 800, 69, 70, "Rank 1 Text", "Rank 2 Text");                
                scaleform.AddWinnerToWall(wallID, "You won a car!", "Vincentsgm", "Vincentsgm Modifications", 69, true, "France", false);
                scaleform.AddWinnerToWall(wallID, "You won a truck!", "BadMusician", "BadMusician.ru", 420, true, "Russia", false);
                scaleform.AddObjectiveToWall(wallID, "Objective Title", "Objective Text", true);
                scaleform.AddArenaUnlockToWall(wallID, "Arena Objective Title", "Arena Objective Text", true);
                scaleform.AddMissionResultToWall(wallID, "Mission Text", "Mission Fail Text", "Mission Reason", true, true, true, 75, HudColor.Green);
                scaleform.AddTimeToWall(wallID, 69, "Time Title", 20);
                scaleform.AddChallengeSetToWall(wallID, 999, 69, "Text Label", "Challenge Name", 75);
                scaleform.AddStatNumericToWall(wallID, "Stat Label", 420);
                scaleform.AddCashWonToWall(wallID, "Cash Won", 666, 1337);
                scaleform.AddWaveReachedToWall(wallID, "Wave Text", "Reached Label");
                scaleform.AddWorldRecordToWall(wallID, 2345);
                scaleform.AddTournamentToWall(wallID, "Playlist Name", "Qualification Label", "Result Text", true, 69);
                scaleform.AddReadyToWall(wallID, "Ready Label");
                //scaleform.AddCashToWall(wallID, 10_000_000);
                //scaleform.AddCashToWall(wallID, 10_000_000);
                //scaleform.AddChallengePartToWall(wallID, "Win Lose Text Label", "Challenge Parts Text");

            }

            string scaleformHandles = string.Empty;

            foreach (MPCelebration scaleform in scaleforms)
            {
                scaleformHandles += $"{scaleform.MovieName}: {scaleform.Handle}\n";
                scaleform.ShowStatWall(wallID);
            }
            Rage.Game.DisplayNotification(scaleformHandles);
        }

        protected override void TestDraw()
        { 
            mpCelebrationBG.DrawMasked(mpCelebrationFG, Color);
            Draw();
        }

        protected override void OnTestEnd()
        {
            if (mpCelebrationBG?.IsLoaded ?? false) mpCelebrationBG.Release();
            if (mpCelebrationFG?.IsLoaded ?? false) mpCelebrationFG.Release();
            t_animPostFX.Dispose();
            t_animPostFX = null;
        }

    }
}
