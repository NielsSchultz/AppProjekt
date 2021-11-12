﻿using AppProjekt.Models;
using AppProjekt.ViewModels;
using AppProjekt.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppProjekt.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
            //MessagingCenter.Subscribe<ItemsViewModel, Telemetrics>(this, "AgeButtonClicked", (sender, arg) =>
            //{
            //    DisplayAlert("Age", $"{arg.Name} er {arg.Age} år!", "OK");
            //});
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}