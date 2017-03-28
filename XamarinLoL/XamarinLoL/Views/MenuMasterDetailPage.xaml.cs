using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLoL.GlobalClasses;

namespace XamarinLoL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuMasterDetailPage : MasterDetailPage
    {
        MasterMasterDetailPage master;
        public MenuMasterDetailPage()
        {
            InitializeComponent();
            masterPage.ListPaginas.ItemSelected += OnItemSelected;

        }
        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.ListPaginas.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
