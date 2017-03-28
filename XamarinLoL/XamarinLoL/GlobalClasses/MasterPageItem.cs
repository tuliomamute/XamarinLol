using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
namespace XamarinLoL.GlobalClasses
{
    [ImplementPropertyChanged]
    public class MasterPageItem
    {
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Detalhes { get; set; }
        public Type TargetType { get; set; }
    }
}
