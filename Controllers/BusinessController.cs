using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Urlize_back.Dtos;
using Urlize_back.Models;
using Urlize_back.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Urlize_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private IGenericCRUDService<Business,BusinessCreateDto,BusinessUpdateDto> _genericCRUDService;
        public BusinessController(AppDbContext context,IMapper mapper)
        {
            _mapper = mapper;

            _context = context;
            _genericCRUDService = new GenericCRUDService<Business, BusinessCreateDto,BusinessUpdateDto>(_mapper, context);
        }

        // GET: api/<BusinessController>
        [HttpGet]
        public async Task<IEnumerable<Business>> Get()
        {
            return await _genericCRUDService.GetAll();
        }

        // GET api/<BusinessController>/5
        [HttpGet("{id}")]
        public async Task<Business> GetBusiness(int id)
        {
            Expression<Func<Business, bool>> predicate = b => b.Id == id;
            return await _genericCRUDService.GetById(predicate);
        }


        // POST api/<BusinessController>
        [HttpPost]
        public async Task<Business> Post(BusinessCreateDto businessdto)
        { 

            return await _genericCRUDService.Add(businessdto);
        }

        // PUT api/<BusinessController>/5
        [HttpPut("{id}")]
        public async Task<Business> Put(int id, BusinessUpdateDto business)
        {
            return await _genericCRUDService.Update(id, business);
        }

        // DELETE api/<BusinessController>/5
        [HttpDelete("{id}")]
        public async Task<Business> Delete(int id)
        {
            return await _genericCRUDService.Delete(id);
        }
    }
}