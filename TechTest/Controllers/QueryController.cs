using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TechTest.Services;

namespace TechTest.Controllers
{
    public class QueryController:Controller
    {
        private readonly IDataAccess _dataAccess;

        public QueryController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        
        [Route("")]
        [HttpGet]
        public IActionResult Query(string deliveryPartner, DateTime effectiveDate)
        {
            return Content(
                JsonConvert.SerializeObject(_dataAccess.Query(deliveryPartner, effectiveDate)), "application/json");
        }
    }
}