using API.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly ApplicationContext _context;

        public UsersController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Create(List<Models.UserSource> sources)
        {
            if (ModelState.IsValid)
            {
                foreach (var source in sources)
                {
                    _context.Users.Add(new Models.User(source.chat_id, source.last_activity));
                    _context.Sources.Add(new Models.Source(source.user_chat_id, source.source_id, source.source));
                }
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public ActionResult Edit(List<Models.User> users)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var user in users)
                    {
                        if (!_context.Users.Any(p => p.chat_id == user.chat_id))
                        {
                            throw new Exception();
                        }
                        var updated = _context.Users.First(p => p.chat_id == user.chat_id);
                        updated.brand_catalogue = user.brand_catalogue;
                        updated.sku_catalogue = user.sku_catalogue;
                        updated.status = user.status;
                        updated.last_activity = user.last_activity;
                        updated.updated_date = DateTime.Now;
                    }
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
