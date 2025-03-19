namespace ProjectName.Runtime.Common.UI
{
  public abstract class BaseWindow : NoParameterWindow
  {
    public virtual void OnOpening() { }
  }

  public abstract class BaseWindow<TArg> : NoParameterWindow
  {
    public abstract void OnOpening(TArg arg);
  }
}