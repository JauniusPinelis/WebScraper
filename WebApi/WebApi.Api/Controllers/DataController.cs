using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Infrastructure.Db;
using WebApi.Infrastructure.Dtos;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private DataContext _context;
        private IMapper _mapper;

        public DataController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<JobUrlDto>> Get()
        {
            var entities = _context.JobHtmls.Take(20);

            var models = _mapper.Map<List<JobUrlDto>>(entities);

            return models;
        }
    }
}
