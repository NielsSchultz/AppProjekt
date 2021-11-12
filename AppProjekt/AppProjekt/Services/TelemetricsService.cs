using AppProjekt.Constants;
using AppProjekt.Models;
using AppProjekt.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyIoC;

namespace AppProjekt.Services
{
    internal class TelemetricsService : ITelemetricsService  
    {
        private readonly IGenericRepository _genericRepository;
        public TelemetricsService()
        {
            _genericRepository = TinyIoCContainer.Current.Resolve<IGenericRepository>();
        }

        public async Task<RootObject> GetTelemetricsAsync(string uri)
        {
            //UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            //{
            //    Path = ApiConstants.TelemetricsEndpoint
            //};
            //Thread.Sleep(3000); // Simulerer 3 sekunders forsinkelte
            return await _genericRepository.GetAsync<RootObject>(uri);
        }

    }
}
