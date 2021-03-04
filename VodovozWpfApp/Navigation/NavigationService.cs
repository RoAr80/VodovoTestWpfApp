using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VodovozWpfApp
{
    public class NavigationService
    {
        
        public readonly Stack<object[]> _historic;
        private ApplicationWindowViewModel _applicationWindowViewModel;
        private Mediator _mediator;

        public NavigationService(ApplicationWindowViewModel applicationWindowViewModel, Mediator mediator)
        {
            _historic = new Stack<object[]>();
            _applicationWindowViewModel = applicationWindowViewModel;
            _mediator = mediator;
        }

        public void NavigateTo(AppPageEnum appPageEnum, object payload)
        {
            _applicationWindowViewModel.CurrentPage = appPageEnum;
            _historic.Push(new object[2] { appPageEnum, payload});
            _mediator.Send(appPageEnum, payload);
        }

        public void GoBack()
        {
            if(_historic.Count > 1)
            {
                _historic.Pop();
                var toNavigateData = _historic.Pop();

                NavigateTo((AppPageEnum)toNavigateData[0], toNavigateData[1]);

            }
        }
    }
}
