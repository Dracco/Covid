using Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CovidController.Controllers
{
    [Route("api/covid/[controller]")]
    [ApiController]
    public class CasosController : ControllerBase
    {
        // GET api/covid/casos/mensais
        [Route("mensais")]
        [HttpGet]
        public ActionResult<IEnumerable<Core.Models.ConfirmedSummary>> Mensais()
        {
            CovidService covidService = new CovidService();

            var confirmeds = covidService.GetConfirmeds();
            return confirmeds;

        }
    }
}
