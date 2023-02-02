using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidStrate()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameterName_ResultObjectValidStrate()
        {
            Action action = () => new Category("Category Name");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalid()
        {
            Action action = () => new Category(-1, "Category Name");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");                
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExcpetionInvalidName()
        {
            Action action = () => new Category(1, "");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "ms");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characteres");
        }
    }
}