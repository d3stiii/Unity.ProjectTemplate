using ProjectName.Runtime.Core.Services;
using ProjectName.Runtime.Services.UI;
using VContainer;
using VContainer.Unity;

namespace ProjectName.Runtime.Core
{
  public class CoreScope : LifetimeScope
  {
    protected override void Configure(IContainerBuilder builder)
    {
      builder.RegisterEntryPoint<CoreEntryPoint>();

      builder.Register<UIFactory>(Lifetime.Singleton);
      builder.Register<UIService>(Lifetime.Singleton);

      builder.Register<CameraProvider>(Lifetime.Singleton);
    }
  }
}