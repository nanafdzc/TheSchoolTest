using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSchool.Data.Helpers
{
    public static class TagHelper
    {
        public static List<Entities.TagItem> Process(Services.IQueryService<Entities.KnowledgeBaseItem> knowledgeService, out int tagMaxCount)
        {
            var sourceItems = knowledgeService.GetAll();
            return Process(sourceItems, out tagMaxCount);
        }

        public static List<Entities.TagItem> Process(List<Entities.KnowledgeBaseItem> items, out int tagMaxCount)
        {
            //TODO: Based on the list of items you need to rank tags dynamically. Also, return the max value that will be used for Tag Cloud control.
            List<Entities.TagItem> itemList;

            foreach (var tags in items)
            {
                
            }
            
            throw new NotImplementedException();
        }
    }

}
