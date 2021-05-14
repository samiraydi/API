using System.Collections.Generic;
using AutoMapper;
using IIT.Clubs.Data;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IIT.Clubs.Controllers
{
    [Route("api/Personne")]
    [ApiController]
    public class PersonneController : ControllerBase
    {
        private readonly IPersonneRepo _repository;
        private readonly IMapper _mapper;

        // inject dependency "_repository"
        public PersonneController(IPersonneRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //  private readonly MockIITRepo _repository = new MockIITRepo();

        [HttpGet]
        public ActionResult<IEnumerable<PersonneReadDto>> GetAllPersonne()
        {
            var commandItems = _repository.GetAllPersonne();
            return Ok(_mapper.Map<IEnumerable<PersonneReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetPersonneById")]
        public ActionResult<PersonneReadDto> GetPersonneById(int id)
        {
            var commandItems = _repository.GetPersonneById(id);
            if (commandItems != null)
            {
                return Ok(_mapper.Map<PersonneReadDto>(commandItems));
            }
            return NotFound();
        }

        //post api/commands
        [HttpPost]
        public ActionResult<PersonneCreateDto> CreatePersonne(PersonneCreateDto personneCreateDto)
        {
            var personneModel = _mapper.Map<Personne>(personneCreateDto);
            _repository.CreatePersonne(personneModel);
            _repository.SaveChanges();

            var PersonneReadDto = _mapper.Map<PersonneReadDto>(personneModel);

            return CreatedAtRoute(nameof(GetPersonneById), new { id = PersonneReadDto.Id }, PersonneReadDto);
            //return Ok(CommandReadDto);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdatePersonne(int id, PersonneUpdateDto PersonneUpdateDto)
        {
            var PersonneModelFromRepo = _repository.GetPersonneById(id);
            if (PersonneModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(PersonneUpdateDto, PersonneModelFromRepo);

            _repository.UpdatePersonne(PersonneModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialPersonneUpdate(int id, JsonPatchDocument<PersonneUpdateDto> patchDoc)
        {
            var PersonneModelFromRepo = _repository.GetPersonneById(id);
            if (PersonneModelFromRepo == null)
            {
                return NotFound();
            }

            var PersonneToPatch = _mapper.Map<PersonneUpdateDto>(PersonneModelFromRepo);
            patchDoc.ApplyTo(PersonneToPatch, ModelState);

            if (!TryValidateModel(PersonneToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(PersonneToPatch, PersonneModelFromRepo);

            _repository.UpdatePersonne(PersonneModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeletePersonne(int id)
        {
            var PersonneModelFromRepo = _repository.GetPersonneById(id);
            if (PersonneModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeletePersonne(PersonneModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}