using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TheSchool.Data.Helpers;
using TheSchool.Entities;
using TheSchool.Models;

namespace TheSchool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        Services.IDataService<KnowledgeBaseItem> KnowledgeBaseData;
        Services.IQueryService<KnowledgeBaseItem> KnowledgeBaseQuery;
        private readonly AutoMapper.IMapper mapper;
        public HomeController(ILogger<HomeController> logger, Services.IDataService<KnowledgeBaseItem> dataService, Services.IQueryService<KnowledgeBaseItem> queryService)
        {
            _logger = logger;
            KnowledgeBaseData = dataService;
            KnowledgeBaseQuery = queryService;

            //TODO: Implement mapping from QuestionAndAnswerModel to Entities.KnowledgeBaseItem.
            //LastUpdateOn field is set with DateTime.Now and Tags field with lowercase.
            //Also create a map from TagItem to TagModel.
            //Use "mapper" attribute which is already defined. More information: https://docs.automapper.org/en/latest/Getting-started.html.

            throw new NotImplementedException();

        }

        public ActionResult Index()
        {
            //TODO: Return a view "Index" with all the required information for the nested views.
            //You need to call TagHelper.Process as shown below in order to populate the object "HomeViewModel".
            
            throw new NotImplementedException();
        }
        public ActionResult Entry()
        {
            //TODO: Return partival view "Entry";
            throw new NotImplementedException();
        }
        [HttpGet]
        public ActionResult TagCloud()
        {
            //TODO: Return partival view "TagCloud" with an instance of TagCloudviewModel.
            //You need to call TagHelper.Process as shown below.
            
            throw new NotImplementedException();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(QuestionAndAnswerModel model)
        {
            //TODO: Return partial view "Index" to reload the page.
            //If model is valid then persists the new entry on DB. Make sure  data changes are committed.
            
            throw new NotImplementedException();
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
    }
}
