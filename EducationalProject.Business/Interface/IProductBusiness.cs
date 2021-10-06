using System.Collections.Generic;
using EducationalProject.Repository.Entity;
using EducationalProject.Utilities.Results;

namespace EducationalProject.Business.Interface
{
    public interface IProductBusiness
    {
        List<Product> GetAll();

        IDataResult<Product> GetById(int productId);

        List<Product> GetAllByCategoryId(int categoryId);

        IResult Add(Product product);

        IResult Update(Product product);

        IResult Delete(int productId);


    }
}
