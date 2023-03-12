using DeveloperChallenge.Models.Dtos.OutputDtos;
using DeveloperChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace DeveloperChallenge.Services.Services
{
    public class QuotableService: IQuotableService
    {
        HttpClient httpClient = new HttpClient();
        public async Task<QuotableOutputDto> GetRandomQuote()
        {
            QuotableOutputDto quotableOutput = new QuotableOutputDto();
            try { 
                    HttpResponseMessage response = await httpClient.GetAsync("https://api.quotable.io/random");
                    if (response.IsSuccessStatusCode)
                    {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    quotableOutput = JsonConvert.DeserializeObject< QuotableOutputDto> (apiResponse, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                }
                return quotableOutput;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<QuotableActualOutputDto>> GetQuotesByAuthor()
        {

            List<QuotableOutputDto> quotableOutputDtos= new List<QuotableOutputDto>();
            var filterData = new List<QuotableActualOutputDto>();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://quotable.io/quotes?author=albert-einstein&limit=30");
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var userObj = JObject.Parse(apiResponse);
                    var userGuid = Convert.ToString(userObj["results"]);
                    quotableOutputDtos = JsonConvert.DeserializeObject<List<QuotableOutputDto>>(userGuid, new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                    var shortContent = quotableOutputDtos.GroupBy(a => a.content.Split(' ').Length);
                    var shortList = shortContent.Where(x => x.Key <= 10).SelectMany(y => y).ToList();
                    var mediumList = shortContent.Where(x => x.Key > 10 && x.Key <= 20).SelectMany(y => y).ToList();
                    var longList = shortContent.Where(x => x.Key > 20).SelectMany(y => y).ToList();

                    filterData = new List<QuotableActualOutputDto>
                    {
                        new QuotableActualOutputDto
                        {
                            category = "Short",
                            quotables = shortList
                        },
                        new QuotableActualOutputDto
                        {
                            category = "Medium",
                            quotables = mediumList
                        },
                        new QuotableActualOutputDto
                        {
                            category = "Long",
                            quotables = longList
                        }

                    };
                }
                return filterData;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
