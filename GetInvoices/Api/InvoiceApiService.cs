using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BabelSol.Persistence.Core;
using BabelSol.Persistence.Entities;
using GetInvoices.Api.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GetInvoices.Api
{
    public class InvoiceApiService : IInvoiceApiService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<InvoiceApiService> logger;
        private string baseUrl;

        public InvoiceApiService(IHttpClientFactory httpClientFactory,
                               IConfiguration configuration,
                               ILogger<InvoiceApiService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = configuration.GetValue<string>("baseUrl");
          
        }
        public async Task<DataResult> ProccessInvoices(List<Invoice> invoices)
        {
            DataResult result = new DataResult();
            
            try
            {
                using (var httpClient = this.httpClientFactory.CreateClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(invoices), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync($"{this.baseUrl}/Invoice/ProccessInvoice", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            result = JsonConvert.DeserializeObject<DataResult>(apiResponse);
                        }
                        else
                        {

                            result.Message = "Error proccesing invoices";
                            result.Success = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error proccesing invoices";
                this.logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }
    }
}
