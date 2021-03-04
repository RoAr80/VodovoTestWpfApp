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
    public class OrdersControlPageViewModel : BaseViewModel
    {
        public override AppPageEnum AppPageEnumName => AppPageEnum.OrdersControlPage;
        private EmployeesRepository _employeesRepository { get; set; }
        private OrdersRepository _ordersRepository { get; set; }
        private NavigationService _navigationService { get; set; }

        public OrdersControlPageViewModel()
        {
            _employeesRepository = (EmployeesRepository)DI.ServiceProvider.GetService<IEmployeesRepo>();
            _ordersRepository = (OrdersRepository)DI.ServiceProvider.GetService<IOrdersRepo>();
            _navigationService = DI.ServiceProvider.GetService<NavigationService>();

            OrdersList = new ObservableCollection<Order>(_ordersRepository.Orders);
            EmployeesList = new ObservableCollection<Employee>(_employeesRepository.Employees);

        }

        public ObservableCollection<Order> OrdersList { get; set; }
        public Order SelectedOrder { get; set; }
        public ObservableCollection<Employee> EmployeesList { get; set; }
        public int HistoricCount { get => _navigationService._historic.Count; }

        private AsyncCommand<object> _rowEditEndingCommand = null;
        public AsyncCommand<object> RowEditEndingCommand => _rowEditEndingCommand ??
            (_rowEditEndingCommand = new AsyncCommand<object>(_rowEditEndingCommandMethod));

        private async Task _rowEditEndingCommandMethod(object args)
        {
            Order order = ((args as DataGridRowEditEndingEventArgs).Row.DataContext) as Order;
            await _ordersRepository.UpdateOrAddOrderAsync(order).ConfigureAwait(false);
        }

        private AsyncCommand<object> _deleteCommand = null;
        public AsyncCommand<object> DeleteCommand => _deleteCommand ??
            (_deleteCommand = new AsyncCommand<object>(_deleteCommandMethod));

        private async Task _deleteCommandMethod(object args)
        {
            var KeyString = (args as KeyEventArgs).Key.ToString();
            if (KeyString == "Delete")
            {
                await _ordersRepository.DeleteOrderAsync(SelectedOrder).ConfigureAwait(false);
            }
        }

        private RelayCommand<object> _navigateToEmployeeCommand = null;
        public RelayCommand<object> NavigateToEmployeeCommand => _navigateToEmployeeCommand ??
            (_navigateToEmployeeCommand = new RelayCommand<object>(_navigateToEmployeeCommandMethod));
        private void _navigateToEmployeeCommandMethod(object id)
        {
            if (id == null) return;
            var Id = (long)id;
            _navigationService.NavigateTo(AppPageEnum.EmployeePage, Id);
        }

        private RelayCommand _goBackCommand = null;
        public RelayCommand GoBackCommand => _goBackCommand ??
            (_goBackCommand = new RelayCommand(_goBackCommandMethod));

        private void _goBackCommandMethod()
        {
            _navigationService.GoBack();
        }

        private RelayCommand _navigateToEmployeesControlCommand = null;
        public RelayCommand NavigateToEmployeesControlCommand => _navigateToEmployeesControlCommand ??
            (_navigateToEmployeesControlCommand = new RelayCommand(_navigateToEmployeesControlCommandMethod));
        private void _navigateToEmployeesControlCommandMethod()
        {            
            _navigationService.NavigateTo(AppPageEnum.EmployeesControlPage, null);
        }

        private RelayCommand _navigateToSubdivisionsControlCommand = null;
        public RelayCommand NavigateToSubdivisionsControlCommand => _navigateToSubdivisionsControlCommand ??
            (_navigateToSubdivisionsControlCommand = new RelayCommand(_navigateToSubdivisionsControlCommandMethod));
        private void _navigateToSubdivisionsControlCommandMethod()
        {
            _navigationService.NavigateTo(AppPageEnum.SubdivisionsControlPage, null);
        }
    }
}
