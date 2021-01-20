﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheSchool.Entities;

namespace TheSchool.Services
{
    public interface IDataService<T>
    {
        void Add(T entity);
        void Edit(T entity);
        void Delete(int id);

        void CommitChanges();
        KnowledgeBaseItem Get(int id);
    }
}
