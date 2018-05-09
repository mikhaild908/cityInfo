using System;
using System.Collections.Generic;
using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
		public static CitiesDataStore Current { get; } = new CitiesDataStore();
		public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
		{
			Cities = new List<CityDto>
			{
				new CityDto
				{ 
					Id = 1,
					Name = "New York",
					Description = "NYC",
					PointsOfInterest = new List<PointsOfInterestDto>
					{ 
						new PointsOfInterestDto { Id = 1, Name = "One", Description = "One" },
						new PointsOfInterestDto { Id = 2, Name = "Two", Description = "Two" },
						new PointsOfInterestDto { Id = 3, Name = "Three", Description = "Three" }
					} 
				},
                new CityDto
				{ 
					Id = 2,
					Name = "Los Angeles",
					Description = "LA",
					PointsOfInterest = new List<PointsOfInterestDto>
                    {
                        new PointsOfInterestDto { Id = 4, Name = "Four", Description = "Four" },
                        new PointsOfInterestDto { Id = 5, Name = "Five", Description = "Five" },
                        new PointsOfInterestDto { Id = 6, Name = "Six", Description = "Six" }
                    }               
				},
                new CityDto
				{
					Id = 3,
					Name = "Chicago",
					Description = "Chicago",
					PointsOfInterest = new List<PointsOfInterestDto>
                    {
                        new PointsOfInterestDto { Id = 7, Name = "Seven", Description = "Seven" },
                        new PointsOfInterestDto { Id = 8, Name = "Eight", Description = "Eight" },
                        new PointsOfInterestDto { Id = 9, Name = "Nine", Description = "Nine" }
                    }               
				}
			};
		}
    }
}