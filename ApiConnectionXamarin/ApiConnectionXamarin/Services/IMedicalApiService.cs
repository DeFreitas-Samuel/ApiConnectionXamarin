using ApiConnectionXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiConnectionXamarin.Services
{
    public interface IMedicalApiService
    {
        Task<OutcomeResponse> GetOutcomesAsync();
    }
}
