using Core.Infrastructure.States;
using Core.Services;
using Core.Services.AssetManagement;
using Core.Services.Audio;
using Core.Services.SceneLoader;
using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Core.Infrastructure.DI
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private GameBootstrapper gameBootstrapper;
        [SerializeField] private AudioSystem audioSystem;
        [SerializeField] private MainThreadDispatcher mainThreadDispatcher;
        [SerializeField] private ApplicationFocus applicationFocus;
        [SerializeField] private ConditionalAssetManager conditionalAssetManager;

        protected override void Configure(IContainerBuilder builder)
        {
            if (GameBootstrapper.IsInitialized) return;

            builder.Register<IObjectResolver, Container>(Lifetime.Scoped);

            builder.RegisterComponent(gameBootstrapper).AsImplementedInterfaces();
            builder.RegisterComponent(audioSystem);
            builder.RegisterComponent(mainThreadDispatcher);
            builder.RegisterComponent(applicationFocus);

            builder.Register<BootstrapState>(Lifetime.Singleton);
            builder.Register<LoadLevelState>(Lifetime.Singleton);
            builder.Register<GameLoopState>(Lifetime.Singleton);
            builder.Register<GameStateMachine>(Lifetime.Singleton);

            builder.Register<Game>(Lifetime.Singleton);

            builder.Register<SceneLoader>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<AddressablesProvider>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.RegisterInstance<ConditionalAssetManager>(conditionalAssetManager);
        }
    }
}
