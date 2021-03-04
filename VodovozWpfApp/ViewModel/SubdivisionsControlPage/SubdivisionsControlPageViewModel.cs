using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Vodovoz.Models.ClientSide.Database;

namespace VodovozWpfApp
{
    public class SubdivisionsControlPageViewModel : BaseViewModel
    {
        public override AppPageEnum AppPageEnumName => AppPageEnum.SubdivisionsControlPage;
        #region Fields

        private EmployeesRepository _employeesRepository { get; set; }
        private SubdivisionsRepository _subdivisionsRepository { get; set; }
        private NavigationService _navigationService { get; set; } 
        #endregion


        public SubdivisionsControlPageViewModel()
        {
            _employeesRepository = (EmployeesRepository)DI.ServiceProvider.GetService<IEmployeesRepo>();
            _subdivisionsRepository = (SubdivisionsRepository)DI.ServiceProvider.GetService<ISubdivisionsRepo>();
            _navigationService = (NavigationService)DI.ServiceProvider.GetService<NavigationService>();

            EmployeesList = new ObservableCollection<Employee>(_employeesRepository.Employees);
            SubdivisionsList = new ObservableCollection<Subdivision>(_subdivisionsRepository.Subdivisions);            
        }

        #region Properties
        public ObservableCollection<Employee> EmployeesList { get; set; }
        public Subdivision SelectedSubdivision { get; set; }
        public ObservableCollection<Subdivision> SubdivisionsList { get; set; } 
        public int HistoricCount { get => _navigationService._historic.Count; }
        #endregion

        #region Commands


        private AsyncCommand<object> _rowEditEndingCommand = null;
        public AsyncCommand<object> RowEditEndingCommand => _rowEditEndingCommand ??
            (_rowEditEndingCommand = new AsyncCommand<object>(_rowEditEndingCommandMethod));

        private async Task _rowEditEndingCommandMethod(object args)            
        {
            Subdivision employee = ((args as DataGridRowEditEndingEventArgs).Row.DataContext) as Subdivision;            
            await _subdivisionsRepository.UpdateOrAddSubdivisionAsync(employee).ConfigureAwait(false);            
        }

        private AsyncCommand<object> _deleteCommand = null;
        public AsyncCommand<object> DeleteCommand => _deleteCommand ??
            (_deleteCommand = new AsyncCommand<object>(_deleteCommandMethod));
        private async Task _deleteCommandMethod(object args)
        {
            var KeyString = (args as KeyEventArgs).Key.ToString();
            if (KeyString == "Delete")
            {
                await _subdivisionsRepository.DeleteSubdivisionAsync(SelectedSubdivision).ConfigureAwait(false);
            }
        }


        private RelayCommand<object> _navigateToEmployee = null;
        public RelayCommand<object> NavigateToEmployee => _navigateToEmployee ??
            (_navigateToEmployee = new RelayCommand<object>(_navigateToEmployeeCommandMethod));
        private void _navigateToEmployeeCommandMethod(object id)
        {
            if (id == null) return;
            var Id = (long)id;
            _navigationService.NavigateTo(AppPageEnum.EmployeePage, Id);
        }

        private RelayCommand<object> _navigateToSubdivisionCommand = null;
        public RelayCommand<object> NavigateToSubdivisionCommand => _navigateToSubdivisionCommand ??
            (_navigateToSubdivisionCommand = new RelayCommand<object>(_navigateToSubdivisionCommandMethod));

        private void _navigateToSubdivisionCommandMethod(object id)
        {
            if (id == null) return;
            var Id = (long)id;
            _navigationService.NavigateTo(AppPageEnum.SubdivisionPage, Id);
        }

        private RelayCommand _navigateToEmployeesControlCommand = null;
        public RelayCommand NavigateToEmployeesControlCommand => _navigateToEmployeesControlCommand ??
            (_navigateToEmployeesControlCommand = new RelayCommand(_navigateToEmployeesControlCommandMethod));
        private void _navigateToEmployeesControlCommandMethod()
        {
            _navigationService.NavigateTo(AppPageEnum.EmployeesControlPage, null);
        }



        private RelayCommand _navigateToOrdersControlCommand = null;
        public RelayCommand NavigateToOrdersControlCommand => _navigateToOrdersControlCommand ??
            (_navigateToOrdersControlCommand = new RelayCommand(_navigateToOrdersControlCommandMethod));
        private void _navigateToOrdersControlCommandMethod()
        {
            _navigationService.NavigateTo(AppPageEnum.OrdersControlPage, null);
        }

        private RelayCommand _goBackCommand = null;
        public RelayCommand GoBackCommand => _goBackCommand ??
            (_goBackCommand = new RelayCommand(_goBackCommandMethod));

        private void _goBackCommandMethod()
        {
            _navigationService.GoBack();
        }

        #endregion
    }
}
