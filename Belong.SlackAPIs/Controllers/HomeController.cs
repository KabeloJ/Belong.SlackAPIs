using Belong.SlackAPIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Belong.SlackAPIs.Services;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Belong.SlackAPIs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly APIServices apis;
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
            apis = new APIServices(_config);
        }

        public IActionResult Index()
        {
            var data = apis.GetChannels();
            return View(data);
        }

        public IActionResult History(string channelId, string channelName)
        {
            var data = apis.GetChannelMessages(channelId);
            if (data != null)
            {
                ViewData["Channel"] = channelName;
                ViewData["ChannelId"] = channelId;
                return View(data);
            }
            return BadRequest();
        }
        public FileResult SaveToCSV(string channelId)
        {
            var data = apis.GetChannelMessages(channelId);
            if (data != null)
            {
                var sb = new StringBuilder();
                sb.AppendLine("Username,Text");
                if (data.messages != null)
                {
                    foreach (var c in data.messages)
                    {
                        sb.AppendLine($"{c.username},{c.text.Replace(',', ' ')}");
                    }
                }
                var bytes = Encoding.ASCII.GetBytes(sb.ToString());
                string fileName = $"{channelId}_{DateTime.Now.ToString("yyyy-MM-dd").Replace("-","")}.csv";
                string contentType = "application/csv";
                return File(bytes, contentType, fileName);
            }
            return null;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
