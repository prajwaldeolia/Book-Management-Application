using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [Route("{id:int:minlength(1):maxlength(2):range(45, 55)}")]
        public string GetById(int id)
        {
            return "hello int " + id;
        }
                                                                        //sb p sb chalta hai
        [Route("{id:min(1):max(3)}")]
        public string GetByStringId(string id)
        {
            return "hello string " + id;
        }
    }
}
