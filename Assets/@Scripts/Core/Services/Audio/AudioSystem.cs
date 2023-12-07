using UnityEngine;

namespace Core.Services.Audio
{
    public class AudioSystem : MonoBehaviour
    {
        [SerializeField] AudioSource music;
        [SerializeField] AudioSource effects;

        public void ChangeVolume(AudioType audioType, float value)
        {
            switch (audioType)
            {
                case AudioType.MUSIC:
                    music.volume = value;
                    break;
                case AudioType.SFX:
                    effects.volume = value;
                    break;
            }
        }

        public void PlayClip(AudioBase sound, AudioType audioType, float volumeScale = 1)
        {
            if (sound is null || sound.Clip is null) return;
            PlayClip(sound.Clip.LoadAndCache(), audioType, volumeScale);
        }

        public void PlayClip(AudioClip clip, AudioType audioType, float volumeScale = 1)
        {
            if (clip is null) return;
            switch (audioType)
            {
                case AudioType.MUSIC:
                    music.PlayOneShot(clip, volumeScale);
                    break;
                case AudioType.SFX:
                    effects.PlayOneShot(clip, volumeScale);
                    break;
            }
        }
    }

    public enum AudioType
    {
        MUSIC = 0,
        SFX = 1
    }
}