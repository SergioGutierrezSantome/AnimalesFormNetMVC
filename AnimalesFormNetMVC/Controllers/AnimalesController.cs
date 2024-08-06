using AnimalesFormNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalesFormNetMVC.Controllers
{
    public class AnimalesController : Controller
    {
        // GET: Animales
        public ActionResult Index()
        {
            List<Animal> ListaAnimal = new List<Animal>()
            {
                new Animal(){IdAnimal=1,nombre="Gato"},
                new Animal(){IdAnimal=2,nombre="Perro"},
                new Animal(){IdAnimal=3,nombre="Cocodrilo"},
                new Animal(){IdAnimal=4,nombre="Pajaro"},
                new Animal(){IdAnimal=5,nombre="Aguila"}
            };
            Random rnd = new Random();
            int NumAleatorio = rnd.Next(0, 5);
            ViewBag.Message = "Tu animal de la suerte del dia es " + ListaAnimal[NumAleatorio].nombre;
            return View(ListaAnimal);
        }
    }
}