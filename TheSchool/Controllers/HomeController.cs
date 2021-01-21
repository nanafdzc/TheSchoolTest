using AutoMapper;
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

            var config = new AutoMapper.MapperConfiguration(
                cfg => {
                    cfg.CreateMap<QuestionAndAnswerModel, Entities.KnowledgeBaseItem>()
                .ForMember(x => x.Query, opt => opt.MapFrom(z => z.Question))
                .ForMember(x => x.LastUpdateOn, opt => opt.MapFrom(z => DateTime.Now));
                    cfg.CreateMap<TagItem, TagModel>();
                 });

            mapper = config.CreateMapper();
        }

        public ActionResult Index()
        {
            //TODO: Return a view "Index" with all the required information for the nested views.
            //You need to call TagHelper.Process as shown below in order to populate the object "HomeViewModel".
            var model = new HomeViewModel();
            model.QA = new QuestionAndAnswerModel();
          
            var tagList = TagHelper.Process(KnowledgeBaseQuery, out int tagMaxCount);
            model.Tags = new TagCloudModel() { Tags = mapper.Map<List<TagModel>>(tagList), MaxCount = tagMaxCount };

            return View("Index", model);
        }
        public ActionResult Entry()
        {
            //TODO: Return partial view "Entry";
            return PartialView("Entry");
        }
        [HttpGet]
        public ActionResult TagCloud()
        {
            //TODO: Return partial view "TagCloud" with an instance of TagCloudviewModel.
            //You need to call TagHelper.Process as shown below.
            /*var tagCloud = new TagCloudModel();

            var tagList = TagHelper.Process(KnowledgeBaseQuery, out int tagMaxCount);
            tagCloud.Tags = mapper.Map<List<TagModel>>(tagList);
            tagCloud.MaxCount = tagMaxCount;*/
           
            return PartialView("TagCloud");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(QuestionAndAnswerModel model)
        {
            //TODO: Return partial view "Index" to reload the page.
            //If model is valid then persists the new entry on DB. Make sure  data changes are committed.
            if (ViewData.ModelState.IsValid)
            {
                KnowledgeBaseItem baseItem = mapper.Map<KnowledgeBaseItem>(model);
                KnowledgeBaseData.Add(baseItem);
                KnowledgeBaseData.CommitChanges();

                return RedirectToRoute(new { action = "Index", controller = "Home", area = "" });
            }

            return Index();
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
