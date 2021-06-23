using System.Collections.Generic;
using AutoMapper;
using IIT.Clubs.Data;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IIT.Clubs.Controllers
{
 
    [Route("api/Evennements")]
    [ApiController]
    public class EvennementsController : ControllerBase
    {
        private readonly IEvennementeRepo _repository;
        private readonly IMapper _mapper;

        // inject dependency "_repository"
        public EvennementsController(IEvennementeRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //  private readonly MockIITRepo _repository = new MockIITRepo();

        [HttpGet]
        public ActionResult<IEnumerable<EvennementReadDto>> GetAllEvennements()
        {
            var commandItems = _repository.GetAllEvennements();
            return Ok(_mapper.Map<IEnumerable<EvennementReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetEvennementById")]
        public ActionResult<EvennementReadDto> GetEvennementById(int id)
        {
            var commandItems = _repository.GetEvennementById(id);
            if (commandItems != null)
            {
                return Ok(_mapper.Map<EvennementReadDto>(commandItems));
            }
            return NotFound();
        }

/// <summary>
/// Créer un évennement
/// </summary>
/// <remarks>
/// Sample request:
///
///     POST /evennement
///     {
///        "id": 1,
///        "name": "Item1",
///        "isComplete": true
///     }
///
/// </remarks>
/// <param name="item"></param>
/// <returns>A newly created TodoItem</returns>
/// <response code="201">Returns the newly created item</response>
/// <response code="400">If the item is null</response> 
        [HttpPost]
        public ActionResult<EvennementCreateDto> CreateEvennement(EvennementCreateDto EvennementCreateDto)
        {
            var EvennementModel = _mapper.Map<Evennement>(EvennementCreateDto);
            _repository.CreateEvennement(EvennementModel);
            _repository.SaveChanges();

            var EvennementReadDto = _mapper.Map<EvennementReadDto>(EvennementModel);

            return CreatedAtRoute(nameof(GetEvennementById), new { id = EvennementReadDto.Id }, EvennementReadDto);
            //return Ok(CommandReadDto);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateEvennement(int id, EvennementUpdateDto EvennementUpdateDto)
        {
            var EvennementModelFromRepo = _repository.GetEvennementById(id);
            if (EvennementModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(EvennementUpdateDto, EvennementModelFromRepo);
            
            _repository.UpdateEvennement(EvennementModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialEvennementUpdate(int id, JsonPatchDocument<EvennementUpdateDto> patchDoc)
        {
            var EvennementModelFromRepo = _repository.GetEvennementById(id);
            if (EvennementModelFromRepo == null)
            {
                return NotFound();
            }

            var EvennementToPatch = _mapper.Map<EvennementUpdateDto>(EvennementModelFromRepo);
            patchDoc.ApplyTo(EvennementToPatch, ModelState);

            if(!TryValidateModel(EvennementToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(EvennementToPatch, EvennementModelFromRepo);

            _repository.UpdateEvennement(EvennementModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteEvennement(int id)
        {
            var EvennementModelFromRepo = _repository.GetEvennementById(id);
            if (EvennementModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteEvennement(EvennementModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}