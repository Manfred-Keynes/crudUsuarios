﻿using MVC__curso.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC__curso.Files
{
    public class ArchivoController : Controller
    {
        // GET: Archivo
        public ActionResult Index()
        {
            //validar si tempdata es sitintito de null es porque existe por lo tanto lo fuardo  en un viewbag
            if (TempData["Message"]!=null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }
            return View();
        }

        [HttpPost]
        public ActionResult Save(ArchivoViewModel model)
        {
            string RutaSitio = Server.MapPath("~/");
            string PathArchivo1 = Path.Combine(RutaSitio + "/Files/archivo1.png");
            string PathArchivo2 = Path.Combine(RutaSitio + "/Files/archivo2.png");

            //valida los data notations
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            model.Archivo1.SaveAs(PathArchivo1);
            model.Archivo2.SaveAs(PathArchivo2);

            @TempData["Message"] = "Se cargaron los archivos"; 
            return RedirectToAction("Index");
        }
    }
}