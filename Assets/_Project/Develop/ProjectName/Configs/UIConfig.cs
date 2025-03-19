using System;
using System.Collections.Generic;
using ProjectName.Runtime.Common.UI;
using ProjectName.Runtime.Core.UI.HUD;
using UnityEngine;

namespace ProjectName.Configs
{
  [CreateAssetMenu(menuName = "Configs/UIConfig", fileName = "UIConfig")]
  public class UIConfig : ScriptableObject
  {
    [SerializeField] private List<NoParameterWindow> _uiPrefabs;
    [field: SerializeField] public UIRoot UIRootPrefab { get; private set; }
    [field: SerializeField] public Hud HudPrefab { get; private set; }

    public TWindow GetWindow<TWindow>() where TWindow : NoParameterWindow
    {
      foreach (var baseWindow in _uiPrefabs)
        if (baseWindow is TWindow screen)
          return screen;

      throw new IndexOutOfRangeException($"Can't find window of type {typeof(TWindow)}");
    }
  }
}