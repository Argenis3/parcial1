﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial1.API.Data;
using Parcial1.Shared.Entities;

namespace Parcial1.API.Controllers
{
    [ApiController]
    [Route("/api/vehicles")]
    public class VehiclesController:ControllerBase
    {
        private readonly DataContext dataContext;

        public VehiclesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Vehicles.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Vehicle vehicle)
        {
            dataContext.Vehicles.Add(vehicle);  
            await dataContext.SaveChangesAsync();
            return Ok(vehicle);
        }
    }
}
