using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Objects;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace DBFilteringService
{
    class FilteringOperations
    {
        public static Expression<Func<Books, bool>> ContainsInDescription(
                                                params string[] keywords)
        {
            var predicate = PredicateBuilder.False<Books>();
            
            return predicate;
        }

    }
}
