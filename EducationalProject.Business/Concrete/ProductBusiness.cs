using EducationalProject.Business.Interface;
using System.Collections.Generic;
using EducationalProject.Repository.Entity;
using EducationalProject.Repository.Interface;
using EducationalProject.Utilities.Results;
using System;

namespace EducationalProject.Business.Concrete
{
    public class ProductBusiness : IProductBusiness
    {
        IProductRepository _productRepository;
        public ProductBusiness(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
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
                return new ErrorResult("Ürün Silinemedi");
            }
        }
        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }
        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _productRepository.GetAll(p => p.CategoryId == categoryId);
        }
        public IDataResult<Product> GetById(int productId)
        {
            var product = _productRepository.Get(p => p.ProductId == productId);

            if(product != null)
            {
            return new SuccessDataResult<Product>(product, "Ürün Getirildi");
            }
            return new ErrorDataResult<Product>(product, "Ürün Bulunamadı");
        }
        public IResult Update(Product product)
        {
            try
            {
                _productRepository.Update(product);
                return new SuccessResult("Ürün Güncellendi");
            }
            catch (Exception)
            {
                return new ErrorResult("Ürün Güncellenemedi");
            }
        }
    }
}
