using EducationalProject.Business.Interface;
using EducationalProject.Repository.Entity;
using EducationalProject.Repository.Interface;
using EducationalProject.Utilities.Logging;
using EducationalProject.Utilities.Results;
using System;
using System.Collections.Generic;

namespace EducationalProject.Business.Concrete
{


    public class ProductBusiness : IProductBusiness
    {
        IProductRepository _productRepository;
        public ProductBusiness(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [Log]
        public IResult Add(Product product)
        {
            try
            {
                _productRepository.Add(product);
                return new SuccessResult("Ürün Eklendi");
            }
            catch(Exception)
            {
                return new ErrorResult("Ürün Eklenmedi");
            }
        }
        [Log]
        public IResult Delete(int productId)
        {
            try
            {
                var product = _productRepository.Get(p => p.ProductId == productId);
                _productRepository.Delete(product);
                return new SuccessResult("Ürün Silindi");
            }
            catch (Exception)
            {
                return new ErrorResult("Ürün Silinmedi");
            }
        }
        [Log]
        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
        [Log]
        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _productRepository.GetAll(p => p.CategoryId == categoryId);
        }
        [Log]
        public IDataResult<Product> GetById(int productId)
        {
            var product = _productRepository.Get(p => p.ProductId == productId);

            if(product != null)
            {
            return new SuccessDataResult<Product>(product, "Ürün Getirildi");
            }
            return new ErrorDataResult<Product>(product, "Ürün Bulunamadı");
        }
        [Log]
        public IResult Update(Product product)
        {
            try
            {
                _productRepository.Update(product);
                return new SuccessResult("Ürün Güncellendi");
            }
            catch (Exception)
            {
                return new ErrorResult("Ürün Güncellenmedi");
            }
        }
    }
}
