using ProjectName.Configs;
using ProjectName.Runtime.Common.Constants;
using ProjectName.Runtime.Services.AssetManagement;

namespace ProjectName.Runtime.Services.Configs
{
  public class ConfigProvider
  {
    private readonly AssetLoader _assetLoader;

    public ConfigProvider(AssetLoader assetLoader) =>
      _assetLoader = assetLoader;

    public UIConfig UIConfig { get; private set; }

    public void Load()
    {
      UIConfig = _assetLoader.Load<UIConfig>(AssetsPath.UIConfigPath);
    }
  }
}