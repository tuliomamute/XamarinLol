using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinLoL.GlobalClasses;
using XamarinLoL.Views;

namespace XamarinLoL.ViewModel
{
    [ImplementPropertyChanged]
    public class MasterMasterDetailViewModel
    {
        public List<MasterPageItem> masterPageItems = null;
        public MasterMasterDetailViewModel()
        {
            masterPageItems = new List<MasterPageItem>();

            masterPageItems.Add(new MasterPageItem
            {
                Titulo = "Perfil do Invocador",
                Imagem = "contacts.png",
                Detalhes = "Detalhes do Perfil do Invocador",
                TargetType = typeof(SummonerProfilePage)
            });
            
        }
    }
}
