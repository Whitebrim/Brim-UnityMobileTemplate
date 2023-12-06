using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using Object = UnityEngine.Object;

namespace Core.Services.AssetManagement
{
    public class AddressablesProvider : IAssetProvider
    {
        private static readonly Dictionary<string, Object> Cache = new();

        public TObject Load<TObject>(string path) where TObject : Object =>
            Addressables.LoadAssetAsync<TObject>(path).WaitForCompletion();

        public static TObject LoadPrefab<TObject>(AssetReferenceGameObject assetReference) where TObject : Object
        {
            if (!Cache.ContainsKey(assetReference.AssetGUID))
            {
                Cache.Add(assetReference.AssetGUID,
                    assetReference.LoadAssetAsync().WaitForCompletion().GetComponent<TObject>());
            }

            return (TObject)Cache[assetReference.AssetGUID];
        }

        public static void LoadPrefabAsync<TObject>(AssetReferenceGameObject assetReference, Action<TObject> onLoad)
            where TObject : Object
        {
            if (!Cache.ContainsKey(assetReference.AssetGUID))
            {
                assetReference.LoadAssetAsync().Completed += (result) =>
                {
                    Cache.Add(assetReference.AssetGUID, result.Result.GetComponent<TObject>());
                    onLoad?.Invoke((TObject)Cache[assetReference.AssetGUID]);
                };
                return;
            }

            onLoad?.Invoke((TObject)Cache[assetReference.AssetGUID]);
        }
    }
}