using System;
using EducationalProject.Repository.Entity;
using FluentValidation;

namespace EducationalProject.WebApi.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotNull().WithMessage("Ürün ismi boş olamaz.");
            RuleFor(x => x.ProductName).Length(2,25).WithMessage("Ürün ismi 2 ile 25 karakter arasında olmalı.");
            RuleFor(x => x.UnitPrice).NotNull().WithMessage("Fiyat giriniz.");
            RuleFor(x => x.UnitsinStock).NotNull().WithMessage("Stok adedi giriniz.");
            RuleFor(x => x.CategoryId).NotNull().WithMessage("Kategori belirtiniz..");
        }
    }
}
