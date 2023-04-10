using Microsoft.AspNetCore.Mvc;

namespace Statement.Controllers
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