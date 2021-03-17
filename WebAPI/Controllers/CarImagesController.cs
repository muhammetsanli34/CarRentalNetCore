using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("carimage/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
                
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId([FromForm(Name =("CarId"))] int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(file, carImage);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm(Name = ("Id"))] int Id)
        {
            var carImage = _carImageService.GetById(Id);
            var result = _carImageService.Update(file, carImage.Data);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int Id)
        {
            var carImage = _carImageService.GetById(Id);
            var result = _carImageService.Delete(carImage.Data);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
       
    }
}
