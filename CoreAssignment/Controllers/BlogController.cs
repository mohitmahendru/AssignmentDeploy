using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAssignment.Controllers
{
    [Authorize(Roles = UserRole.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly IDataRepository<Blog> _dataRepository;
        public BlogController(IDataRepository<Blog> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        /// <summary>
        /// Get Blogs
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Blog> employees = _dataRepository.GetAll();
            return Ok(employees);
        }

        /// <summary>
        /// Get Blog By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Blog blog = _dataRepository.Get(id);
            if (blog == null)
            {
                return NotFound("The Blog record couldn't be found.");
            }
            return Ok(blog);
        }

        /// <summary>
        /// Create new Blog
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult Post([FromBody] Blog blog)
        {
            if (blog == null)
            {
                return BadRequest("Blog is null.");
            }
            _dataRepository.Add(blog);
            return CreatedAtRoute(
                  "Get",
                  new { Id = blog.BlogID },
                  blog);
        }

        /// <summary>
        /// Update Blog
        /// </summary>
        /// <param name="id"></param>
        /// <param name="blog"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Blog blog)
        {
            if (blog == null)
            {
                return BadRequest("Blog is null.");
            }
            Blog blogToUpdate = _dataRepository.Get(id);
            if (blogToUpdate == null)
            {
                return NotFound("The Blog record couldn't be found.");
            }
            _dataRepository.Update(blogToUpdate, blog);
            return NoContent();
        }


        /// <summary>
        /// Delete Blog
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Blog blog = _dataRepository.Get(id);
            if (blog == null)
            {
                return NotFound("The Blog record couldn't be found.");
            }
            _dataRepository.Delete(blog);
            return NoContent();
        }
    }
}

