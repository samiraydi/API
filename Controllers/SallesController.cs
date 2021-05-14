using System.Collections.Generic;
using AutoMapper;
using IIT.Clubs.Data;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IIT.Clubs.Controllers
{
    [Route("api/salles")]
    [ApiController]
    public class SallesController : ControllerBase
    {
        private readonly ISalleeRepo _repository;
        private readonly IMapper _mapper;

        // inject dependency "_repository"
        public SallesController(ISalleeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //  private readonly MockIITRepo _repository = new MockIITRepo();

        [HttpGet]
        public ActionResult<IEnumerable<SalleReadDto>> GetAllSalles()
        {
            var commandItems = _repository.GetAllSalles();
            return Ok(_mapper.Map<IEnumerable<SalleReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetSalleById")]
        public ActionResult<SalleReadDto> GetSalleById(int id)
        {
            var commandItems = _repository.GetSalleById(id);
            if (commandItems != null)
            {
                return Ok(_mapper.Map<SalleReadDto>(commandItems));
            }
            return NotFound();
        }

        //post api/commands
        [HttpPost]
        public ActionResult<SalleCreateDto> CreateSalle(SalleCreateDto salleCreateDto)
        {
            var salleModel = _mapper.Map<Salle>(salleCreateDto);
            _repository.CreateSalle(salleModel);
            _repository.SaveChanges();

            var SalleReadDto = _mapper.Map<SalleReadDto>(salleModel);

            return CreatedAtRoute(nameof(GetSalleById), new { id = SalleReadDto.Id }, SalleReadDto);
            //return Ok(CommandReadDto);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSalle(int id, SalleUpdateDto salleUpdateDto)
        {
            var salleModelFromRepo = _repository.GetSalleById(id);
            if (salleModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(salleUpdateDto, salleModelFromRepo);
            
            _repository.UpdateSalle(salleModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialSalleUpdate(int id, JsonPatchDocument<SalleUpdateDto> patchDoc)
        {
            var salleModelFromRepo = _repository.GetSalleById(id);
            if (salleModelFromRepo == null)
            {
                return NotFound();
            }

            var salleToPatch = _mapper.Map<SalleUpdateDto>(salleModelFromRepo);
            patchDoc.ApplyTo(salleToPatch, ModelState);

            if(!TryValidateModel(salleToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(salleToPatch, salleModelFromRepo);

            _repository.UpdateSalle(salleModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSalle(int id)
        {
            var salleModelFromRepo = _repository.GetSalleById(id);
            if (salleModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteSalle(salleModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}