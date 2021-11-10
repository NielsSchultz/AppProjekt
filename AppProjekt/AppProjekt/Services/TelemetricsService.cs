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
    internal class TelemetricsService : ITelemtricsService  
    {
        private readonly IGenericRepository _genericRepository;
        public TelemetricsService()
        {
            _genericRepository = TinyIoCContainer.Current.Resolve<IGenericRepository>();
        }

        public async Task<IEnumerable<Telemetrics>> GetTelemetricsAsync()
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.ItemsEndpoint
            };
            //Thread.Sleep(3000); // Simulerer 3 sekunders forsinkelte
            return await _genericRepository.GetAsync<IEnumerable<Telemetrics>>(builder.ToString());
        }

    }
}
