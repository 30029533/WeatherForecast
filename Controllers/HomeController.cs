using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Models;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        weatherEntities dbContext = new weatherEntities();
        public ActionResult Index()
        {
            weatherEntities myentity = new weatherEntities();
            var getdatelist = myentity.temprature_details.ToList();
            SelectList list = new SelectList(dbContext.temprature_details.Select(m => m.day).Distinct(), "day");
            ViewBag.ddlistname = list;

            return View();
        }

        public ActionResult GetTempratureDetails(string param)
        {
            List<temprature_details> temp = new List<temprature_details>();
            var data = dbContext.temprature_details.Where(a => a.day == param).ToList();

            for (int i = 0; i < data.Count; i++)
            {
                var Temp = new temprature_details();
                Temp.degree = data[i].degree;
                Temp.hour = data[i].hour;

                temp.Add(Temp);
            }

            return this.Json(temp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetWindDetails(String param)
        {
            List<temprature_details> wind = new List<temprature_details>();
            var data = dbContext.temprature_details.Where(a => a.day == param).ToList();

            for (int i = 0; i < data.Count; i++)
            {
                var Temp = new temprature_details();
                Temp.hour = data[i].hour;
                Temp.wind = data[i].wind;

                wind.Add(Temp);
            }

            return this.Json(wind, JsonRequestBehavior.AllowGet);
        }
    }
}