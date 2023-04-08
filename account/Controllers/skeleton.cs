using Microsoft.AspNetCore.Mvc;

namespace Account.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Skeleton : ControllerBase
    {
        [HttpGet]
        public ActionResult GetSkeleton() {
            return NotFound();
        }
    }
}