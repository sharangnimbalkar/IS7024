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
using QuickTypeCountry;
using QuickTypeGeo;

namespace FinalXmL.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            //hard coding values used in a function is a bad practice especially when you have to change every instance in functions rather than changing one variable name
            //also if we wanted to manipulate and edit parts of the endURL creating this variable would make that process easier
            String endCountryURL = "https://pkgstore.datahub.io/core/country-list/data_json/data/8c458f2d15d9f2119654b29ede6e45b8/data_json.json";
            String jsonCountryString = RetrieveData(endCountryURL);
            Country[] countries = QuickTypeCountry.Country.FromJson(jsonCountryString);
            ViewData["Countries"] = countries;


            String endGeoURL = "https://pkgstore.datahub.io/core/world-cities/world-cities_json/data/5b3dd46ad10990bca47b04b4739a02ba/world-cities_json.json";
            String jsonGeoString = RetrieveData(endGeoURL);
            Geonamedata[] geoData = QuickTypeGeo.Geonamedata.FromJson(jsonGeoString);
            ViewData["Geoname"] = geoData;
        }

        public string RetrieveData(string endPoint)
        {
            string downloadedData = "";
            using (WebClient webClient = new WebClient())
            {
                downloadedData = webClient.DownloadString(endPoint);
                //using camelcase as defined in https://www.dofactory.com/reference/csharp-coding-standards
            }
            return downloadedData;
        }
    }
}