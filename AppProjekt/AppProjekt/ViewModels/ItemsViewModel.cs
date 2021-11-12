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
        
        public ObservableCollection<Telemetrics> Telemetrics { get; }
        public Command LoadItemsCommand { get; }
        public Command IndexChangedCommand { get; }
        public Command<Telemetrics> ItemTapped { get; }
        public ObservableCollection<string> Filters { get; }
        public ItemsViewModel()
        {
            Title = "Browse";
            Telemetrics = new ObservableCollection<Telemetrics>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            Filters = new ObservableCollection<string>
            {
                "10 Minutter",
                "1 Time",
                "10 Timer"
            };
            
        }

        string _filterSelected;
        public string FilterSelected
        {
            get { return _filterSelected; }
            set { SetProperty(ref _filterSelected, value); }
        }


        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            string uri = "https://api.thingspeak.com/channels/12397/feeds.json?results=600&average=10";
            try
            {
                Telemetrics.Clear();
                #region Load stuff
                var teles = await TeleService.GetTelemetricsAsync(uri);
                DateTime now = DateTime.Now;
                foreach (var item in teles.feeds)
                {
                    if (_filterSelected == null)
                    {
                        double cel = (double.Parse(item.field3) - 32) * 5 / 9;
                        Telemetrics.Add(new Telemetrics { Id = item.entry_id, Temperature = (float)Math.Round(cel, 2), Humidity = float.Parse(item.field4), CreatedAt = item.created_at });
                    }
                    if (_filterSelected == "10 Minutter")
                    {
                        if (item.created_at > now.AddMinutes(-10))
                        {
                            double cel = (double.Parse(item.field3) - 32) * 5 / 9;
                            Telemetrics.Add(new Telemetrics { Id = item.entry_id, Temperature = (float)Math.Round(cel, 2), Humidity = float.Parse(item.field4), CreatedAt = item.created_at });
                        }
                    }
                    if (_filterSelected == "1 Time")
                    {
                        if (item.created_at > now.AddHours(-1))
                        {
                            double cel = (double.Parse(item.field3) - 32) * 5 / 9;
                            Telemetrics.Add(new Telemetrics { Id = item.entry_id, Temperature = (float)Math.Round(cel, 2), Humidity = float.Parse(item.field4), CreatedAt = item.created_at });
                        }
                    }
                    if (_filterSelected == "10 Timer")
                    {
                        if (item.created_at > now.AddHours(-10))
                        {
                            double cel = (double.Parse(item.field3) - 32) * 5 / 9;
                            Telemetrics.Add(new Telemetrics { Id = item.entry_id, Temperature = (float)Math.Round(cel, 2), Humidity = float.Parse(item.field4), CreatedAt = item.created_at });
                        }
                    }
                }
                #endregion
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
            FilterSelected = null;
        }

        async Task RefreshCanExecutesAsync()
        {
            await ExecuteLoadItemsCommand();
        }

    }
}