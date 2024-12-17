using MaratonApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

namespace MaratonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FutokController : ControllerBase
    {
        private readonly FutokInterface futokInterface;

        public FutokController(FutokInterface futokInterface)
        {
            this.futokInterface = futokInterface;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRunners()
        {
            var runners = await futokInterface.AllRunner();
            if (runners != null)
            {
                return Ok(new { result = runners, message = "Sikeres lekérdezés" });
            }
            Exception e = new();
            return BadRequest(new { result = runners, message = e.Message });
        }
        [HttpGet("byid")]
        public async Task<ActionResult> GetById(int id)
        {
            var runner = await futokInterface.ById(id);
            if (runner != null)
            {

                return Ok(runner);
            }
            return NotFound();

        }
        [HttpGet("runneralldata")]
        public async Task<ActionResult> GetRunnerWithAllData(int id)
        {
            var runner = await futokInterface.RunnerWithAllData(id);
            if (runner != null)
            {

                return Ok(runner);
            }
            return NotFound();
        }
        [HttpGet("femalesrunners")]
        public async Task<ActionResult> AllFemaleRunners()
        {
            var females = await futokInterface.AllFemaleRunner();
            return Ok(females);

        }
        [HttpGet("agerunners")]
        public async Task<ActionResult> GetRunnersAage()
        {
            var age = await futokInterface.RunnerAge();
            if (age != null)
            {
                return Ok(age);
            }
            return BadRequest();
        }
    }
}
