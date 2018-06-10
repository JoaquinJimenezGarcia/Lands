namespace Lands.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using Models;
    using Newtonsoft.Json;
    using Plugin.Connectivity;

    public class ApiService
    {
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Please, turn on your internet connection."
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable("goole.com");

            if (!isReachable) 
            {
                return new Response 
                {
                    IsSuccess = false,
                    Message = "The network is no reachable."
                }
            }

            return new Response
            {
                IsSuccess = true,
                Message = "Connected!"
            }
        }
    }
}
