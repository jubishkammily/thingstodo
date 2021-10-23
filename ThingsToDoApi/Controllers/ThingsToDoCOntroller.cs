using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ThingsToDoApi.Data;
using ThingsToDoApi.Entities;

namespace ThingsToDoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThingsToDoCOntroller : ControllerBase
    {
        private readonly DataContext _context;
        public ThingsToDoCOntroller(DataContext context)
        {
            _context = context;
        }

        // [HttpGet]
        // public ActionResult<IEnumerable<AppDataTable>> GetListTopThings(string category){
        //     return (_context.Details
        //     .Where(p=>p.Category ==category).ToList());
        // }

        // Convert the above code to Asynchronous so that when the database is running others can use this Http call
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppDataTable>>> GetListTopThings(string category){
            var topList =   await (_context.Details
            .Where(p=>p.Category ==category).ToListAsync());

            var topList2 = topList.OrderBy(s => s.Rank);

            return topList2.ToList();
        }
 
    }
}