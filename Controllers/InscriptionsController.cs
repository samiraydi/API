using System.Collections.Generic;
using AutoMapper;
using IIT.Clubs.Services;
using IIT.Clubs.Data;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IIT.Clubs.Controllers
{
    [Route("api/inscriptions")]
    [ApiController]
    public class InscriptionsController : ControllerBase
    {
        private readonly IInscriptioneRepo _repository;
        private readonly IMapper _mapper;
        private readonly IAuthentification _authentification;

        // inject dependency "_repository"
        public InscriptionsController(IInscriptioneRepo repository, IMapper mapper, IAuthentification authentification)
        {
            _repository = repository;
            _mapper = mapper;
            _authentification = authentification;
        }
        //  private readonly MockIITRepo _repository = new MockIITRepo();

        [HttpGet]
        public ActionResult<IEnumerable<InscriptionReadDto>> GetAllInscriptions()
        {
            var commandItems = _repository.GetAllInscriptions();
            return Ok(_mapper.Map<IEnumerable<InscriptionReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetInscriptionById")]
        public ActionResult<InscriptionReadDto> GetInscriptionById(int id)
        {
            var commandItems = _repository.GetInscriptionById(id);
            if (commandItems != null)
            {
                return Ok(_mapper.Map<InscriptionReadDto>(commandItems));
            }
            return NotFound();
        }

        //post api/commands
        [HttpPost]
        public ActionResult<InscriptionCreateDto> CreateInscription(InscriptionCreateDto inscriptionCreateDto)
        {
            var inscriptionModel = _mapper.Map<Inscription>(inscriptionCreateDto);
            _repository.CreateInscription(inscriptionModel);
            _repository.SaveChanges();

            var InscriptionReadDto = _mapper.Map<InscriptionReadDto>(inscriptionModel);

            return CreatedAtRoute(nameof(GetInscriptionById), new { id = InscriptionReadDto.Id }, InscriptionReadDto);
            //return Ok(CommandReadDto);
        }

        [Route("api/inscriptions/Authetifier")]
        [HttpPost]
        public ActionResult<InscriptionCreateDto> Authentifier (AuthentificateRequest request)
        {

            bool auth = false;
            auth = _authentification.Authentifier(request);

         
            return Ok(auth);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateInscription(int id, InscriptionUpdateDto inscriptionUpdateDto)
        {
            var inscriptionModelFromRepo = _repository.GetInscriptionById(id);
            if (inscriptionModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(inscriptionUpdateDto, inscriptionModelFromRepo);
            
            _repository.UpdateInscription(inscriptionModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialInscriptionUpdate(int id, JsonPatchDocument<InscriptionUpdateDto> patchDoc)
        {
            var inscriptionModelFromRepo = _repository.GetInscriptionById(id);
            if (inscriptionModelFromRepo == null)
            {
                return NotFound();
            }

            var inscriptionToPatch = _mapper.Map<InscriptionUpdateDto>(inscriptionModelFromRepo);
            patchDoc.ApplyTo(inscriptionToPatch, ModelState);

            if(!TryValidateModel(inscriptionToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(inscriptionToPatch, inscriptionModelFromRepo);

            _repository.UpdateInscription(inscriptionModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteInscription(int id)
        {
            var inscriptionModelFromRepo = _repository.GetInscriptionById(id);
            if (inscriptionModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteInscription(inscriptionModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}