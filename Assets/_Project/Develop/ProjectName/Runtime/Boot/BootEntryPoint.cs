using ProjectName.Runtime.Common.Constants;
using ProjectName.Runtime.Services.Configs;
using ProjectName.Runtime.Services.SceneManagement;
using VContainer.Unity;

namespace ProjectName.Runtime.Boot
{
  public class BootEntryPoint : IStartable
  {
    private readonly ConfigProvider _configProvider;
    private readonly SceneLoader _sceneLoader;

    public BootEntryPoint(ConfigProvider configProvider, SceneLoader sceneLoader)
    {
      _configProvider = configProvider;
      _sceneLoader = sceneLoader;
    }

    public void Start()
    {
      _configProvider.Load();

      _sceneLoader.Load(SceneNames.Core);
    }
  }
}