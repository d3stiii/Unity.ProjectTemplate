using UnityEngine;

namespace ProjectName.Runtime.Core.Services
{
  public class CameraProvider
  {
    private Camera _mainCamera;

    public Camera MainCamera
    {
      get
      {
        if (_mainCamera == null)
          _mainCamera = Camera.main;

        return _mainCamera;
      }
    }
  }
}