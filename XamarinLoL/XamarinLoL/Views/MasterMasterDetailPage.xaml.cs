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

            List<MasterPageItem> masterPageItems = null;

            masterPageItems = new List<MasterPageItem>();

            masterPageItems.Add(new MasterPageItem
            {
                Titulo = "Perfil do Invocador",
                Imagem = "icon.png",
                Detalhes = "Detalhes do Perfil do Invocador",
                TargetType = typeof(SummonerProfilePage)
            });

            lstPaginas.ItemsSource = masterPageItems;
        }
    }
}
