using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class AddressablesLoader
{
    /// <summary>
    /// Возвращает закэшированный ассет или грузит его и кэширует
    /// </summary>
    public static T LoadAndCache<T>(this AssetReference asset) where T : Object
    {
        if (AddressablesCache.Instance.Cache.TryGetValue(asset, out var product))
        {
            return (T)product;
        }
        else
        {
            T result = Addressables.LoadAssetAsync<T>(asset.RuntimeKey).WaitForCompletion();
            if (result != null)
                AddressablesCache.Instance.Cache[asset] = result;
            return result;
        }
    }

    /// <summary>
    /// Возвращает закэшированный ассет или грузит его и кэширует
    /// </summary>
    public static T LoadAndCache<T>(this AssetReferenceT<T> asset) where T : Object
    {
        if (AddressablesCache.Instance.Cache.TryGetValue(asset, out var product))
        {
            return (T)product;
        }
        else
        {
            T result = Addressables.LoadAssetAsync<T>(asset.RuntimeKey).WaitForCompletion();
            if (result != null)
                AddressablesCache.Instance.Cache[asset] = result;
            return result;
        }
    }

    public static async Task<T> LoadAndCacheAsync<T>(this AssetReferenceT<T> asset) where T : Object
    {
        if (AddressablesCache.Instance.Cache.TryGetValue(asset, out var product))
        {
            return (T)product;
        }

        AsyncOperationHandle<T> asyncOperation = Addressables.LoadAssetAsync<T>(asset.RuntimeKey);
        asyncOperation.Completed += (x) =>
        {
            if (x.OperationException == null && x.Result != null) AddressablesCache.Instance.Cache[asset] = x.Result;
        };
        
        return await asyncOperation.Task;
    }
}