﻿using Rg.Plugins.Popup.Animations;
using Rg.Plugins.Popup.Enums;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup;
using SII.Models;
using SII.WebServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SII.Views
{
    class DataPage : ContentPage
    {
        private Label lbl_nombre_, lbl_nombre, lbl_carrera, lbl_carrera_, lbl_email_, lbl_email, lbl_nocontrol, lbl_nocontrol_;
        private StackLayout stk;
        private RelativeLayout rl_data;
        private ActivityIndicator ai_data;
        private Student student;
        private WsStudent objWsStu;
        private Image img;
        private Button btnLogin;
        public DataPage()
        {
            objWsStu = new WsStudent();
            createGUIAsync();
        }

        private async Task createGUIAsync()
        {
            btnLogin = new Button
            {
                Text = "Actualizar datos",
                BackgroundColor = Color.FromHex("#80ffe5"),
                BorderColor = Color.FromHex("#b3f0ff"),
                BorderWidth = 3,
                CornerRadius = 40,
                TextColor = Color.Black,
            };
            btnLogin.Clicked += async (sender, e) =>
            {
                var popup = new Popup();

                var scaleAnimation = new ScaleAnimation
                {
                    PositionIn = MoveAnimationOptions.Top,
                    PositionOut = MoveAnimationOptions.Bottom,
                    ScaleIn = 1.2,
                    ScaleOut = 0.8,
                    DurationIn = 400,
                    DurationOut = 800,
                    EasingIn = Easing.BounceIn,
                    EasingOut = Easing.CubicOut,
                    HasBackgroundAnimation = false
                };

                popup.Animation = scaleAnimation;

                await PopupNavigation.PushAsync(popup);
            };
            img = new Image
            {
                WidthRequest = 150,
                HeightRequest = 150,
            };
            ai_data = new ActivityIndicator()
            {
                Color = Color.Aqua,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            lbl_nombre_ = new Label
            {
                Text = "Nombre",
                FontSize = 15,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lbl_carrera_ = new Label
            {
                Text = "Carrera",
                FontSize = 15,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lbl_email_ = new Label
            {
                Text = "Correo",
                FontSize = 15,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lbl_nocontrol_ = new Label
            {
                Text = "Número de Control",
                FontSize = 15,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lbl_nombre = new Label
            {
                Text = "Nombre",
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lbl_carrera = new Label
            {
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lbl_email = new Label
            {
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            lbl_nocontrol = new Label
            {
                FontSize = 15,
                TextColor = Color.FromHex("#003399"),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            stk = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HeightRequest = 500,
                WidthRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                Children =
            {
            img,
             btnLogin,
            lbl_nombre_,
            lbl_nombre,
            lbl_carrera_,
            lbl_carrera,
            lbl_email_,
            lbl_email,
            ai_data,
            lbl_nocontrol_,
            lbl_nocontrol,

            }
            };
            rl_data = new RelativeLayout();
            rl_data.Children.Add(
                stk,
                Constraint.RelativeToParent((parent) => { return 0; }), //valor para posicion de x apartir del layout
                Constraint.RelativeToParent((parent) => { return parent.Height * .05; }), //valor para posicion de Con un cuarto del tamaño total del padre
                Constraint.RelativeToParent((parent) => { return parent.Width; }), //valor para posicion de x apartir del layout
                Constraint.RelativeToParent((parent) => { return parent.Width; }) //valor para posicion de x apartir del layout
                );
            Content = rl_data;
        }

        private async Task BtnLogin_CLickedAsync(object sender, EventArgs e)
        {

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ai_data.IsRunning = true;
            student = await objWsStu.getStudent();
            img.Source = student.image;
            lbl_nombre.Text = student.name + " " + student.father_lastname + " " + student.mother_lastname;
            lbl_carrera.Text = student.career.name;
            lbl_email.Text = student.email;
            lbl_nocontrol.Text = student.nocontrol;
            ai_data.IsRunning = false;
            ai_data.IsVisible = false;
        }
    }
}