using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Microsoft.AspNetCore.Cors;
using MyApi.Filters;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ValidateModel]
    public class SurveysController : Controller
    {
        private readonly ApplicationContext _context;

        public SurveysController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Create(List<Models.Survey> surveys)
        {
            if (ModelState.IsValid)
            {
                foreach(var survey in surveys)
                {
                    if (_context.Surveys.Any(p => p.user_chat_id == survey.user_chat_id))
                    {
                        var updated = _context.Surveys.First(p => p.user_chat_id == survey.user_chat_id);
                        updated.survey = survey.survey;
                        updated.question = survey.question;
                        updated.answer = survey.answer;
                    }
                    else
                    {
                        _context.Surveys.Add(survey);
                    }
                }
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        //public ActionResult Create(int user_chat_id, string survey, string question, string answer, string? comment)
        //{
        //    try
        //    {
        //        if (_context.Surveys.Any(p => p.user_chat_id == user_chat_id))
        //        {
        //            var updated = _context.Surveys.First(p => p.user_chat_id == user_chat_id);
        //            updated.survey = survey;
        //            updated.question = question;
        //            updated.answer = answer;
        //            if(comment!=null)
        //                updated.comment = comment;
        //        }
        //        else
        //        {
        //            _context.Surveys.Add(new Models.Survey(user_chat_id, survey, question, answer, comment));
        //        }
        //        _context.SaveChanges();
        //        return Ok();
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
