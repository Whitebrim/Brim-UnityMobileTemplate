using UnityEngine;

namespace Core.Services.AssetManagement
{
    public interface IAssetProvider
    {
        TObject Load<TObject>(string path) where TObject : Object;
    }
}