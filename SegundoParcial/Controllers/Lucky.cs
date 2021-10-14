using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegundoParcial.Data;
using SegundoParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Lucky : ControllerBase
    {
        private readonly AppDbContext _context;

        public Lucky(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Suerte>> GetSuerte()
        {

            var list = await _context.Lucky.ToListAsync();

            var max = list.Count;
            int index = new Random().Next(0, max);

            var suerte = list[index];

            if (suerte == null)
            {
                return NoContent();
            }

            return suerte;
        }
    }
}

