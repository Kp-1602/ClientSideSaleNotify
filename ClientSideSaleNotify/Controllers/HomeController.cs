using ClientSideSaleNotify.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TimmerTrigger;
using Microsoft.Azure.Functions.Worker;
using System.Threading;
using Microsoft.AspNetCore.Authorization;

namespace ClientSideSaleNotify.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
     
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
      // [Authorize(Roles ="Gold")]
      //  [HttpPost]
        public string GetNotified(string strProduct)
        {

            string strResult = "";

            //string azureBaseUrl = "http://localhost:7071/api/Function1";


            ////   //Azure VS Function call

            ////strProduct = "'" + strProduct + "%'"
            //string urlQueryStringParams = "?PName=" + strProduct;



            //// create hhtp client 
            //HttpClient client = new();

            ////send request and await response from Azure Function 
            //HttpResponseMessage response = await client.GetAsync($"{azureBaseUrl}{urlQueryStringParams}");

            ////receive content
            //HttpContent content = response.Content;

            //// read content 
            //strResult = await content.ReadAsStringAsync();

            //AspNetUser user = new AspNetUser();
            //strResult = user.Email.ToString();
            //strResult = User.Identity.Name.ToString();
   
            
            MyInfo info = new();

            MyScheduleStatus mySchedule = new();
            strResult =  Function1.Run(info, strProduct).ToString();

            return strResult;


            //ViewBag.Id = strResult;


        }
    
    

    }
}
