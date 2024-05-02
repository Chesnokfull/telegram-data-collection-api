using API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Filters;
using System.Net;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ValidateModel]
    public class SourcesController : Controller
    {
        private readonly ApplicationContext _context;
        public SourcesController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Create(List<Models.Source> sources)
        {
            if(ModelState.IsValid)
            {
                foreach(var item in sources)
                    _context.Sources.Add(item);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
