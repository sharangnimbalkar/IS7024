using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuickType;

namespace XMLProject.Pages
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
            using(var webClient = new WebClient()) 
            {
                string jsonString = webClient.DownloadString("https://data.cincinnati-oh.gov/api/views/8us8-wi2w/rows.json?accessType=DOWNLOAD");
                var welcome = Welcome.FromJson(jsonString);
                ViewData["Welcome"] = welcome;
            }
            
        }
    }
}
