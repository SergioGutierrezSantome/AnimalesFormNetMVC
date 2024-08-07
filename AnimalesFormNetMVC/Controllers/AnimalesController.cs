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

        private  AnimalDal animal = new AnimalDal();
        private TipoAnimalDal TipoanimalDal = new TipoAnimalDal();
        // GET: Animales
        [HttpPost]
        public ActionResult DeleteSelected(int[] selectedItems)
        {
            animal.DeletedAnimals(selectedItems);
            return RedirectToAction("index");
        }
        public ActionResult FormAdd()
        {
            var tiposanimales = TipoanimalDal.SelectTipoAnimalDal();
            // Aquí podrías llenar ViewBag o ViewData con datos para los campos desplegables si es necesario
            return View(tiposanimales);
        }
        [HttpPost]
        public ActionResult FormAdd(Animal aanimal)
        {
            animal.AddAnimal(aanimal);
            // Aquí podrías llenar ViewBag o ViewData con datos para los campos desplegables si es necesario
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
               var animales = animal.SelectAnimalDal();
             Random rnd = new Random();
            int NumAleatorio = rnd.Next(0, animales.Count);
            ViewBag.Message = "Tu animal de la suerte del dia es " + animales[NumAleatorio].NombreAnimal;
            return View(animales);
        }
    }
}