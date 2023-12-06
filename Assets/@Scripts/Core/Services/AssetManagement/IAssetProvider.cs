using Core.Infrastructure.Services;
using UnityEngine;

namespace Core.Services.AssetManagement
{
    public interface IAssetProvider : IService
    {
        TObject Load<TObject>(string path) where TObject : Object;
    }
}