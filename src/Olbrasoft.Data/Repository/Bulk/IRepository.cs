using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Olbrasoft.Data.Repository.Bulk  
{
    public interface IRepository<T> where T : class
    {
        void BulkSave(IEnumerable<T> entities, params Expression<Func<T, object>>[] ignorePropertiesWhenUpdating);

        void BulkSave(IEnumerable<T> entities, int batchSize, params Expression<Func<T, object>>[] ignorePropertiesWhenUpdating);
    }
}