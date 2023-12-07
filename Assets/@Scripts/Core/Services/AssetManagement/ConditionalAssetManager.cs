using System;
using Sirenix.OdinInspector;
using UnityEngine.AddressableAssets;
using UnityEngine;

namespace Core.Services.AssetManagement
{
    public class ConditionalAssetManager : SerializedScriptableObject
    {
        //Example
        //[HideLabel, BoxGroup(GroupID = "Nakama Connection", CenterLabel = true, LabelText = "Nakama Connection", ShowLabel = true)] public VariableAsset<NakamaConnection> NakamaConnection;
    }

    [Serializable]
    public class VariableAsset<TObj> where TObj : UnityEngine.Object
    {
        public TObj Load => Debug.isDebugBuild ? debug.LoadAndCache() : release.LoadAndCache();

        [SerializeField, HorizontalGroup(LabelWidth = 60, MarginLeft = 0.01f)] private AssetReferenceT<TObj> release;
        [SerializeField, HorizontalGroup(MarginLeft = 0.05f, MarginRight = 0.01f)] private AssetReferenceT<TObj> debug;
    }
}