using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Urlize_back.Dtos;
using Urlize_back.Models;
using Urlize_back.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Urlize_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private IGenericCRUDService<Catalogue, CatalogueCreateDto> _genericCRUDService;
        public CatalogueController(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;

            _context = context;
            _genericCRUDService = new GenericCRUDService<Catalogue, CatalogueCreateDto>(_mapper, context);
        }

        // GET: api/<CatalogueController>
        [HttpGet]
        public async Task<IEnumerable<Catalogue>> Get()
        {
            return await _genericCRUDService.GetAll();
        }

        // GET api/<CatalogueController>/5
        [HttpGet("{id}")]
        public async Task<Catalogue> GetCatalogue(int id)
        {
            Expression<Func<Catalogue, bool>> predicate = b => b.Id == id;
            return await _genericCRUDService.GetById(predicate);
        }


        // POST api/<CatalogueController>
        [HttpPost]
        public async Task<Catalogue> Post(CatalogueCreateDto catadto)
        {

            return await _genericCRUDService.Add(catadto);
        }

        // PUT api/<CatalogueController>/5
        [HttpPut("{id}")]
        public async Task<Catalogue> Put(int id, CatalogueCreateDto catadto)
        {
            return await _genericCRUDService.Update(id, catadto);
        }

        // DELETE api/<CatalogueController>/5
        [HttpDelete("{id}")]
        public async Task<Catalogue> Delete(int id)
        {
            return await _genericCRUDService.Delete(id);
        }
    }
}