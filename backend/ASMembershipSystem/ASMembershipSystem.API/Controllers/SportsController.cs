using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASMembershipSystem.API.Models;
using ASMembershipSystem.Core.Domain;
using ASMembershipSystem.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASMembershipSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly ISportService _sportService;

        public SportsController(ISportService sportService)
        {
            _sportService = sportService;
        }
        
        [HttpGet]
        public ActionResult<List<SportDto>> GetAllSports()
        {
            var sports = _sportService.GetAllSports().Select(s => new SportDto 
            { 
                Id = s.Id,
                Name = s.Name
            }).ToList();

            return Ok(sports);
        }
    }
}