using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestCallApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TestApiController : ControllerBase
    {

        [HttpGet("SuccessGet")]
        public async Task<IActionResult> SuccessGet()
        {
            Console.WriteLine("Success Get => "+ DateTime.Now.ToString());
            return Ok();
        }

        [HttpGet("FailureGet")]
        public async Task<IActionResult> FailureGet()
        {
            Console.WriteLine("Failure Get => "+ DateTime.Now.ToString());
            return BadRequest();
        }
        
        [HttpGet("SuccessGetWithParameter/{id}")]
        public async Task<IActionResult> SuccessGetWithParameter(int id)
        {
            Console.WriteLine("Success Get With Parameter => "+ DateTime.Now.ToString());
            return Ok();
        }

        [HttpGet("FailureGetWithParameter/{id}")]
        public async Task<IActionResult> FailureGetWithParameter()
        {
            Console.WriteLine("Failure Get With Parameter => "+ DateTime.Now.ToString());
            return BadRequest();
        }

        [HttpDelete("SuccessDelete")]
        public async Task<IActionResult> SuccessDelete()
        {
            Console.WriteLine("Success Delete => "+ DateTime.Now.ToString());
            return Ok();
        }

        [HttpDelete("FailureDelete")]
        public async Task<IActionResult> FailureDelete()
        {
            Console.WriteLine("Failure Delete => "+ DateTime.Now.ToString());
            return BadRequest();
        }

        [HttpPost("SuccessPost")]
        public async Task<IActionResult> SuccessPost([FromBody] TestBody testBody)
        {
            Console.WriteLine("Success Post => "+ DateTime.Now.ToString());
            return Ok();
        }

        [HttpPost("FailurePost")]
        public async Task<IActionResult> FailurePost([FromBody] TestBody testBody)
        {
            Console.WriteLine("Failure Post => "+ DateTime.Now.ToString());
            return BadRequest();
        }

        [HttpPut("SuccessPut")]
        public async Task<IActionResult> SuccessPut([FromBody] TestBody testBody)
        {
            Console.WriteLine("Success Put => " + DateTime.Now.ToString());
            return Ok();
        }

        [HttpPut("FailurePut")]
        public async Task<IActionResult> FailurePut([FromBody] TestBody testBody)
        {
            Console.WriteLine("Failure Put => "+ DateTime.Now.ToString());
            return BadRequest();
        }

        [HttpPatch("SuccessPatch")]
        public async Task<IActionResult> SuccessPatch([FromBody] TestBody testBody)
        {
            Console.WriteLine("Success Patch => "+ DateTime.Now.ToString());
            return Ok();
        }

        [HttpPatch("FailurePatch")]
        public async Task<IActionResult> FailurePatch([FromBody] TestBody testBody)
        {
            Console.WriteLine("Failure Patch => "+ DateTime.Now.ToString());
            return BadRequest();
        }

    }
    public class TestBody
    {
        public string Id { get; set; }
        public string name { get; set; }

    }
}