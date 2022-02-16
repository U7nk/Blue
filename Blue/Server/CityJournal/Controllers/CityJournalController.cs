using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using Blue.Server.CityJournal.Models;
using Blue.Server.Database;
using Blue.Shared;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blue.Server.CityJournal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CityJournalController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CityJournalController(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CityViewModel>>> GetAll() =>
            await dbContext.CityModels
                .Select(x => mapper.Map<CityViewModel>(x))
                .ToListAsync();

        [HttpGet("{id:long}")]
        public async Task<ActionResult<CityViewModel>> GetById(long id)
        {
            var cityModel = await dbContext.CityModels.FindAsync(id);

            if (cityModel == null)
            {
                return NotFound();
            }

            return mapper.Map<CityViewModel>(cityModel);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult> Update(long id, CityViewModel cityViewModel)
        {
            if (id != cityViewModel.Id)
            {
                return BadRequest();
            }
            
            var cityModel = mapper.Map<CityModel>(cityViewModel);
            
            dbContext.Entry(cityModel).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityModelExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<CityViewModel>> Create(CityViewModel cityViewModel)
        {
            var newCityModel = mapper.Map<CityModel>(cityViewModel);

            dbContext.CityModels.Add(newCityModel);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = newCityModel.Id },
                mapper.Map<CityViewModel>(newCityModel));
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> Delete(long id)
        {
            var city = dbContext.Find<CityModel>(id);
            if (city is null)
            {
                return NotFound();
            }
            
            dbContext.Remove(city);
            
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityModelExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }
        private bool CityModelExists(long id) => dbContext.CityModels.Any(x => x.Id == id);
    }
}
