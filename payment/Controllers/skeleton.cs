using Microsoft.AspNetCore.Mvc;

namespace Payment.Controllers
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