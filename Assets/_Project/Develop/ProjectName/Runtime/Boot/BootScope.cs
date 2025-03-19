using VContainer;
using VContainer.Unity;

namespace ProjectName.Runtime.Boot
{
  public class BootScope : LifetimeScope
  {
    protected override void Configure(IContainerBuilder builder)
    {
      builder.RegisterEntryPoint<BootEntryPoint>();
    }
  }
}