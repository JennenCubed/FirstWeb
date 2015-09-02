using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer;

namespace WebOne.Controllers
{
    public class PokemonController : Controller
    {
        private PokemonDAL PDAL = new PokemonDAL();
        // GET: Pokemon
        public ActionResult Index()
        {
            List<Pokemon> pokemon = PDAL.pokemon.ToList();
            return View(pokemon);
        }
    }
}