using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLoL.GlobalClasses;
using XamarinLoL.ViewModel;

namespace XamarinLoL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMasterDetailPage : ContentPage
    {

        public ListView ListPaginas { get { return lstPaginas; } }
        public MasterMasterDetailPage()
        {
            InitializeComponent();
            BindingContext = new MasterMasterDetailViewModel();

        }
    }
}
