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
using CountryData;
using MunicipalData;

namespace FinalXmL.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            SearchCompleted = false;

        }
        [BindProperty]
        public string Search { get; set; }
        public bool SearchCompleted { get; set; }
        List <Geonamedata> Geonamelist= new List<Geonamedata>();
        CountryCode Countrycollection = new CountryCode();

        public void OnPost()
        {
            using (var webClient = new WebClient())

            {


                String jsonString = GetData("https://pkgstore.datahub.io/core/country-list/data_json/data/8c458f2d15d9f2119654b29ede6e45b8/data_json.json");
                CountryCode[] country = CountryCode.FromJson(jsonString);

                String jsonString1 = webClient.DownloadString("https://pkgstore.datahub.io/core/world-cities/world-cities_json/data/5b3dd46ad10990bca47b04b4739a02ba/world-cities_json.json");
                Geonamedata[] geodata = Geonamedata.FromJson(jsonString1);
                foreach (Geonamedata geonamedata in geodata)
                {
                    if (geonamedata.Country != null)
                    {
                        if (geonamedata.Country.ToLower() == Search.ToLower())
                        {
                            Geonamelist.Add(geonamedata);
                        }
                    }
                }
                foreach (CountryCode cst in country)
                {
                    if (cst.Name.ToLower() == Search.ToLower())
                    {
                        Countrycollection = cst;
                    }
                }
                ViewData["RequiredCountry"] = Geonamelist;
                ViewData["Country"] = Countrycollection;
                SearchCompleted = true;




            }
        }
            public string GetData(string endpoint)
            {
                string downloadedJson;
                using (WebClient webClient = new WebClient())
                {
                    downloadedJson = webClient.DownloadString(endpoint); ;
                }
                return downloadedJson;
            }

        }
    }
