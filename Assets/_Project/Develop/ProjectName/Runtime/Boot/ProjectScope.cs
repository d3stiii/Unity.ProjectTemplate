using ProjectName.Runtime.Common;
using ProjectName.Runtime.Common.EditorTools;
using ProjectName.Runtime.Services.AssetManagement;
using ProjectName.Runtime.Services.Configs;
using ProjectName.Runtime.Services.SceneManagement;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ProjectName.Runtime.Boot
{
  public class ProjectScope : LifetimeScope
  {
    [SerializeField] private CoroutineRunner _coroutineRunner;

    protected override void Configure(IContainerBuilder builder)
    {
#if UNITY_EDITOR
      SwitchToEntrySceneEditor.Init();
#endif

      builder.Register<AssetLoader>(Lifetime.Singleton);
      builder.Register<ConfigProvider>(Lifetime.Singleton);
      builder.RegisterComponentInNewPrefab(_coroutineRunner, Lifetime.Singleton);
      builder.Register<SceneLoader>(Lifetime.Singleton);
    }
  }
}