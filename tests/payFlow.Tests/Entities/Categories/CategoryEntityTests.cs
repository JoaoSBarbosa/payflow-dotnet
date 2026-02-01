using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using payFlow.Core.Commons.ExceptionsMessage;
using payFlow.Core.Exceptions;
using payFlow.Core.Models;
using Xunit.Abstractions;

namespace payFlow.Tests.Entities.Categories
{
    [Collection(nameof(CategoryTestFixtureCollection))]
    public class CategoryEntityTests(CategoryTestFixture fixture, ITestOutputHelper output)
    {
        private readonly CategoryTestFixture _fixture = fixture;
        private readonly ITestOutputHelper _output = output;


        [Fact]
        [Trait("Categoria", "Entidade - Deve criar categoria quando dados validos")]
        public void Should_Create_Category_With_Valid_Data()
        {
            var category = _fixture.GetValidCategory();

            category.Should().NotBeNull();
            category.Title.Should().NotBeNullOrWhiteSpace();
            category.Description.Should().NotBeNullOrWhiteSpace();
            category.UserId.Should().NotBeNullOrWhiteSpace();

        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [Trait("Categoria", "Entidade - Deve lançar exceção quando nome inválido")]
        public void Should_Throw_Exception_When_Name_Is_Invalid( string title)
        {
            Action action = () => new Category(title, _fixture.GetValidUserId(), _fixture.GetValidDescription());
            action.Should().Throw<DomainException>().WithMessage(CategoryExceptionMessage.FieldNullExceptionMessage("Titulo"));
            _output.WriteLine("Exceção DomainException validada com sucesso");

        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [Trait("Categoria", "Entidade - Deve lançar exceção quando email do usuario inválido")]
        public void Should_Throw_Exception_When_UserId_Is_Invalid(string email)
        {
            Action action = () => new Category(_fixture.GetValidName(), email, _fixture.GetValidDescription());
            action.Should().Throw<DomainException>().WithMessage(CategoryExceptionMessage.FieldNullExceptionMessage("E-mail de usuário"));
            _output.WriteLine("Exceção DomainException validada com sucesso");

        }
    }
}
