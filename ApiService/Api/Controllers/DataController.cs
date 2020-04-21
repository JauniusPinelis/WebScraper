using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Application.JobUrls.Queries.GetJobUrls;
using WebApi.Infrastructure.Db;

namespace WebApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : BaseController
    {
        private DataContext _context;
        private IMapper _mapper;

        public DataController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        /*[HttpGet]
        public ActionResult<IEnumerable<JobUrlDto>> Get()
        {
            var entities = _context.JobHtmls.Take(20);

            var models = _mapper.Map<List<JobUrlDto>>(entities);

            return models;
        }*/

        [HttpGet]
        public async Task<ActionResult<JobUrlsVm>> Get()
        {
            return Ok(await Mediator.Send(new GetJobUrlsQuery()));
        }
    }
}
