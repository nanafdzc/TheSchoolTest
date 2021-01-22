
using Microsoft.AspNetCore.Mvc;
using System;
using TheSchool.Entities;
using TheSchool.Models;

namespace TheSchool.Controllers
{
    public class QuestionController : Controller
    {
        Services.IDataService<Entities.KnowledgeBaseItem> KnowledgeData;
        Services.IQueryService<Entities.KnowledgeBaseItem> KnowledgeQuery;
        readonly AutoMapper.IMapper mapper;

        public QuestionController(Services.IDataService<Entities.KnowledgeBaseItem> knowledgeData, Services.IQueryService<Entities.KnowledgeBaseItem> knowledgeQuery)
        {
            //TODO: Implement mapping as needed.
            KnowledgeData = knowledgeData;
            KnowledgeQuery = knowledgeQuery;

            var config = new AutoMapper.MapperConfiguration(
                cfg => {
                    cfg.CreateMap<Entities.KnowledgeBaseItem, QuestionAndAnswerEditModel>()
                    .ForMember(x => x.Question, opt => opt.MapFrom(z => z.Query));
                    cfg.CreateMap<QuestionAndAnswerEditModel, KnowledgeBaseItem>()
                    .ForMember(x => x.Query, opt => opt.MapFrom(z => z.Question));
                    
                });

            mapper = config.CreateMapper();
        }
        // GET: Question
        public ActionResult Edit(int id)
        {
            //TODO: Implement this method to retrieve and present data for Edition/Updates.
            var item = KnowledgeData.Get(id);
            var model = new QuestionAndAnswerEditModel();
            model = mapper.Map<QuestionAndAnswerEditModel>(item);
            
            return View("Edit", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionAndAnswerEditModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Implement this part of code to persist changes into database.
                var editedModel = mapper.Map<KnowledgeBaseItem>(model);
                KnowledgeData.Edit(editedModel);

            }
            return View(model);
        }
    }
}