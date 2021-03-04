using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VodovozWpfApp
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region Mediator Implementation
        public Mediator Mediator;

        public abstract AppPageEnum AppPageEnumName { get; }

        #endregion
        
        #region Constructor

        public BaseViewModel()
        {
            Mediator = DI.ServiceProvider.GetService<Mediator>();
            
        }
        #endregion       

        #region INotifyPropertyChanged Implementation
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public void CallerPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
