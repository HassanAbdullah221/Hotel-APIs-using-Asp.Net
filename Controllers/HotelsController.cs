using Microsoft.AspNetCore.Mvc;
using TrainingProject.Data;

namespace TrainingProject.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private static List<Hotel> hotels = new List<Hotel>
            {
            new Hotel { Id=1 , Name="Grand Plaza" , Adress = "123 Main st" , Rating = 4},
             new Hotel { Id=2 , Name="Ocean View" , Adress = "456 Beach st" , Rating = 2}
            };

        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> Get()
        {
            return Ok(hotels);
        }

       
        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            var hotel = hotels.FirstOrDefault(hotels => hotels.Id == id);
            if (hotel == null)
                {
                    return NotFound();
                }
            return Ok(hotel);
        }

       
        [HttpPost]
        public ActionResult<Hotel> Post([FromBody] Hotel newHotel)
        {
            if(hotels.Any(h => h.Id == newHotel.Id))
            {
                return BadRequest("Hotel Already Exist");
            }
        hotels.Add(newHotel);
        return CreatedAtAction(nameof(Get) , new {id = newHotel.Id } , newHotel);
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Hotel updatedHotel)
        {
        var existingHotel = hotels.FirstOrDefault(hotels => hotels.Id == id);
        if (existingHotel == null)
        {
            return NotFound();
        } 
        
        existingHotel.Name = updatedHotel.Name;
        existingHotel.Adress = updatedHotel.Adress;
        existingHotel.Rating = updatedHotel.Rating;
        return Ok(updatedHotel);
        }

        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
        var hotel = hotels.FirstOrDefault(hotels => hotels.Id == id);
        if (hotel == null)
        {
            return NotFound(new {message = "Hotel not found" });
        }
        hotels.Remove(hotel);
        return NoContent();
    }
    }

