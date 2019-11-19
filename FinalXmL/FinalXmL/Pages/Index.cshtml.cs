﻿using System;
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
using QuickType;
using QuickType1;

namespace FinalXmL.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            using (var webClient = new WebClient())

            {


                String jsonString = webClient.DownloadString("https://pkgstore.datahub.io/core/country-list/data_json/data/8c458f2d15d9f2119654b29ede6e45b8/data_json.json");

                var welcome = QuickType.Welcome.FromJson(jsonString);
                ViewData["Welcome"] = welcome;

                String jsonString1 = webClient.DownloadString("https://pkgstore.datahub.io/core/world-cities/world-cities_json/data/5b3dd46ad10990bca47b04b4739a02ba/world-cities_json.json");


                var geodata = Geonamedata.FromJson(jsonString1);
                ViewData["Geoname"] = geodata;


            }

        }
    }
}