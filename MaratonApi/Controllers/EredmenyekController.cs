using MaratonApi.Models;
using MaratonApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaratonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EredmenyekController : ControllerBase
    {
        private readonly EredmenyekInterface eredmenyekInterface;

        public EredmenyekController(EredmenyekInterface eredmenyekInterface)
        {
            this.eredmenyekInterface = eredmenyekInterface;
        }
        [HttpPost]
        public async Task<ActionResult> PostNewResult(Eredmenyek eredmenyek)
        {
            var ered = await eredmenyekInterface.NewResult(eredmenyek);
            if (ered == null)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
