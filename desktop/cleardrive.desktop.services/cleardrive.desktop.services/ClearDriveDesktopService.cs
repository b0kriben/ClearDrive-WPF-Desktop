using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
//using desktop.cleardrive.desktop.models;
using Models;
using System.Net;
using Newtonsoft.Json;

namespace desktop.cleardrive.desktop.services
{
    public class ClearDriveDesktopService : IClearDriveDesktopService
    {
        private readonly HttpClient _httpClient;
        public ClearDriveDesktopService(IHttpClientFactory? httpClientFactory)
        {
            if (httpClientFactory is not null)
            {
                _httpClient = httpClientFactory.CreateClient("ClearDriveApi");
            }
        }

        public async Task<List<Position>> SelectAll()
        {
            if (_httpClient is object)
            {
                List<Position>? result = await _httpClient.GetFromJsonAsync<List<Position>>("api/ClearDrive");
                if (result is object)
                    return result;
            }
            return new List<Position>();
        }
    }
}