using HotelManage.Moudle;
using HotelManage.Repositery;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JodAssingController : ControllerBase
    {
        private readonly Ijodassingcs _hote;

        public JodAssingController(Ijodassingcs hote)
        {
            this._hote = hote;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Alldata = await _hote.GetAllAsyc();
            return Ok(Alldata);
        }

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


        [HttpPost]
        public async Task<IActionResult> Post(JodAssing value)
        {
            await _hote.creatAsync(value);
            return Ok("sucesfull create");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(String id, [FromBody] JodAssing value)
        {
            var cotgart = await _hote.GetById(id);
            if (cotgart == null)
            {
                return NotFound();
            }
            await _hote.Updatecatogry(id, value);

            return Ok("Updatecatogry  Succesfully");
        }


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
    }
}
