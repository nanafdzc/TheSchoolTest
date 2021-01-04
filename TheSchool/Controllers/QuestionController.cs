
using Microsoft.AspNetCore.Mvc;
using System;
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
            KnowledgeData = knowledgeData;
            KnowledgeQuery = knowledgeQuery;


            //TODO: Implement mapping as needed.
            throw new NotImplementedException();
          
        }
        // GET: Question
        public ActionResult Edit(int id)
        {
            //TODO: Implement this method to retrieve and present data for Edition/Updates.
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(QuestionAndAnswerEditModel model)
        {
            if (ModelState.IsValid)
            {
                //TODO: Implement this part of code to persist changes into database.
                throw new NotImplementedException();
            }
            return View(model);
        }
    }
}