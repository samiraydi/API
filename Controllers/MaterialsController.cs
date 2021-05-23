using System.Collections.Generic;
using AutoMapper;
using IIT.Clubs.Data;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IIT.Clubs.Controllers
{
    [Route("api/materials")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialRepo _repository;
        private readonly IMapper _mapper;

        // inject dependency "_repository"
        public MaterialsController(IMaterialRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //  private readonly MockIITRepo _repository = new MockIITRepo();

        [HttpGet]
        public ActionResult<IEnumerable<MaterialReadDto>> GetAllMaterials()
        {
            var commandItems = _repository.GetAllMaterials();
            return Ok(_mapper.Map<IEnumerable<MaterialReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetMaterialById")]
        public ActionResult<MaterialReadDto> GetMaterialById(int id)
        {
            var commandItems = _repository.GetMaterialById(id);
            if (commandItems != null)
            {
                return Ok(_mapper.Map<MaterialReadDto>(commandItems));
            }
            return NotFound();
        }

        //post api/commands
        [HttpPost]
        public ActionResult<MaterialCreateDto> CreateMaterial(MaterialCreateDto materialCreateDto)
        {
            var materialModel = _mapper.Map<Material>(materialCreateDto);
            _repository.CreateMaterial(materialModel);
            _repository.SaveChanges();

            var MaterialReadDto = _mapper.Map<MaterialReadDto>(materialModel);

            return CreatedAtRoute(nameof(GetMaterialById), new { id = MaterialReadDto.Id }, MaterialReadDto);
            //return Ok(CommandReadDto);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMaterial(int id, MaterialUpdateDto materialUpdateDto)
        {
            var materialModelFromRepo = _repository.GetMaterialById(id);
            if (materialModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(materialUpdateDto, materialModelFromRepo);
            
            _repository.UpdateMaterial(materialModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialMaterialUpdate(int id, JsonPatchDocument<MaterialUpdateDto> patchDoc)
        {
            var materialModelFromRepo = _repository.GetMaterialById(id);
            if (materialModelFromRepo == null)
            {
                return NotFound();
            }

            var materialToPatch = _mapper.Map<MaterialUpdateDto>(materialModelFromRepo);
            patchDoc.ApplyTo(materialToPatch, ModelState);

            if(!TryValidateModel(materialToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(materialToPatch, materialModelFromRepo);

            _repository.UpdateMaterial(materialModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteMaterial(int id)
        {
            var materialModelFromRepo = _repository.GetMaterialById(id);
            if (materialModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteMaterial(materialModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}