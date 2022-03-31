using EducationalProject.Repository.Abstract;
using System.ComponentModel.DataAnnotations;

namespace EducationalProject.Repository.Entity
{
    public class Product : IEntity
    {
        //[Required(ErrorMessage = "ID is required")]
        //[DataType(DataType.MultilineText)]
        public int ProductId { get; set; }
        //[DataType(DataType.Text)]
        public int CategoryId { get; set; }
        [CustomValidation(typeof(OnlyStringValidation), nameof(OnlyStringValidation.StringValidate))]

        public string ProductName { get; set; }
        //[DataType(DataType.PostalCode)]

        public short UnitsinStock { get; set; }

        public decimal UnitPrice { get; set; }
    }
    public class OnlyStringValidation
    {
        public static ValidationResult StringValidate(object test)
        {
            string str = string.Empty;
            return test.GetType() == str.GetType()
                ? ValidationResult.Success
                : new ValidationResult("The type of the parameter isn't valid");
        }
    }
}
