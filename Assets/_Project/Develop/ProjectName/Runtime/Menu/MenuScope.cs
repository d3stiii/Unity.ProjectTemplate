using VContainer;
using VContainer.Unity;

namespace ProjectName.Runtime.Menu
{
  public class MenuScope : LifetimeScope
  {
    protected override void Configure(IContainerBuilder builder)
    {
      builder.RegisterEntryPoint<MenuEntryPoint>();
    }
  }
}