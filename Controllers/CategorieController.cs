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


namespace Urlize_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        private IGenericCRUDService<Categorie, CategorieCreateDto> _genericCRUDService;
        public CategorieController(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;

            _context = context;
            _genericCRUDService = new GenericCRUDService<Categorie, CategorieCreateDto>(_mapper, context);
        }

        // GET: api/<CategorieController>
        [HttpGet]
        public async Task<IEnumerable<Categorie>> Get()
        {
            return await _genericCRUDService.GetAll();
        }

        // GET api/<CategorieController>/5
        [HttpGet("{id}")]
        public async Task<Categorie> GetCategorie(int id)
        {
            Expression<Func<Categorie, bool>> predicate = b => b.Id == id;
            return await _genericCRUDService.GetById(predicate);
        }


        // POST api/<CategorieController>
        [HttpPost]
        public async Task<Categorie> Post(CategorieCreateDto catedto)
        {

            return await _genericCRUDService.Add(catedto);
        }

        // PUT api/<CategorieController>/5
        [HttpPut("{id}")]
        public async Task<Categorie> Put(int id, CategorieCreateDto catedto)
        {
            return await _genericCRUDService.Update(id, catedto);
        }

        // DELETE api/<CategorieController>/5
        [HttpDelete("{id}")]
        public async Task<Categorie> Delete(int id)
        {
            return await _genericCRUDService.Delete(id);
        }
    }
}