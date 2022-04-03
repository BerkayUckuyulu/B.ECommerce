using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Business.Concrete;
using System.Threading;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //attribute
    public class ProductsController : ControllerBase
    {
        //IoC Container--- Inversion of control
        IProductService _productService;

        public ProductsController(IProductService productService) //kontroler sen bir iproductservis bağımlısısın. loosely coupled
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            Thread.Sleep(1000);
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result.Message);

        }
        [HttpPost("add")]

        public IActionResult Add(Product product)
        
         {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int categoryId)
        {
            var result = _productService.GetAllByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }

}          
            
        

    

