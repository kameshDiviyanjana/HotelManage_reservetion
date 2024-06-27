using HotelManage.Moudle;
using HotelManage.Repositery;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {

        private readonly IHotelseriveRepositer _hote;

        public HotelController(IHotelseriveRepositer hote)
        {
            this._hote = hote;
        }
        // GET: api/hotel
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Alldata = await _hote.GetAllAsyc();
            return Ok(Alldata);
        }

        // GET api/hotel/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(String id)
        {
            var Hotels = await _hote.GetById(id);
            if (Hotels == null)
            {
                return BadRequest("Not found");
            }
            return Ok(Hotels);
        }
        // POST api/hotel
        [HttpPost]
        public async Task<IActionResult> Post( Hotel value)
        {
            /*string oo = "";
            var hotel = new Hotel
            {
                Id= oo,
                addres = value.addres,
                packeage = value.packeage,
                phoneNumber = value.phoneNumber,
                Dateonly = value.Dateonly,
                Dateonlyend = value.Dateonlyend,
                location = value.location,
                Name = value.Name,
                Status = value.Status,
                priority = value.priority,
              

            };*/
         /*   var hotel = new Hotel
            {
                // Id is not explicitly set here, MongoDB will generate it
                addres = value.addres,
                packeage = value.packeage,
                phoneNumber = value.phoneNumber,
                Dateonly = value.Dateonly,
                Dateonlyend = value.Dateonlyend,
                location = value.location,
                Name = value.Name,
                Status = value.Status,
                priority = value.priority,
            };*/
            await _hote.creatAsync(value);
            return Ok("sucesfull create");
        }

        // PUT api/hotel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(String id, [FromBody] Hotel value)
        {
            var cotgart = await _hote.GetById(id);
            if (cotgart == null)
            {
                return NotFound();
            }
            await _hote.Updatecatogry(id, value);

            return Ok("Updatecatogry  Succesfully");
        }

        // DELETE api/hotel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(String id)
        {
            var cotgart = await _hote.GetById(id);
            if (cotgart == null)
            {
                return NotFound();
            }
            await _hote.deletebyid(id);
            return Ok($"Student with id = {id} delete");

        }

        [HttpPost("calculate-sum")]
        public ActionResult<double> CalculateSum([FromBody] CalculationRequest request)
        {
            if (request == null || request.Values == null || !request.Values.Any())
            {
                return BadRequest("No values provided");
            }

            double sum = request.Values.Sum();
            return Ok(sum);
        }

    }
}
