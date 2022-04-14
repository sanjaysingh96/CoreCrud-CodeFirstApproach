using CoadFirstWithCore.dbdata;
using CoadFirstWithCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoadFirstWithCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly mydata _db;
            
            public HomeController(mydata db)
        {
            _db = db;
        }



        public IActionResult Index()
        {
            var res = _db.Empmodels.ToList();
            List<Empmodel> obj = new List<Empmodel>();
            foreach (var item in res)
            {
                obj.Add(new Empmodel
                {
                    id=item.id,
                    name=item.name,
                    age=item.age,
                    email=item.email
                });
            }

            return View(obj);
        }
        [HttpGet]
        public IActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmp(Empmodel obj)
        {
            Empmodel tbl = new Empmodel();
            tbl.id = obj.id;
            tbl.name = obj.name;
            tbl.age = obj.age;
            tbl.email = obj.email;

            if (obj.id == 0)
            {
                _db.Empmodels.Add(tbl);
                _db.SaveChanges();
            }
            else
            {
                _db.Entry(tbl).State = EntityState.Modified;
                _db.SaveChanges();
            }
            
            return RedirectToAction("Index","Home");
        }

        public IActionResult Delete(int id)
        {
            var deleteitem = _db.Empmodels.Where(a => a.id == id).First();
            _db.Empmodels.Remove(deleteitem);
            _db.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        public IActionResult Edit(int id)
        {
            Empmodel modobj = new Empmodel();
            var edititem = _db.Empmodels.Where(a => a.id == id).First();
            modobj.id = edititem.id;
            modobj.name = edititem.name;
            modobj.age = edititem.age;
            modobj.email = edititem.email;

            return View("AddEmp",edititem);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
