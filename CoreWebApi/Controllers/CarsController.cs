﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain.DTO;
using Domain.Models;
using Domain.Resources;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly IService<Car, CarDTO, CarResource> _serviceCar;
        private readonly IMapper _mapper;
        public CarsController(IService<Car, CarDTO, CarResource> serviceCar, IMapper mapper)
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
            _serviceCar.Add(carDto);

            return Ok();
        }
        [HttpPut("{id?}")]
        public IActionResult Put(int? id,[FromBody] CarResource carResource)
        {
            if (!ModelState.IsValid && id != 0)
            {
                return NotFound();
            }

            var carDto = _mapper.Map<CarDTO>(carResource);
            carDto.Id = (int)id;
            _serviceCar.Update(carDto);

            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _serviceCar.Delete(id);
            return Ok();
        }
    }
}