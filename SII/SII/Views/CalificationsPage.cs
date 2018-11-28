using SII.Models;
using SII.WebServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SII.Views
{ 
    class CalificationsPage : ContentPage
    {
        private ListView lv_kardex;
        private SearchBar sr_kardex;
        private ActivityIndicator ai_kardex;
        private Label lb_nmateria, lb_calificacion1, lb_calificacion2, lb_calificacion3, lb_calificacion4, lb_promedio;
        private BoxView bv_div;
        private List<Subjects> list_kardex;
        private WsSubjects objWsSubject;
        private StackLayout st_inst;
        private ScrollView scv_hor;

        public CalificationsPage()
        {
            objWsSubject = new WsSubjects();
            createGUI();
            scv_hor = new ScrollView();
            scv_hor.Orientation = ScrollOrientation.Horizontal;
        }

        private void createGUI()
        {
            NavigationPage.SetHasNavigationBar(this, false); //Quitar barra de navegacion 
            ai_kardex= new ActivityIndicator()
            {
                Color = Color.Green,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            sr_kardex = new SearchBar()
            {
                HorizontalTextAlignment = TextAlignment.Start,
                Placeholder = "Buscar registro",
                FontSize = 16,
                TextColor = Color.Black
            };
            sr_kardex.TextChanged += (sender, e) => buscarInstitucion(sr_kardex.Text);

            lv_kardex = new ListView();
            lv_kardex.HasUnevenRows = true;
            lv_kardex.ItemTemplate = new DataTemplate(typeof(ResultCellCalifications));

            bv_div = new BoxView()
            {
                Color = Color.Green,
                HeightRequest = 2,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 300
            };
            lb_nmateria = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Materia",
                FontSize = 12,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
           
            lb_calificacion1 = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Calificacion 1",
                TextColor = Color.Gray,
                FontSize = 12,
                FontFamily = "Roboto"
            };
            lb_calificacion2 = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Calificacion 2",
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Gray,
                FontSize = 12,
                FontFamily = "Roboto"
            };
            lb_calificacion3 = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Calificacion 3",
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Gray,
                FontSize = 12,
                FontFamily = "Roboto"
            };
            lb_calificacion4 = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Calificacion 4",
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Gray,
                FontSize = 12,
                FontFamily = "Roboto"
            };
            lb_promedio = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Center,
                Text = "Promedio",
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Gray,
                FontSize = 12,
                FontFamily = "Roboto"
            };

            st_inst = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(20),
                Children =
                {
                    sr_kardex,
                    ai_kardex,
                    new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        Padding = new Thickness(20),
                        Children ={ lb_nmateria,lb_calificacion1,lb_calificacion2,lb_calificacion3,lb_calificacion4,lb_promedio}
                    },
                    lv_kardex,
                    bv_div,
                    
                }
            };
            
            Content = new ScrollView
            {
                Orientation = ScrollOrientation.Horizontal,
                Content = st_inst
            };
        }

        private void buscarInstitucion(string institucion)
        {
            if (!string.IsNullOrWhiteSpace(institucion))
            {
                lv_kardex.ItemsSource = list_kardex.Where(x => x.group.matter.name.ToLower().Contains(institucion.ToLower()));
            }
            else
            {
                lv_kardex.ItemsSource = list_kardex;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lv_kardex.IsVisible = false;
            ai_kardex.IsRunning = true;
            list_kardex = await objWsSubject.getSubjects();
            lv_kardex.ItemsSource = list_kardex;
            ai_kardex.IsRunning = false;
            ai_kardex.IsVisible = false;
            lv_kardex.IsVisible = true;
             
        }
        protected override bool OnBackButtonPressed()
        {
            DisplayAlert("UPS!", "selecciona una institución", "Aceptar");
            return true;
        }
        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }

    }
    class ResultCellCalifications : ViewCell
    {
        public ResultCellCalifications()
        {
            int width = 150,heigh =35;

            var lblmateria = new Label()
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest =heigh,
                WidthRequest =width,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblmateria.SetBinding(Label.TextProperty, "group.matter.name");
            var lblcalificacion1 = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 100,
                TextColor = Color.Gray,
                FontFamily = "Roboto"
            };
            lblcalificacion1.SetBinding(Label.TextProperty, "calificacion1");
            var lblcalificacion2 = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 80,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblcalificacion2.SetBinding(Label.TextProperty, "calificacion2");
            var lblcalificacion3 = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 80,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblcalificacion3.SetBinding(Label.TextProperty, "calificacion3");
            var lblcalificacion4 = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
                WidthRequest = 80,
                TextColor = Color.Gray,
                FontFamily = "Roboto",
                FontAttributes = FontAttributes.Bold
            };
            lblcalificacion4.SetBinding(Label.TextProperty, "calificacion4");

            var lblPromedio = new Label
            {
                HorizontalTextAlignment = TextAlignment.Start,
                FontSize = 14,
                HeightRequest = heigh,
               WidthRequest =80,
                TextColor = Color.Gray,
                FontFamily = "Roboto",

            };
            lblPromedio.SetBinding(Label.TextProperty, "promedio");

            var stackList = new StackLayout
            {
                Padding = new Thickness(10),
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    lblmateria,
                    lblcalificacion1,
                    lblcalificacion2,
                    lblcalificacion3,
                    lblcalificacion4,
                    lblPromedio
                }
            };
            View = stackList;
        }
       
    }
}
