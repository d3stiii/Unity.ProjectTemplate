using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectName.Runtime.Common.UI
{
  public class BaseContextMenu : BaseWindow<Vector3>, IDeselectHandler
  {
    public override void OnOpening(Vector3 arg) =>
      transform.position = arg;

    public void OnDeselect(BaseEventData eventData) =>
      Unselect().Forget();

    private async UniTask Unselect(CancellationToken token = default)
    {
      await UniTask.DelayFrame(1, cancellationToken: token);

      var currentSelected = EventSystem.current.currentSelectedGameObject;
      if (currentSelected == null || !currentSelected.transform.IsChildOf(transform))
        UIService.Close(this);
      else
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
  }
}