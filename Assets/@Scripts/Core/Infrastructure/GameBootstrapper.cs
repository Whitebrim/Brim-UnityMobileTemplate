using Core.Infrastructure.States;
using Core.Services;
using Core.Services.AssetManagement;
using Core.Services.Audio;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using VContainer;

namespace Core.Infrastructure
{
    [RequireComponent(typeof(MainThreadDispatcher), typeof(AudioSystem))]
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public static bool IsInitialized;

        [SerializeField] private ConditionalAssetManager assetManager;
        
        private Game _game;

        [Inject]
        private void Construct(Game game)
        {
            _game = game;
        }

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

            IsInitialized = true;

            _game.StateMachine.Enter<BootstrapState>();
        }

        private void ApplicationInit()
        {
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
            Addressables.InitializeAsync();
        }
    }
}