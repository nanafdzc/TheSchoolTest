﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TheSchool.Entities;

namespace TheSchool.Data
{
    public class KnowledgeBaseData : Services.IDataService<KnowledgeBaseItem>, Services.IQueryService<KnowledgeBaseItem>
    {
        WisperoDbContext _context;

        #region Constructors
        public KnowledgeBaseData(WisperoDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods
        public void Add(KnowledgeBaseItem entity)
        {
            //TODO: Implement Adding mechanism for KnowledgeBaseItems.
            throw new NotImplementedException();
        }

        public void CommitChanges()
        {
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            //TODO: Implement Deleting mechanism for KnowledgeBaseItems.
            throw new NotImplementedException();
        }

        public void Edit(KnowledgeBaseItem entity)
        {
            //TODO: Implement Editing mechanism for KnowledgeBaseItems.
            //This need to handle concurrency. As long as rowversions are the same then persist changes.
            throw new NotImplementedException();
        }

        public KnowledgeBaseItem Get(int id)
        {
            //TODO: Implement Getting by Id mechanism for KnowledgeBaseItems.
            throw new NotImplementedException();
            
        }

        public List<KnowledgeBaseItem> GetAll()
        {
            //TODO: Implement Getting ALL mechanism for KnowledgeBaseItems.
            throw new NotImplementedException();
        
        }

        public List<KnowledgeBaseItem> GetByFilter(Expression<Func<KnowledgeBaseItem, bool>> expression)
        {
            //TODO: Implement Getting by Filter mechanism for KnowledgeBaseItems.
            throw new NotImplementedException();
        }

        #endregion
    }
}
