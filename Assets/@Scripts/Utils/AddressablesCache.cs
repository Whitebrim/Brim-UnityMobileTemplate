using System;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;

/// <summary>
/// Хранит кэш для <see cref="AddressablesLoader"/>
/// </summary>
public class AddressablesCache
{
    private static readonly Lazy<AddressablesCache> LazyLoader = new Lazy<AddressablesCache>(() => new AddressablesCache());
    public static AddressablesCache Instance => LazyLoader.Value;
    public readonly Dictionary<AssetReference, UnityEngine.Object> Cache;

    public AddressablesCache()
    {
        Cache = new Dictionary<AssetReference, UnityEngine.Object>();
    }
}