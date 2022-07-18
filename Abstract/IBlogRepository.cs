using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Abstract
{
    public interface IBlogRepository
    {
        Entity.Blog GetById(int blogId);
        IQueryable<Entity.Blog> GetAll();

        void AddBlog (Entity.Blog entity);
        void UpdateBlog (Entity.Blog entity);
        void DeleteBlog (int blogId);


    }
}
