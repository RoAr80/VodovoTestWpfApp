using Microsoft.Extensions.DependencyInjection;
using Vodovoz.Models.ClientSide.Database;

namespace VodovozWpfApp
{
    public class SubdivisionPageViewModel : BaseViewModel
    {
        public override AppPageEnum AppPageEnumName => AppPageEnum.SubdivisionPage;
        private SubdivisionsRepository _subdivisionsRepository { get; set; }
        private NavigationService _navigationService { get; set; }


        public SubdivisionPageViewModel()
        {
            _subdivisionsRepository = (SubdivisionsRepository)DI.ServiceProvider.GetService<ISubdivisionsRepo>();
            _navigationService = DI.ServiceProvider.GetService<NavigationService>();

            Mediator.MessageReceived += _mediator_MessageReceived;
        }

        public string SubdivisionName { get; set; }
        public Employee Manager { get; set; }

        private async void _mediator_MessageReceived(AppPageEnum recipient, object message)
        {
            if(AppPageEnumName == recipient)
            {
                long Id = (long)message;
                if (Id == default(long))
                    return;

                var subdivisionFromDb = await _subdivisionsRepository.GetSubdivisionAsync(Id);
                SubdivisionName = subdivisionFromDb.Name;

                if(subdivisionFromDb.Manager != null)
                {
                    Manager = new Employee
                    {
                        Id = subdivisionFromDb.Manager.Id,
                        Name = subdivisionFromDb.Manager.Name,
                        Surname = subdivisionFromDb.Manager.Surname,
                        FatherName = subdivisionFromDb.Manager.FatherName,
                    };
                }
                else
                {
                    
                }
            }
        }
        private RelayCommand _goBackCommand = null;
        public RelayCommand GoBackCommand => _goBackCommand ??
            (_goBackCommand = new RelayCommand(_goBackCommandMethod));
        private void _goBackCommandMethod()
        {            
            _navigationService.GoBack();
        }

        private RelayCommand<object> _navigateToEmployeeCommand = null;
        public RelayCommand<object> NavigateToEmployeeCommand => _navigateToEmployeeCommand ??
            (_navigateToEmployeeCommand = new RelayCommand<object>(_navigateToEmployeeCommandMethod));

        private void _navigateToEmployeeCommandMethod(object id)
        {
            var Id = (long)id;
            _navigationService.NavigateTo(AppPageEnum.EmployeePage, Id);
        }
    }
}
