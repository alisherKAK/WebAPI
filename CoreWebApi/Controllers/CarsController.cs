using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain.DTO;
using Domain.Models;
using Domain.Resources;
using Domain.Responses;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly IService<Car, CarDTO, CarResource, CarResponse> _serviceCar;
        private readonly IMapper _mapper;
        public CarsController(IService<Car, CarDTO, CarResource, CarResponse> serviceCar, IMapper mapper)
        {
            _serviceCar = serviceCar;
            _mapper = mapper;
        }

        [HttpGet]
        public List<CarResource> GetAll()
        {
            return _serviceCar.GetAll().ToList();
        }
        [HttpGet("{id}")]
        public CarResource Get(int id)
        {
            return _serviceCar.Get(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]CarResource carResource)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            var carDto = _mapper.Map<CarDTO>(carResource);
            var response = _serviceCar.Add(carDto);

            if (response.IsSuccess)
                return Ok(response.Object);

            return BadRequest(response.ErrorMessage);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] CarResource carResource)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var carDto = _mapper.Map<CarDTO>(carResource);
            carDto.Id = id;
            var response = _serviceCar.Update(carDto);

            if(response.IsSuccess)
                return Ok(response.Object);

            return BadRequest(response.ErrorMessage);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var response = _serviceCar.Delete(id);

            if(response.IsSuccess)
                return Ok(response.Object);

            return BadRequest(response.ErrorMessage);
        }
    }
}