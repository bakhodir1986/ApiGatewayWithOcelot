using Catalog_Service_DAL;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Service_BLL.GraphQL
{
    public class QueryGrQL
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Category> GetCategories([Service] CatalogDbContext catalogDbContext) =>
            catalogDbContext.Categories;
    }
}
