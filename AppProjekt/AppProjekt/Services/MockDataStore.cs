using AppProjekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppProjekt.Services
{
    public class MockDataStore : IDataStore<Telemetrics>
    {
        readonly List<Telemetrics> items;

        public MockDataStore()
        {
            items = new List<Telemetrics>()
            {
                new Telemetrics { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Telemetrics { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Telemetrics { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Telemetrics { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Telemetrics { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Telemetrics { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
        }

        public async Task<bool> AddItemAsync(Telemetrics item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Telemetrics item)
        {
            var oldItem = items.Where((Telemetrics arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Telemetrics arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Telemetrics> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Telemetrics>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}