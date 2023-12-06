using Core.Infrastructure.Services;
using Core.Infrastructure.States;
using Core.Services;
using Core.Services.AssetManagement;
using Core.Services.Audio;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Core.Infrastructure
{
    [RequireComponent(typeof(MainThreadDispatcher), typeof(AudioSystem))]
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public static bool IsInitialized;
        private static Game _game;
        [SerializeField] private VariableAssets assetManager;

        private void Awake()
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                if (!IsInitialized) SceneManager.LoadScene(0);
                Destroy(gameObject);
                return;
            }
            ApplicationInit();

            DontDestroyOnLoad(this);
            ServiceLocator.Container.RegisterSingle<ICoroutineRunner>(this);
            ServiceLocator.Container.RegisterSingle(GetComponent<AudioSystem>());
            ServiceLocator.Container.RegisterSingle(GetComponent<MainThreadDispatcher>());

            IsInitialized = true;

            _game = new Game(this, assetManager);
            _game.StateMachine.Enter<BootstrapState>();
        }

        private void ApplicationInit()
        {
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
            Addressables.InitializeAsync();
        }
    }
}