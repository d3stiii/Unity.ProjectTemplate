using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ProjectName.Runtime.Common.UI;
using ProjectName.Runtime.Core.UI.HUD;

namespace ProjectName.Runtime.Services.UI
{
  public class UIService
  {
    private readonly Dictionary<Type, NoParameterWindow> _cachedWindows = new();
    private readonly UIFactory _uiFactory;
    private Hud _hud;

    public UIService(UIFactory uiFactory) =>
      _uiFactory = uiFactory;

    public Hud Hud => _hud ??= _uiFactory.CreateHud();

    public TWindow Open<TWindow>(UILayer layer)
      where TWindow : BaseWindow
    {
      var window = (TWindow)GetWindow<TWindow>(layer);
      window.OnOpening();
      window.Focus();

      window.ShowAnimationAsync().Forget();

      return window;
    }

    public TWindow Open<TWindow, TArg>(TArg arg, UILayer layer)
      where TWindow : BaseWindow<TArg>
    {
      var window = (TWindow)GetWindow<TWindow>(layer);
      window.OnOpening(arg);
      window.Focus();

      window.ShowAnimationAsync().Forget();

      return window;
    }

    public void Close<TWindow>()
      where TWindow : NoParameterWindow
    {
      if (_cachedWindows.TryGetValue(typeof(TWindow), out var cachedWindow))
        CloseAsync(cachedWindow).Forget();
    }

    public void Close<TWindow>(TWindow window)
      where TWindow : NoParameterWindow
    {
      CloseAsync(window).Forget();
    }

    public bool IsOpened<TWindow>() where TWindow : NoParameterWindow =>
      _cachedWindows.TryGetValue(typeof(TWindow), out var ui) && ui.isActiveAndEnabled;

    public void CloseAll()
    {
      foreach (var openedWindow in _cachedWindows.Values)
        CloseAsync(openedWindow).Forget();
    }

    private NoParameterWindow GetWindow<TWindow>(UILayer layer)
      where TWindow : NoParameterWindow
    {
      if (_cachedWindows.TryGetValue(typeof(TWindow), out var cachedWindow))
      {
        cachedWindow.gameObject.SetActive(true);
        return cachedWindow;
      }

      var newWindow = _uiFactory.CreateWindow<TWindow>(layer);
      _cachedWindows.Add(typeof(TWindow), newWindow);

      return newWindow;
    }

    private async UniTask CloseAsync(NoParameterWindow window)
    {
      await window.HideAnimationAsync();
      window.gameObject.SetActive(false);
      window.OnClosing();
    }
  }
}