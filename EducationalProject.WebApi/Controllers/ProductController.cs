using EducationalProject.Business.Interface;
using EducationalProject.Repository.Entity;
using EducationalProject.WebApi.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EducationalProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        IProductBusiness _productBusiness;

        public ProductController(IProductBusiness productBusiness)
        {
            _productBusiness = productBusiness;
        }

        [HttpGet]
        [Route("GetAll")]
        [Log]
        public List<Product> GetAll()
        {
            return _productBusiness.GetAll();
        }

        [HttpGet]
        [Route("GetByCategoryId/{categoryId}")]
        [Log]
        public List<Product> GetByCategoryId(int categoryId)
        {
            return _productBusiness.GetAllByCategoryId(categoryId);
        }

        [HttpGet]
        [Route("GetById/{productId}")]
        [Log]
        public IActionResult GetByID(int productId)
        {
            var result = _productBusiness.GetById(productId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Route("Add")]
        [Log]
        public IActionResult Add(Product product)
        {
            var result = _productBusiness.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut]
        [Route("Update")]
        [Log]
        public IActionResult Update(Product product)
        {
            var result = _productBusiness.Update(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        [Route("Delete/{productId}")]
        [Log]
        public IActionResult Delete(int productid)
        {
            var result = _productBusiness.Delete(productid);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}