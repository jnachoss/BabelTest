using Microsoft.AspNetCore.Mvc;
using PruebaBabelAPI.Models;
using PruebaBabelAPI.Service;
using System.Numerics;

namespace PruebaBabelAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService) 
        { 
            this.countryService = countryService;
        }
        [HttpGet]
        public ActionResult Get(int pageNumber, int rowsPerPage, string keyword = "")
        {
            IList<Country> countries = new List<Country>();

            try
            {
                countries = countryService.GetCountries(pageNumber, rowsPerPage, keyword);


                Response.Headers.Add("TotalItem", countries.Count().ToString());
                return Ok(countries);
            }
            catch (Exception)
            {
                Response.Headers.Add("TotalItem", "0");
                return BadRequest();
            }

        }
    }
}
