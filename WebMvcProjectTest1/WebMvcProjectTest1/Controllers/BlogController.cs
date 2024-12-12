using Business.Services;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace WebMvcProjectTest1.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService service)
        {
            _blogService = service;
        }



        public IActionResult Index()
        {
            var blog = _blogService.GetAllBlog();
            return View(blog);
        }

        public IActionResult Details(int id)
        {
            var blog = _blogService.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        
        public IActionResult Create()
        {
          return View();
        }

        [HttpPost]
        public IActionResult Create (Blog blog)
        {
            _blogService.AddBlog(blog);
            return RedirectToAction("Index");
        }

        public IActionResult Edit (int id)
        {
            var blog = _blogService.GetBlogById(id);
            if(blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        [HttpPost]
        public IActionResult Edit (Blog blog)
        {
            _blogService.UpdateBlog(blog);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var blog = _blogService.GetBlogById(id);
            if( blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _blogService.DeleteBlog(id);
            return RedirectToAction("Index");
        }

    }
}
