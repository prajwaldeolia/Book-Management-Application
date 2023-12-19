using ConsoleToWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private List<AnimalModel>? ani = null;
        public AnimalController()
        {
            ani = new List<AnimalModel>()
            {
                new AnimalModel() {Id = 1, Name = "Dog"},
                new AnimalModel() {Id = 2, Name = "Lion"}
            };
        }

        [Route("", Name = "All")]
        public IActionResult GetAnimal()
        {
            //ani = new List<AnimalModel>()
            //{
            //    new AnimalModel() {Id = 1, Name = "Dog"},
            //    new AnimalModel() {Id = 2, Name = "Lion"}
            //};
            return Ok(ani);
        }

        [Route("test")]
        public IActionResult GetAnimalTest()
        {
            //return Accepted("~/api/animal");
            //return AcceptedAtAction("GetAnimal");
            //return AcceptedAtRoute("All");
            //return LocalRedirect("~/api/animal");
            return LocalRedirectPermanent("~/api/animal");
        }

        [Route("{name}")]
        public IActionResult GetAnimalByName(string name)
        {
            if(!name.Contains("ABC"))
                return BadRequest();
                //return BadRequest(name);

            return Ok(ani);
        }

        [Route("{id:int}")]
        public IActionResult GetAnimalById(int id)
        {
            if (id == 0)
                return BadRequest();
            //return BadRequest(name);

            var anim = ani.FirstOrDefault(x => x.Id == id);

            if (anim == null)
                return NotFound();

            return Ok(anim);
        }

        [HttpPost("")]
        public IActionResult GetAnimal(AnimalModel animal)
        {
            ani.Add(animal);

            //return Created("~/api/animal", new { id = animal.Id });
            //return Created("~/api/animal" + animal.Id, animal);
            return CreatedAtAction("GetAnimalById", new { id = animal.Id }, animal);
        }
    }
}
