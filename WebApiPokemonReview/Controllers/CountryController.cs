using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApiPokemonReview.Dto;
using WebApiPokemonReview.Interfaces;
using WebApiPokemonReview.Models;

namespace WebApiPokemonReview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController(ICountryRepository countryRepository, IMapper mapper) : ControllerBase
    {
        private readonly ICountryRepository _countryRepository = countryRepository;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<CountryDto>))]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetCountries()
        {
            try
            {
                var countries = _mapper.Map<List<CountryDto>>(_countryRepository.GetCountries());
                return Ok(countries);
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode((int)HttpStatusCode.InternalServerError, ModelState);
            }
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CountryDto))]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetCategory(int countryId)
        {
            if (_countryRepository.CountryExists(countryId))
                return NotFound();

            try
            {
                var country = _mapper.Map<CountryDto>(_countryRepository.GetCountry(countryId)!);
                return Ok(country);
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode((int)HttpStatusCode.InternalServerError, ModelState);
            }
        }

        [HttpGet("/owners/{ownerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<CountryDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetCountryByOwner(int ownerId)
        {
            var country = _mapper.Map<CountryDto>(
                _countryRepository.GetCountryByOwner(ownerId)!);

            if (!ModelState.IsValid) return BadRequest();

            return Ok(country);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult CreateCountry([FromBody] CountryDto countryCreate)
        {
            if (countryCreate == null) return BadRequest(ModelState);

            if (_countryRepository.GetCountries().Any(c => string.Equals(c.Name.Trim(), countryCreate.Name.TrimEnd(), StringComparison.OrdinalIgnoreCase)))
            { 
                ModelState.AddModelError("", "Category already exists");
                return StatusCode((int)HttpStatusCode.UnprocessableEntity, ModelState);
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var countryMap = _mapper.Map<Country>(countryCreate);

            try
            {
                _countryRepository.CreateCountry(countryMap);
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode((int)HttpStatusCode.InternalServerError, ModelState);
            }

            return NoContent();
        }

        [HttpPut("{countryId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult UpdateCountry(int countryId, [FromBody] CountryDto updatedCountry)
        {
            if (updatedCountry == null) return BadRequest(ModelState);

            if (countryId != updatedCountry.Id)
                return BadRequest(ModelState);

            if (_countryRepository.CountryExists(countryId)) return NotFound();

            if (!ModelState.IsValid) return BadRequest();

            var countryMap = _mapper.Map<Country>(updatedCountry);

            try
            {
                _countryRepository.UpdateCountry(countryMap);
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong updating country");
                return StatusCode((int)HttpStatusCode.InternalServerError, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{countryId}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult DeleteCountry(int countryId)
        {
            if (_countryRepository.CountryExists(countryId))
                return NotFound();

            var countryToDelete = _countryRepository.GetCountry(countryId)!;

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _countryRepository.DeleteCountry(countryToDelete);
            }
            catch
            {
                ModelState.AddModelError("", "Something went wrong deleting country");
                return StatusCode((int)HttpStatusCode.InternalServerError, ModelState);
            }

            return NoContent();
        }
    }
}
