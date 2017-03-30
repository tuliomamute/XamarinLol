﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLoL.ViewModel;

namespace XamarinLoL.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SummonerProfilePage : ContentPage
    {
        public SummonerProfilePage()
        {
            try
            {
                InitializeComponent();
                BindingContext = new SummonerProfileViewModel();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
