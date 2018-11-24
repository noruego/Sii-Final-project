using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SII.Views
{
    class CuentaPage : ContentPage
    {
            public CuentaPage()
            {
            Navigation.PopModalAsync();
            }

           


            protected override async void OnAppearing()
            {
                base.OnAppearing();
                
            }
        }
    
}
