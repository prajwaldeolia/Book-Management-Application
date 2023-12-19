using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //[Route("api/get-all")]                  //using multiple urls or routs
        //[Route("getall")]
        public string GetAll()
        {
            return "hello from get all";
        }

        //[Route("api/get-all-authors")]
        //[Route("getall")]                       //this cannot be done
        [Route("~/getauthors")]                   //to not use the base url or use custom url
        public string GetAllAuthors()
        {
            return "hello from get all authors";
        }

        //[Route("books/{id}")]
        public string GetById(int id)
        {
            return "hello " + id;
        }

        //[Route("books/{id}/author/{authorId}")]
        [Route("{id}/{authorId}")]
        public string GetAuthorAddressById(int id, int authorId)
        {
            return "hello author address " + id + " " + authorId;
        }

        //[Route("search")]
        public string SearchBooks(int id, int authorId, string name, int rating, int price)
        {
            return "hello from search";
        }
    }
}
