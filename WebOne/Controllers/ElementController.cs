using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;

namespace WebOne.Controllers
{
    public class ElementController : Controller
    {
        private ElementDAL EDAL = new ElementDAL();
        // GET: Element
        public ActionResult Index()
        {
            List<Element> elements = EDAL.elements.ToList();
            return View(elements);
        }
    }
}