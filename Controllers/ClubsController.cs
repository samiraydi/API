using System.Collections.Generic;
using AutoMapper;
using IIT.Clubs.Data;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IIT.Clubs.Controllers
{
    [Route("api/Clubs")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IClubeRepo _repository;
        private readonly IMapper _mapper;

        // inject dependency "_repository"
        public ClubsController(IClubeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //  private readonly MockIITRepo _repository = new MockIITRepo();

        [HttpGet]
        public ActionResult<IEnumerable<ClubReadDto>> GetAllClubs()
        {
            var commandItems = _repository.GetAllClubs();
            return Ok(_mapper.Map<IEnumerable<ClubReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetClubById")]
        public ActionResult<ClubReadDto> GetClubById(int id)
        {
            var commandItems = _repository.GetClubById(id);
            if (commandItems != null)
            {
                return Ok(_mapper.Map<ClubReadDto>(commandItems));
            }
            return NotFound();
        }

        //post api/commands
        [HttpPost]
        public ActionResult<ClubCreateDto> CreateClub(ClubCreateDto clubCreateDto)
        {
            var clubModel = _mapper.Map<Club>(clubCreateDto);
            _repository.CreateClub(clubModel);
            _repository.SaveChanges();

            var ClubReadDto = _mapper.Map<ClubReadDto>(clubModel);

            return CreatedAtRoute(nameof(GetClubById), new { id = ClubReadDto.Id }, ClubReadDto);
            //return Ok(CommandReadDto);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateClub(int id, ClubUpdateDto clubUpdateDto)
        {
            var clubModelFromRepo = _repository.GetClubById(id);
            if (clubModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(clubUpdateDto, clubModelFromRepo);
            
            _repository.UpdateClub(clubModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialClubUpdate(int id, JsonPatchDocument<ClubUpdateDto> patchDoc)
        {
            var clubModelFromRepo = _repository.GetClubById(id);
            if (clubModelFromRepo == null)
            {
                return NotFound();
            }

            var clubToPatch = _mapper.Map<ClubUpdateDto>(clubModelFromRepo);
            patchDoc.ApplyTo(clubToPatch, ModelState);

            if(!TryValidateModel(clubToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(clubToPatch, clubModelFromRepo);

            _repository.UpdateClub(clubModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteClub(int id)
        {
            var clubModelFromRepo = _repository.GetClubById(id);
            if (clubModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteClub(clubModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}