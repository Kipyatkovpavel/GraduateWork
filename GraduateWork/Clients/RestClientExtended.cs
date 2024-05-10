using NLog;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraduateWork.Helpers.Configuration;

namespace GraduateWork.Clients
{
    public sealed class RestClientExtended
    {
        private readonly RestClient _client;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public RestClientExtended()
        {
            var options =
                new RestClientOptions(Configurator.AppSettingsApi.URL ?? throw new InvalidOperationException());
            _client = new RestClient(options);
            _client.AddDefaultHeader( Configurator.AppSettingsApi.Authorization ,$"Bearer {Configurator.AppSettingsApi.Token}");
        }
        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }

        private void LogRequest(RestRequest request)
        {
            _logger.Debug($"{request.Method}, request to: {request.Resource}");

            var body = request.Parameters
                .FirstOrDefault(p => p.Type == ParameterType.RequestBody)?.Value;

            if (body != null)
            {
                _logger.Debug($"body: {body}");
            }
        }

        private void LogResponse(RestResponse response)
        {
            if (response.ErrorException != null)
            {
                _logger.Error(
                    $"Error retrieving response. Check inner details for more info. \n{response.ErrorException.Message}");
            }
            _logger.Debug($"Request finished with status code: {response.StatusCode}");

            if (!string.IsNullOrEmpty(response.Content))
            {
                _logger.Debug(response.Content);
            }
        }

        public async Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            LogRequest(request);
            var response = await _client.ExecuteAsync(request);
            LogResponse(response);

            return response;
        }

        public async Task<T> ExecuteAsync<T>(RestRequest request)
        {
            LogRequest(request);
            var response = await _client.ExecuteAsync<T>(request);
            LogResponse(response);

            return response.Data ?? throw new InvalidOperationException();
        }
    }
}