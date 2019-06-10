using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Services;
using Business.Utils;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IBusinessService _iBusinessService;

        public ProductController(IBusinessService iBusinessService)
        {
            _iBusinessService = iBusinessService;
        }

        // GET api/product
        [HttpGet]
        [Authorize(Policy = PermissionRegister.GetProduct)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var listProduct = _iBusinessService.GetAllProduct();
            return Ok(listProduct);
        }

        // GET api/product/5
        [HttpGet("{id}")]
        [Authorize(Policy = PermissionRegister.GetProduct)]
        public IActionResult Get(int id)
        {
            var product = _iBusinessService.GetProductById(id);
            return Ok(product);
        }

        // POST api/product
        [HttpPost]
        [Authorize(Policy = PermissionRegister.AddProduct)]
        public IActionResult Post([FromBody] Product product)
        {
            var result = _iBusinessService.AddProduct(product);
            return Ok(result);
        }

        // PUT api/product/5
        [HttpPut]
        [Authorize(Policy = PermissionRegister.UpdateProduct)]
        public IActionResult Put([FromBody] Product product)
        {
            var result = _iBusinessService.UpdateProduct(product);
            return Ok(result);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PermissionRegister.DeleteProduct)]
        public IActionResult Delete(int id)
        {
            var result = _iBusinessService.DeleteProductById(id);
            return Ok(result);
        }
    }
}
