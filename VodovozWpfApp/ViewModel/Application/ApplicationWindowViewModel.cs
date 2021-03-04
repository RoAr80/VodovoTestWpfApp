using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

using System.Threading.Tasks;
using System.Windows.Controls;

namespace VodovozWpfApp
{
    public class ApplicationWindowViewModel : BaseViewModel
    {

        public AppPageEnum CurrentPage { get; set; }        
        
        public ApplicationWindowViewModel()
        {
            
            VodovozSeedData.EnsurePopulated();

        }
        
        public override AppPageEnum AppPageEnumName => throw new NotImplementedException();

        
    }
}
