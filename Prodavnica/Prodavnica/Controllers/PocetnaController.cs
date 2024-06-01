using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Prodavnica.Models;

namespace Prodavnica.Controllers
{
    public class PocetnaController : Controller
    {
        private Model1 db = new Model1();

        // GET: Pocetna
        public ActionResult Index()
        {
            var proizvodis = db.proizvodis.Include(p => p.dobavljaci).Include(p => p.kategorije).Include(p => p.proizvodjaci);
            return View(proizvodis.ToList());
        }
    }
}
