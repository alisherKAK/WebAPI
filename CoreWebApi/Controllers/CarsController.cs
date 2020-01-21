using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly IRepository<Car> _repositoryCar;
        public CarsController(IRepository<Car> repositoryCar)
        {
            _repositoryCar = repositoryCar;
        }

        [HttpGet]
        public List<Car> GetAll()
        {
            return _repositoryCar.GetAll().ToList();
        }
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            return _repositoryCar.Get(id);
        }
    }
}