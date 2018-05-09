using System.Linq;
using CityInfo.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
	[Route("api/cities")]
	public class PointsOfInterestController : Controller
	{
		[HttpGet("{cityId}/pointsOfInterest")]
		public IActionResult GetPointsOfInterest(int cityId)
		{
			var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

			if (city == null)
			{
				return NotFound();
			}

			return Ok(city.PointsOfInterest);
		}

		[HttpGet("{cityId}/pointsOfInterest/{id}", Name = "GetPointOfInterest")]
		public IActionResult GetPointOfInterest(int cityId, int id)
		{
			var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

			var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

			if (pointOfInterest == null)
            {
                return NotFound();
            }

			return Ok(pointOfInterest);
		}

		[HttpPost("{cityId}/pointsOfInterest")]
		public IActionResult CreatePointOfInterest(int cityId,
		                                          [FromBody]PointOfInterestForCreationDto pointOfInterest)
		{
			if (pointOfInterest == null)
			{
				return BadRequest();
			}

            if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
			{
				return NotFound();
			}

			var maxPointOfInterestId =
				CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(p => p.Id);

			var finalPointOfInterest = new PointsOfInterestDto()
			{
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
			};

			city.PointsOfInterest.Add(finalPointOfInterest);

			return CreatedAtRoute("GetPointOfInterest",
			                      new { cityId = cityId, id = finalPointOfInterest.Id },
			                      finalPointOfInterest);
		}
    
		[HttpPut("{cityId}/pointsOfInterest/{id}")]
	    public IActionResult UpdatePointOfInterest(int cityId, int id,
		                                           [FromBody]PointOfInterestForCreationDto pointOfInterest)
		{
			if (pointOfInterest == null)
			{
				return BadRequest();
			}

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

			var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

			if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

			pointOfInterestFromStore.Name = pointOfInterest.Name;
			pointOfInterestFromStore.Description = pointOfInterest.Description;

			return NoContent();
		}

		[HttpPatch("{cityId}/pointsOfInterest/{id}")]
        public IActionResult PartiallyUpdatePointOfInterest(int cityId, int id,
		                                                    [FromBody] JsonPatchDocument<PointOfInterestForUpdateDto>patchDocument)
		{
			if (patchDocument == null)
			{
				return BadRequest();
			}

			var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

			var pointOfInterestToPatch =
				new PointOfInterestForUpdateDto()
				{
                    Name = pointOfInterestFromStore.Name,
				    Description = pointOfInterestFromStore.Description
				};

			patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

            if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);	
			}

			//TryValidateModel(pointOfInterestToPatch);  // TODO: research
            
			pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
			pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

			return NoContent();

            // use this in the body in PostMan
            //[
			// {
			//      "op": "replace",
			//      "path": "/name",
			//      "value": "new name value"
		    // },
			// {
            //      "op": "replace",
            //      "path": "/description",
            //      "value": "new description value"
            // },
			//]
		}
	
		[HttpDelete("{cityId}/pointsOfInterest/{id}")]
		public IActionResult DeletePointOfInterest(int cityId, int id)
		{
			var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(p => p.Id == id);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

			city.PointsOfInterest.Remove(pointOfInterest);

			return NoContent();
		}
	}
}
