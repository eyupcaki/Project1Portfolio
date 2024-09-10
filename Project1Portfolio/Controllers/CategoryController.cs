using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project1Portfolio.Controllers
{
    public class CategoryController : Controller
    {
       
        // GET: Category
        public ActionResult CategoryList()
        {
            
            return View();
        }
        
        public ActionResult CreateCategory()
        {
            
            return View();
        }



        //public string deneme()
        //{
        //    return "merhaba";
        //}

        //public double test()
        //{
        //    return 3.14;
        //}

    }
}