using Microsoft.Extensions.DependencyInjection;
using System;
using Vodovoz.Models.ClientSide.Database;

namespace VodovozWpfApp
{
    public class EmployeePageViewModel : BaseViewModel
    {
        public override AppPageEnum AppPageEnumName => AppPageEnum.EmployeePage;
        private EmployeesRepository _employeesRepository { get; set; }
        private NavigationService _navigationService { get; set; }

        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeFatherName { get; set; }
        public string EmployeeBirthday { get; set; }
        public string EmployeeSex { get; set; }
        public Subdivision EmployeeSubdivision { get; set; }

        public EmployeePageViewModel()
        {
            _employeesRepository = (EmployeesRepository)DI.ServiceProvider.GetService<IEmployeesRepo>();
            _navigationService = DI.ServiceProvider.GetService<NavigationService>();

            Mediator.MessageReceived += _mediator_MessageReceived;
        }

        private async void _mediator_MessageReceived(AppPageEnum recipient, object message)
        {
            if (AppPageEnumName == recipient)
            {
                long Id = (long)message;
                if (Id == default(long))
                    return;

                var employeeFromDb = await _employeesRepository.GetEmployeeAsync(Id).ConfigureAwait(false);
                EmployeeId = employeeFromDb.Id;
                EmployeeName = employeeFromDb.Name;
                EmployeeSurname = employeeFromDb.Surname;
                EmployeeFatherName = employeeFromDb.FatherName;
                EmployeeBirthday = employeeFromDb.Birthday.ToShortDateString();
                EmployeeSex = employeeFromDb.Sex.ToString();
                
                if (employeeFromDb.Subdivision != null)
                {
                    EmployeeSubdivision = new Subdivision
                    {
                        Id = employeeFromDb.Subdivision.Id,
                        Name = employeeFromDb.Subdivision.Name,
                        Manager = employeeFromDb.Subdivision.Manager,
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

        private RelayCommand<object> _navigateToSubdivision = null;
        public RelayCommand<object> NavigateToSubdivision => _navigateToSubdivision ??
            (_navigateToSubdivision = new RelayCommand<object>(_navigateToSubdivisionCommandMethod));

        private void _navigateToSubdivisionCommandMethod(object id)
        {
            var Id = (long)id;
            _navigationService.NavigateTo(AppPageEnum.SubdivisionPage, Id);
        }

        
    }
}
