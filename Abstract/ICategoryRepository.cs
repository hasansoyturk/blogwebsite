using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Abstract
{
    public interface ICategoryRepository
    {
        Entity.Category GetById(int categoryId);
        IQueryable<Entity.Category> GetAll();

        void AddCategory(Entity.Category entity);
        void UpdateCategory(Entity.Category entity);
        void DeleteCategory(int categoryId);


    }
}
