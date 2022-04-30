using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product("Television", "50' - Panasonic", 799.99M, 10, "asfadfsdfsf");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Theory(DisplayName = "Create a Product With Negative Id")]
        [InlineData(-1)]
        //Para passar um parâmetro através do método se usa a anotação THEORY, juntamente com a anotação INLINEDATA passando o parâmetro;
        public void CreateProduct_WithNegativeIdValue_DomainExceptionvalidation(int value)
        {
            Action action = () => new Product(value, "Television", "50' - Panasonic", 799.99M, 10, "asfadfsdfsf");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id Value!");
        }

        [Fact(DisplayName = "Create a Product With Invalid Name")]
        public void CreteProduct_WithInvalidName_DomainExceptionValidation()
        {
            Action action = () => new Product(1, null, "50' - Panasonic", 799.99M, 10, "asfadfsdfsf");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Name. Name is Required!");
        }

        [Fact(DisplayName = "Create a Product Name With less than 3 caracters")]
        public void CreateProduct_TooShortName_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "TV", "50' - Panasonic", 799.99M, 10, "asfadfsdfsf");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Name. Too Short! Name Must have 3 Characters at least!");
        }

        [Fact(DisplayName = "Create a Product with Null or Empty description")]
        public void CreateProduct_WithNullOrEmptyDescription_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Television", null, 799.99M, 10, "asfadfsdfsf");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Description. Description is Required!");
        }

        [Fact(DisplayName = "Create a Product With Too Short Description")]
        public void CreateProduct_WithTooShortDescripton_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Television", "tv50", 799.99M, 10, "asfadfsdfsf");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Description. Too Short! Description Must have 5 Characters at least!");
        }

        [Theory(DisplayName = "Create a Product With Negative Price")]
        [InlineData(-0.1)]
        public void CreateProduct_NegativePrice_DomainExceptionValidation(decimal value)
        {
            Action action = () => new Product(1, "Television", "50' - Panasonic", value, 10, "asfadfsdfsf");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Price Value.");
        }

        [Theory(DisplayName = "Create a Product with Invalid Stock value ")]
        [InlineData(-1)]
        public void CreateProduct_InvalidStock_DomainExceptionValidation(int value)
        {
            Action action = () => new Product(1, "Television", "50' - Panasonic", 799.99M, value, "asfadfsdfsf");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Stock Value.");
        }

        [Fact(DisplayName = "Create a Product With Image Name more than 250 caracters")]
        public void CreateProduct_TooLongImageName_DomainExceptionValidation()
        {
            Action action = () => new Product(1, "Television", "50' - Panasonic", 799.99M, 1, "ssfgfgdhdbdfbfdbdfbdfbdfbdfbdfbdfbdsbsdbggsdbdbdbknebonebnebnenboenfbonefbuneofbnefnboefnbvoefnboefnvbejnfvbjofeboenfbjnefojbnefojbneofnbvoejfnvoejfnvojenvoenvoefvnwoekfvnoefjkvnoefjknvoefkjnvoefkjnvoefknvoefnvoefnvoefnvoenfvojneovnefjvnoefjnvoefjvnoe1");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Image Name. Too Long! Maximum have 250 Characters!");
        }

        [Fact(DisplayName = "Create a Product With Null Image Name")]
        //PADRÃO DO NOME DO MÈTODO: O que deve ser feito + _critério_ + O que é esperado;
        public void CreateProduct_WithNullImageName_NoDomainValidation()
        {
            Action action = () => new Product(1, "Television", "50' - Panasonic", 799.99M, 1, null);

            //Não deve lançar uma exceção, pois eu posso ter um produto sem imagem, ou atribuir depois.
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create a Product With Null Image Name")]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Television", "50' - Panasonic", 799.99M, 1, null);

            //Não deve lançar uma exceção, pois eu posso ter um produto sem imagem, ou atribuir depois.
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Create a Product With Empty Image Name")]
        //PADRÃO DO NOME DO MÈTODO: O que deve ser feito + _critério_ + O que é esperado;
        public void CreateProduct_WithEmptyImageName_NoDomainValidation()
        {
            Action action = () => new Product(1, "Television", "50' - Panasonic", 799.99M, 1, "");
            //Não deve lançar uma exceção, pois eu posso ter um produto sem imagem, ou atribuir depois.
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
