using System.Threading;
using Cysharp.Threading.Tasks;
using ProjectName.Runtime.Services.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

namespace ProjectName.Runtime.Common.UI
{
  public abstract class NoParameterWindow : MonoBehaviour
  {
    private bool _isInAnimation;
    protected UIService UIService { get; private set; }

    [Inject]
    public void Construct(UIService uiService) =>
      UIService = uiService;

    public async UniTask ShowAnimationAsync()
    {
      if (_isInAnimation)
      {
        Debug.LogError("Window is already in animation");
        return;
      }

      _isInAnimation = true;

      await PlayShowAnimationAsync();

      _isInAnimation = false;
    }

    public async UniTask HideAnimationAsync()
    {
      if (_isInAnimation)
      {
        Debug.LogError("Window is already in animation");
        return;
      }

      _isInAnimation = true;

      await PlayHideAnimationAsync();

      _isInAnimation = false;
    }

    public virtual void OnClosing() { }

    public virtual void Focus()
    {
      transform.SetAsLastSibling();
      EventSystem.current?.SetSelectedGameObject(gameObject);
    }

    protected virtual async UniTask PlayShowAnimationAsync() =>
      await UniTask.CompletedTask;

    protected virtual async UniTask PlayHideAnimationAsync() =>
      await UniTask.CompletedTask;

    public async UniTask WaitForAnimationEndAsync(CancellationToken token = default)
    {
      await UniTask.DelayFrame(1, cancellationToken: token);

      while (_isInAnimation)
        await UniTask.DelayFrame(1, cancellationToken: token);
    }
  }
}