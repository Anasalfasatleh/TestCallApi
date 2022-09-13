using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestCallApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class TestApiController : ControllerBase
    {
        public static int callNo = 0;
        public static Dictionary<int,int> callNoById = new Dictionary<int, int>();

        [HttpGet("SuccessGet")]
        public IActionResult SuccessGet()
        {
            ++callNo;
            Console.WriteLine(callNo + " Success Get => " + DateTime.Now.ToString());
            return Ok();
        }

        [HttpGet("FailureGet")]
        public async Task<IActionResult> FailureGet()
        {
            Console.WriteLine(++callNo + " Failure Get => " + DateTime.Now.ToString());
            return BadRequest();
        }
        
        [HttpGet("SuccessGetWithParameter/{id}")]
        public async Task<IActionResult> SuccessGetWithParameter(int id)
        {
            //if (id == 1) // fast succest
            //{
            //    Console.WriteLine(id + " => " + DateTime.Now.ToString());
            //    return BadRequest();
            //}
            //else if(id == 2)
            //{
            //    await Task.Delay(3000);
            //    Console.WriteLine(id + " => " + DateTime.Now.ToString());
            //    return Ok();
            //}
            //else if (id == 3) // Unauthorized
            //{
            //    await Task.Delay(1000);
            //    Console.WriteLine(id + " => " + DateTime.Now.ToString());
            //    return Unauthorized();
            //}
            //else if (id == 4) // Unauthorized
            //{
            //    await Task.Delay(20000);
            //    Console.WriteLine(id + " => " + DateTime.Now.ToString());
            //    return BadRequest();
            //}
            //else if (id == 70) // take alot of time 
            //{
            //    await Task.Delay(70000);
            //    Console.WriteLine(id + " => " + DateTime.Now.ToString());
            //    return Ok();
            //}
            //else
            //{
            //    Console.WriteLine(id + " => " + DateTime.Now.ToString());
            //    return Ok();
            //}

            Console.WriteLine(id + " => " + DateTime.Now.ToString());
            return Ok();

        }


        [HttpGet("test/{id}/{failedEvrey}/{delay}")]
        public async Task<IActionResult> Test(int id,int failedEvrey, int delay)
        {
            var exist = callNoById.TryGetValue(id, out int calNo);
            if(exist == false)
            {
                calNo = 1;
                callNoById.Add(id, calNo);
            }
            else
            {
                calNo++;
                callNoById[id] = calNo; 
            }
            if (delay != 0)
            {
                await Task.Delay(delay);
            }
            if(failedEvrey != 0)
            {
                if(calNo % failedEvrey == 0)
                {
                    Console.WriteLine(id + "  calNo => "+ calNo + "  time => " + DateTime.Now.ToString());
                    return BadRequest();
                }
            }

            Console.WriteLine(id + "  calNo => " + calNo + "  time => " + DateTime.Now.ToString());
            return Ok();

        }


        [HttpGet("FailureGetWithParameter/{id}")]
        public async Task<IActionResult> FailureGetWithParameter()
        {
            Console.WriteLine(++callNo + " Failure Get With Parameter => " + DateTime.Now.ToString());
            return BadRequest();
        }

        [HttpDelete("SuccessDelete")]
        public async Task<IActionResult> SuccessDelete()
        {
            Console.WriteLine(++callNo + " Success Delete => " + DateTime.Now.ToString());
            return Ok();
        }

        [HttpDelete("FailureDelete")]
        public async Task<IActionResult> FailureDelete()
        {
            Console.WriteLine(++callNo + " Failure Delete => " + DateTime.Now.ToString());
            return BadRequest();
        }

        [HttpPost("SuccessPost")]
        public async Task<IActionResult> SuccessPost([FromBody] TestBody testBody)
        {
            Console.WriteLine(++callNo + " Success Post => " + DateTime.Now.ToString());
            return Ok();
        }

        [HttpPost("FailurePost")]
        public async Task<IActionResult> FailurePost([FromBody] TestBody testBody)
        {
            Console.WriteLine(++callNo + " Failure Post => " + DateTime.Now.ToString());
            return BadRequest();
        }

        [HttpPut("SuccessPut")]
        public async Task<IActionResult> SuccessPut([FromBody] TestBody testBody)
        {
            Console.WriteLine(++callNo + " Success Put => " + DateTime.Now.ToString());
            return Ok();
        }

        [HttpPut("FailurePut")]
        public async Task<IActionResult> FailurePut([FromBody] TestBody testBody)
        {
            Console.WriteLine(++callNo + " Failure Put => " + DateTime.Now.ToString());
            return BadRequest();
        }

        [HttpPatch("SuccessPatch")]
        public async Task<IActionResult> SuccessPatch([FromBody] TestBody testBody)
        {
            Console.WriteLine(++callNo + " Success Patch => " + DateTime.Now.ToString());
            return Ok();
        }

        [HttpPatch("FailurePatch")]
        public async Task<IActionResult> FailurePatch([FromBody] TestBody testBody)
        {
            Console.WriteLine(++callNo + " Failure Patch => " + DateTime.Now.ToString());
            return BadRequest();
        }

        [HttpGet("TestHeaders")]
        public async Task<IActionResult> TestHeaders([FromHeader]string? key1, [FromHeader] string? key2)
        {
            Console.WriteLine(++callNo + " TestHeaders => " + "key1 => "+ key1 +", key2 => " + key2);
            return Ok();
        }

    }
    public class TestBody
    {
        public string Id { get; set; }
        public string name { get; set; }

    }
}