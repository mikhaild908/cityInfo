using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
	//[Route("api/[controller]")]
	[Route("api/cities")]
	public class CitiesController : Controller
    {
		//[HttpGet()]
        //public JsonResult GetCities()
		//{         
		//	return new JsonResult(CitiesDataStore.Current.Cities);
		//}

        [HttpGet()]
        public IActionResult GetCities()
		{
			return Ok(CitiesDataStore.Current.Cities);
		}
        
		////[HttpGet("api/cities/{id}")]
		//[HttpGet("{id}")]
        //public JsonResult GetCity(int id)
		//{
		//	return new JsonResult(CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id));
		//}

		//[HttpGet("api/cities/{id}")]
        [HttpGet("{id}")]
		public IActionResult GetCity(int id)
		{
			var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
			{
				return NotFound();
			}

			return Ok(cityToReturn); 
		}
    }
}
