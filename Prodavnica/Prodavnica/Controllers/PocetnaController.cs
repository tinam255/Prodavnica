using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Prodavnica.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;

namespace Prodavnica.Controllers
{
    public class PocetnaController : Controller
    {
        private Model1 db = new Model1();

        // GET: Pocetna
        public ActionResult Index()
        {
            var proizvodis = db.proizvodis.Include(p => p.dobavljaci).Include(p => p.kategorije).Include(p => p.proizvodjaci);

            string proizvodi_json_putanja = Server.MapPath(@"Proizvodi JSON\proizvodi.json");

            StreamReader sr = new StreamReader(proizvodi_json_putanja);

            string json = sr.ReadToEnd();

            List<proizvodi> proizvodi_json_kontent = new List<proizvodi>();

            proizvodi_json_kontent = JsonConvert.DeserializeObject<List<proizvodi>>(json);

            return View(proizvodis.ToList().Concat(proizvodi_json_kontent));
        }
    }
}
