using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Models
{
    [ModelBinder(typeof(CustomBinderCountryDetails))]
    public class CountryModel
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int Population { get; set; }
        public int Area { get; set; }
    }
}
