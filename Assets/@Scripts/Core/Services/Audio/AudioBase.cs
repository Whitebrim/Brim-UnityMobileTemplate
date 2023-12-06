using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Core.Services.Audio
{
    [System.Serializable]
    public class AudioBase
    {
        public AssetReferenceT<AudioClip> Clip;
    }
}