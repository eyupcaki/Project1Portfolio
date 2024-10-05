using Project1Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class DefaultController : Controller
    {
        MyPortfolioDbEntities context=new MyPortfolioDbEntities();
        // GET: Default
        public ActionResult Index()
        {
            List<SelectListItem> values = (from x in context.Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value=x.CategoryId.ToString(),
                                           }
                                           ).ToList();
            ViewBag.v=values;
            return View();
        }

        [HttpPost]
        public ActionResult  Index(Message message)
        {
            message.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.IsRead = false;
            context.Message.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        
        public PartialViewResult PartialNawBar()
        {
            return PartialView();
        }
        
        public PartialViewResult PartialHeader()
        {
            ViewBag.title=context.About.Select(x=>x.Title).FirstOrDefault();
            ViewBag.detail=context.About.Select(x=>x.Detail).FirstOrDefault();
            ViewBag.imageurl=context.About.Select(x=>x.ImageUrl).FirstOrDefault();

            ViewBag.adress = context.Profile.Select(x => x.Address).FirstOrDefault();
            ViewBag.email = context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone = context.Profile.Select(x => x.PhoneNumber).FirstOrDefault();
            ViewBag.github = context.Profile.Select(x => x.Github).FirstOrDefault();

            return PartialView();
        } 
        
        public PartialViewResult PartialAbout()
        {
            ViewBag.title=context.Profile.Select(x => x.Title).FirstOrDefault();
            ViewBag.description=context.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.email=context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.phone=context.Profile.Select(x => x.PhoneNumber).FirstOrDefault();
            ViewBag.imageurl=context.Profile.Select(x => x.ImageUrl).FirstOrDefault();

            return PartialView();
        } 
        
        public PartialViewResult PartialEducaiton()
        {
            var values=context.Education.ToList();

            return PartialView(values);
        }
        
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        
        public PartialViewResult PartialSKill()
        {
            var values = context.Skill.ToList();

            return PartialView(values);
        } 
        
        public PartialViewResult PartialSocialMedia()
        {
            var values = context.SocialMedia.Where(x => x.Status == true).ToList();

            return PartialView(values);
        }
    }
}