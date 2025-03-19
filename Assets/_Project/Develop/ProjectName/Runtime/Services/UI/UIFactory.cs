using ProjectName.Runtime.Common.UI;
using ProjectName.Runtime.Core.UI.HUD;
using ProjectName.Runtime.Services.Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace ProjectName.Runtime.Services.UI
{
  public class UIFactory
  {
    private readonly ConfigProvider _configProvider;
    private readonly IObjectResolver _container;
    private UIRoot _uiRoot;

    public UIRoot UIRoot
    {
      get
      {
        if (_uiRoot == null)
          _uiRoot = Object.Instantiate(_configProvider.UIConfig.UIRootPrefab);

        return _uiRoot;
      }
    }

    public UIFactory(IObjectResolver container, ConfigProvider configProvider)
    {
      _container = container;
      _configProvider = configProvider;
    }

    public TWindow CreateWindow<TWindow>(UILayer layer) where TWindow : NoParameterWindow
    {
      var screenPrefab = _configProvider.UIConfig.GetWindow<TWindow>();
      return _container.Instantiate(screenPrefab, UIRoot.GetLayerCanvas(layer).transform);
    }

    public Hud CreateHud() =>
      _container.Instantiate(_configProvider.UIConfig.HudPrefab, UIRoot.GetLayerCanvas(UILayer.HUD).transform);
  }
}