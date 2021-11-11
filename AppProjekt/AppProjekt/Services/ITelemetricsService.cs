using AppProjekt.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppProjekt.Services
{
    public interface ITelemetricsService
    {
        Task<RootObject> GetTelemetricsAsync();
    }
}
