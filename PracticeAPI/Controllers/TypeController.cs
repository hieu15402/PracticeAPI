using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeAPI.Entity;
using PracticeAPI.Model;
using PracticeAPI.Repository;

namespace PracticeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeRepository _repo;
        private readonly IMapper _mapper;

        public TypeController(ITypeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCafe()
        {
            var types = await _repo.GetAllTypeAsync();
            if (types == null)
            {
                return NotFound();
            }
            return Ok(types);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTypeById(int id)
        {
            var type = await _repo.GetTypeById(id);
            if (type == null)
            {
                return NotFound();
            }
            return Ok(type);
        }
        [HttpPost]
        public async Task<IActionResult> AddType(TypeModel type)
        {
            var typeEntity = _mapper.Map<TypeEntity>(type);
            var id = await _repo.AddType(typeEntity);
            return Ok(id);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateType(int id, TypeEntity type)
        {
            if (id == type.TypeId)
            {
                await _repo.UpdateType(id, type);
                return Ok(id);
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteType(int id)
        {
            var type = await _repo.GetTypeById(id);
            if (type == null)
            {
                return NotFound();
            }
            await _repo.DeleteType(id);
            return Ok();
        }
    }
}
