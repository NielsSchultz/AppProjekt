using AppProjekt.Models;
using AppProjekt.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppProjekt.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Telemetrics _selectedItem;

        public ObservableCollection<Telemetrics> Telemetrics { get; }
        public Command LoadItemsCommand { get; }
        public Command<Telemetrics> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Telemetrics = new ObservableCollection<Telemetrics>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());


        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Telemetrics.Clear();
                var teles = await TeleService.GetTelemetricsAsync();
                foreach (var item in teles.feeds)
                {
                    Telemetrics.Add(new Models.Telemetrics { Id= item.entry_id, Temperature = float.Parse(item.field1), CreatedAt = item.created_at });
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }


        private string createdAt;

        public string CreatedAt 
        { 
            get => createdAt; 
            set => SetProperty(ref createdAt, value); 
        }

        

        private string temperature;

        public string Temperature 
        { 
            get => temperature; 
            set => SetProperty(ref temperature, value); 
        }
    }
}