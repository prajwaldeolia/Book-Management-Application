using ConsoleToWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[BindProperties]                              // this works on the controller level tht is the only difference rest all is same
    public class CountriesController : ControllerBase
    {

        //[BindProperty]
        //public string? Name { get; set; }

        //[BindProperty]
        //public int Population { get; set; }

        //[BindProperty]
        //public int Area { get; set; }

        [BindProperty]                              //[BindProperty(SupportsGet = true)] this to work with [httpGet("")] Attribute
        public CountryModel Country { get; set; }

        //[HttpPost("")]
        //public IActionResult AddCountry()
        //{
        //    return Ok($"Name = { this.Country.Name}, Population = {this.Country.Population}, Area = {this.Country.Area}");
        //}

        [HttpGet("name")]               //if u use rout then also [FromQuery]attribute force to use query string data
        public IActionResult AddCountry([FromQuery]string name)
        {
            return Ok($"Name = {name}");
        }

        //public IActionResult AddCountry([FromRoute] string name)         //similar to [FromQuery] attribute there is [FromRoute] which work only with route

        //we can use multiple attribute also

        [HttpGet("search")]
        public IActionResult SearchCountries([ModelBinder(typeof(CustomBinder))]string[] countries)
        {
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public IActionResult CountryDetails([ModelBinder(Name = "Id")]CountryModel country)
        {
            return Ok(country);
        }
    }
}
