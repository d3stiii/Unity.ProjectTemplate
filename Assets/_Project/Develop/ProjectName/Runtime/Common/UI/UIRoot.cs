using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ProjectName.Runtime.Common.UI
{
  public class UIRoot : SerializedMonoBehaviour
  {
    [SerializeField] private Dictionary<UILayer, Canvas> _layers;

    public Canvas GetLayerCanvas(UILayer layer)
    {
      if (_layers.TryGetValue(layer, out var canvas))
        return canvas;

      throw new IndexOutOfRangeException($"Can't find layer {layer}");
    }
  }
}