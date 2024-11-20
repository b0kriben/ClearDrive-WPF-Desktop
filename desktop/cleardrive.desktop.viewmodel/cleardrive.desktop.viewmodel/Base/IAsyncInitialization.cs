using System.Threading.Tasks;

namespace cleardrive.desktop.viewmodel.Base
{
    public interface IAsyncInitialization
    {
        public Task InitializeAsync();
    }
}
