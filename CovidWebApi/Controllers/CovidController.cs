using CovidWebApi.Lib;
using CovidWebApi.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CovidWebApi.Controllers
{
    public class CovidController : Controller
    {
        public ActionResult Index()
        {
            ConfirmedViewModel confirmedViewModel = new ConfirmedViewModel();
            
            confirmedViewModel.ConfirmedList = Util.GetJsonAndDeserialize<List<Confirmed>>("http://localhost:5000/api/covid/casos/mensais", "application/json");

            if (confirmedViewModel.ConfirmedList == null)
            {
                confirmedViewModel.ConfirmedList = new List<Confirmed>();
            }
            return View(confirmedViewModel);
        }
    }
}
