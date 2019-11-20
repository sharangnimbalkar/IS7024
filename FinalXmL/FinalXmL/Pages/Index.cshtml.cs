using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using QuickTypeCList;
using QuickTypeCityList;

namespace FinalXmL.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            String list;
            list = getData("https://pkgstore.datahub.io/core/country-list/data_json/data/8c458f2d15d9f2119654b29ede6e45b8/data_json.json");
            //var countryLists = QuickTypeCList.CountryList.FromJson(list);
            List<CountryList> countryLists = CountryList.FromJson(list);

            list = getData("https://pkgstore.datahub.io/core/world-cities/world-cities_json/data/5b3dd46ad10990bca47b04b4739a02ba/world-cities_json.json");
            //var cityLists = QuickTypeCityList.CityList.FromJson(list);
            IEnumerable<CityList> cityLists = CityList.FromJson(list);
            ViewData["CountryList"] = countryLists;
            ViewData["CityList"] = cityLists;
        }

        public string getData(string end_Point_Url)
        {
            string dataFromEndpoint;
            //Creating Disposable object webClient which release object Resources after using block is executed
            using (WebClient webClient= new WebClient())  
            {
            //Download data from json url fed into string dataFromEndpoint.
                dataFromEndpoint = webClient.DownloadString(end_Point_Url);     
            }
            //return downloaded json data to the calling method
            return dataFromEndpoint;    
        }
    }
}