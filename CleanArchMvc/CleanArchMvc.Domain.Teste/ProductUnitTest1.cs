using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameterName_ResultObjectValidState()
        {
            //criação do objeto
            Action action = () => new Product("Product Name", "Description", 9.99m, 99, "Product Image");

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            //criação do objeto
            Action action = () => new Product(1, "Product Name", "Description", 9.99m, 99, "Product Image");

            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Description", 9.99m, 99,
                "Product Image");
            action.Should().Throw<DomainExceptionValidation>()
               .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Pe", "Description", 9.99m, 99, "Product Image");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characteres.");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            //criação do objeto
            Action action = () => new Product(1, "Product Name", "Description", 9.99m, 99, 
                "Product toooooooooooooooooooooooooooooooooooooooooo looooooooooooooooooooooooooooooooooooooooooooooooooooooooooong Imageeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid image, name, too long maximum 250 characteres.");
        }

        [Fact]
        public void CreateProduct_WithImageNull_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product Name", "Description", 9.99m, 99, null);

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithEmpetyImage_DomainExceptionInvalidId()
        {
            Action action = () => new Product(1, "Product Name", "Description", 9.99m, 99, "");

            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new Product(-1, "Product Name", "Description", -9.99m, 99, "Product Image");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid price value.");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(-1, "Product Name", "Description", 9.99m, value, "Product Image");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid stock value.");
        }
    }
}
