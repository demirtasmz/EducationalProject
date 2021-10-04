using System.Collections.Generic;
using EducationalProject.Business.Interface;
using EducationalProject.Repository.Entity;
using EducationalProject.WebApi.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace EducationalProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        //[Log]
        public void Update(Product product)
        {
            _productBusiness.Update(product);
        }

        [HttpDelete]
        [Route("Delete/{productId}")]
       // [Log]
        public void Delete(int productid)
        {
            _productBusiness.Delete(productid);
        }
    }
}