using ICities;
using NoDeathcare.Redirection;

namespace NoDeathcare
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnCreated(ILoading loading)
        {
            base.OnCreated(loading);
            AssemblyRedirector.Deploy();
        }

        public override void OnReleased()
        {
            base.OnReleased();
            AssemblyRedirector.Revert();
        }
    }
}