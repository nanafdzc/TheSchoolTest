using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSchool.Entities;


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
            List<TagItem> itemList = new List<TagItem>();

            //list with all the tags separated by comma

            foreach (var tags in items)
            {
                itemList.AddRange(
                    tags.Tags.Split(",").Select(t => new TagItem() { Tag = t.Trim() })
                );
            }

            //all tags grouped by their count
            var tagCount =
                from t in itemList
                group t by t.Tag into g
                select new TagItem() { Tag = g.Key, Count = g.Count() };

            var tagsCount = tagCount.Select(t => t.Count);
            if(tagsCount.Count() > 0)
            {
                tagMaxCount = tagsCount.Max();
            }
            else
            {
                tagMaxCount = tagsCount.Count();
            }
            return tagCount.ToList();
        }
    }

}
