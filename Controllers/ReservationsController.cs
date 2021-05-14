using System.Collections.Generic;
using AutoMapper;
using IIT.Clubs.Data;
using IIT.Clubs.Dtos;
using IIT.Clubs.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace IIT.Clubs.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReserverRepo _repository;
        private readonly IMapper _mapper;

        // inject dependency "_repository"
        public ReservationsController(IReserverRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //  private readonly MockIITRepo _repository = new MockIITRepo();

        [HttpGet]
        public ActionResult<IEnumerable<ReservationReadDto>> GetAllReservations()
        {
            var commandItems = _repository.GetAllReservations();
            return Ok(_mapper.Map<IEnumerable<ReservationReadDto>>(commandItems));
        }

        [HttpGet("{id}", Name = "GetReservationById")]
        public ActionResult<ReservationReadDto> GetReservationById(int id)
        {
            var commandItems = _repository.GetReservationById(id);
            if (commandItems != null)
            {
                return Ok(_mapper.Map<ReservationReadDto>(commandItems));
            }
            return NotFound();
        }

        //post api/commands
        [HttpPost]
        public ActionResult<ReservationCreateDto> CreateReservation(ReservationCreateDto reservationCreateDto)
        {
            var reservationModel = _mapper.Map<Reservation>(reservationCreateDto);
            _repository.CreateReservation(reservationModel);
            _repository.SaveChanges();

            var ReservationReadDto = _mapper.Map<ReservationReadDto>(reservationModel);

            return CreatedAtRoute(nameof(GetReservationById), new { id = ReservationReadDto.Id }, ReservationReadDto);
            //return Ok(CommandReadDto);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateReservation(int id, ReservationUpdateDto reservationUpdateDto)
        {
            var reservationModelFromRepo = _repository.GetReservationById(id);
            if (reservationModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(reservationUpdateDto, reservationModelFromRepo);
            
            _repository.UpdateReservation(reservationModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialReservationUpdate(int id, JsonPatchDocument<ReservationUpdateDto> patchDoc)
        {
            var reservationModelFromRepo = _repository.GetReservationById(id);
            if (reservationModelFromRepo == null)
            {
                return NotFound();
            }

            var reservationToPatch = _mapper.Map<ReservationUpdateDto>(reservationModelFromRepo);
            patchDoc.ApplyTo(reservationToPatch, ModelState);

            if(!TryValidateModel(reservationToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(reservationToPatch, reservationModelFromRepo);

            _repository.UpdateReservation(reservationModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteReservation(int id)
        {
            var reservationModelFromRepo = _repository.GetReservationById(id);
            if (reservationModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteReservation(reservationModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}