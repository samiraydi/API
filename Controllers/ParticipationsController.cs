/*using System.Collections.Generic;
using AutoMapper;
using IIT.Clubs.API.Data;
using IIT.Clubs.API.Models;
using IIT.Clubs.Data;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IIT.Clubs.Controllers
{
    [Route("api/participations")]
    [ApiController]
    public class ParticipationsController : ControllerBase
    {
        private readonly IParticipationRepo _repository;
        private readonly IMapper _mapper;

        // inject dependency "_repository"
        public ParticipationsController(IParticipationRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //  private readonly MockIITRepo _repository = new MockIITRepo();

        [HttpGet]
        public ActionResult<IEnumerable<ParticipationReadDto>> GetAllParticipations()
        {
            var commandItems = _repository.GetAllParticipations();
            return Ok(_mapper.Map<IEnumerable<ParticipationReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetParticipationById")]
        public ActionResult<ParticipationReadDto> GetParticipationById(int id)
        {
            var commandItems = _repository.GetParticipationById(id);
            if (commandItems != null)
            {
                return Ok(_mapper.Map<ParticipationReadDto>(commandItems));
            }
            return NotFound();
        }

        //post api/commands
        [HttpPost]
        public ActionResult<ParticipationCreateDto> CreateParticipation(ParticipationCreateDto participationCreateDto)
        {
            var participationModel = _mapper.Map<Participation>(participationCreateDto);
            _repository.CreateParticipation(participationModel);
            _repository.SaveChanges();

            var ParticipationReadDto = _mapper.Map<ParticipationReadDto>(participationModel);

            return CreatedAtRoute(nameof(GetParticipationById), new { id = ParticipationReadDto.Id }, ParticipationReadDto);
            //return Ok(CommandReadDto);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateParticipation(int id, ParticipationUpdateDto participationUpdateDto)
        {
            var participationModelFromRepo = _repository.GetParticipationById(id);
            if (participationModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(participationUpdateDto, participationModelFromRepo);
            
            _repository.UpdateParticipation(participationModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialParticipationUpdate(int id, JsonPatchDocument<ParticipationUpdateDto> patchDoc)
        {
            var participationModelFromRepo = _repository.GetParticipationById(id);
            if (participationModelFromRepo == null)
            {
                return NotFound();
            }

            var participationToPatch = _mapper.Map<ParticipationUpdateDto>(participationModelFromRepo);
            patchDoc.ApplyTo(participationToPatch, ModelState);

            if(!TryValidateModel(participationToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(participationToPatch, participationModelFromRepo);

            _repository.UpdateParticipation(participationModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteParticipation(int id)
        {
            var participationModelFromRepo = _repository.GetParticipationById(id);
            if (participationModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteParticipation(participationModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}*/