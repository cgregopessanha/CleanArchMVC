using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category Whith Valid State")]
        public void CreateCatogory_WhithValidParameters_ResultObjectValidState()
        {
            //Ação de Criar uma categoria
            Action action = () => new Category(1, "Category Name");

            //Ação deverá NÃO LANÇAR DomainExceptionValidation;
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation >();
        }

        [Fact(DisplayName = "Create Category Whith Negative Value")]
        public void CreateCatogory_NegativeIdValue_DomainExceptionValidation()
        {
            //Ação de Criar uma categoria com um id negativo
            Action action = () => new Category(-1, "Category Name");

            //Ação deverá lançar DomainExceptionValidation;
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid ID!");
        }

        [Fact(DisplayName = "Create Category Whith Less than 3 caracters")]
        public void CreateCategory_ShortNameValue_DomainExceptionValidation()
        {
            //Ação de Criar uma categoria com um nome com menos de 3 caracteres
            Action action = () => new Category(1, "Ca");

            //Ação deverá lançar DomainExceptionValidation;
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Name. Too Short! Name Must have 3 Characters at least!");
        }

        [Fact(DisplayName = "Create Category Whith Missing Name Value")]
        public void CreateCategory_MissingNameValue_DomainExceptionValidation()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Name. Name is Required!");
        }

    }
}
