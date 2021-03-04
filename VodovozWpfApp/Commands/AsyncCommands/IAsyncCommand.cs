using System.Threading.Tasks;
using System.Windows.Input;

namespace VodovozWpfApp
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
