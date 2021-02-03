using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAssignment
{
    public class BlogManager : IDataRepository<Blog>
    {
        readonly ApplicationContext _blogContext;
        public BlogManager(ApplicationContext context)
        {
            _blogContext = context;
        }

        /// <summary>
        /// Get All Blog
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Blog> GetAll()
        {
            return _blogContext.Blogs.ToList();
        }

        /// <summary>
        /// Get Blog by BlogId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Blog Get(long id)
        {
            return _blogContext.Blogs
                  .FirstOrDefault(e => e.BlogID == id);
        }

        /// <summary>
        /// Create New Blog
        /// </summary>
        /// <param name="entity"></param>
        public void Add(Blog entity)
        {
            _blogContext.Blogs.Add(entity);
            _blogContext.SaveChanges();
        }

        /// <summary>
        /// Update Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <param name="entity"></param>
        public void Update(Blog blog, Blog entity)
        {
            blog.Title = entity.Title;
            blog.Content = entity.Content;
            blog.Updated = DateTime.Now;
            _blogContext.SaveChanges();
        }

        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="blog"></param>
        public void Delete(Blog blog)
        {
            _blogContext.Blogs.Remove(blog);
            _blogContext.SaveChanges();
        }
    }
}

