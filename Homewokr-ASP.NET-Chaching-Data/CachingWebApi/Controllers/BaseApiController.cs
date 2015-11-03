namespace CachingWebApi.Controllers
{
    using System.Web.Mvc;
    using Models;

    public class BaseApiController : Controller
    {
        protected BaseApiController()
        {
        }

        public BaseApiController(ApplicationDbContext context)
        {
            Data = context;
        }

        public ApplicationDbContext Data { get; set; }
    }
}