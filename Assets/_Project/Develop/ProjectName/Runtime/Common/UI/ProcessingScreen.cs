using UnityEngine;
using UnityEngine.UI;

namespace ProjectName.Runtime.Common.UI
{
  public class ProcessingScreen : BaseWindow
  {
    [SerializeField] private Image _processingIndicator;
    [SerializeField] private float _indicatorRotationSpeed;

    private void Update() =>
      _processingIndicator.transform.Rotate(0, 0, _indicatorRotationSpeed * Time.deltaTime);
  }
}