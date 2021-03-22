using Rage;
using static Rage.Native.NativeFunction;

namespace ScaleformsResearch
{
    internal class Sound
    {
        public int Id { get; set; }

        public Sound(int id)
        {
            this.Id = id;
        }
        public Sound() : this(GetId()) { }

        public void Play(string soundName, string setName, bool p3 = false, int p4 = 0, bool p5 = true)
        {
            if (setName != null) Natives.PLAY_SOUND(Id, soundName, setName, p3, p4, p5);
            else Natives.PLAY_SOUND(Id, soundName, 0, p3, p4, p5);
        }

        public void PlayFrontend(string soundName, string setName, bool p3 = false)
        {
            if (setName != null) Natives.PLAY_SOUND_FRONTEND(Id, soundName, setName, p3);
            else Natives.PLAY_SOUND_FRONTEND(Id, soundName, 0, p3);
        }

        public void PlayFromEntity(string soundName, string setName, Entity entity, bool p4 = false, int p5 = 0)
        {
            if (setName != null) Natives.PLAY_SOUND_FROM_ENTITY(Id, soundName, entity, setName, p4, p5);
            else Natives.PLAY_SOUND_FROM_ENTITY(Id, soundName, entity, 0, p4, p5);
        }

        public void PlayFromPosition(string soundName, string setName, Vector3 position, bool p6 = false, int p7 = 0, bool p8 = false)
        {
            if (setName != null) Natives.PLAY_SOUND_FROM_COORD(Id, soundName, position.X, position.Y, position.Z, setName, p6, p7, p8);
            else Natives.PLAY_SOUND_FROM_COORD(Id, soundName, position.X, position.Y, position.Z, 0, p6, p7, p8);
        }

        public void SetVariable(string variableName, float value)
        {
            Natives.SET_VARIABLE_ON_SOUND(Id, variableName, value);
        }

        public void Stop()
        {
            Natives.STOP_SOUND(Id);
        }

        public bool HasFinished => Natives.HAS_SOUND_FINISHED<bool>(Id);

        public void ReleaseId()
        {
            Natives.RELEASE_SOUND_ID(Id);
            Id = -1;
        }

        public static int GetId()
        {
            return Natives.GET_SOUND_ID<int>();
        }

        public static bool RequestMissionAudioBank(string audioBankName, bool p1 = true)
        {
            return Natives.REQUEST_MISSION_AUDIO_BANK<bool>(audioBankName, p1);
        }
        public static bool RequestAmbientAudioBank(string audioBankName, bool p1 = true)
        {
            return Natives.REQUEST_AMBIENT_AUDIO_BANK<bool>(audioBankName, p1);
        }
        public static bool RequestScriptAudioBank(string audioBankName, bool p1 = true)
        {
            return Natives.REQUEST_SCRIPT_AUDIO_BANK<bool>(audioBankName, p1);
        }
    }
}

