using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using payFlow.Application.Categories.DTOs.Requests;
using payFlow.Application.Categories.Services;
using payFlow.Infra.Repositories;
using payFlow.Infra.Repositories.UnitOfWork;
using payFlow.IntegrationTests.Common;

namespace payFlow.IntegrationTests.Application.Categories
{
    public class CreateCategoryIntegrationTests : IntegrationTestBase
    {

        [Fact]
        [Trait("Integração", "Categoria")]
        public async Task CreateCategory_Should_Persist_In_Database()
        {
            using var context = CreateDbContext();

            var repository = new CategoryRepository(context);
            var unitOfWork = new UnitOfWork(context);
            var service = new CategoryService(repository, unitOfWork);

            var request = new CreateCategory("Alimentação", "Categoria de gastos", "usuario@teste.com");

            var response = await service.CreateCategory(request);

            response.Should().NotBeNull();
            response.Id.Should().BeGreaterThan(0);

            var categoryInDb = await context.Categories.FirstAsync();

            categoryInDb.Title.Should().Be("Alimentação");
            categoryInDb.UserId.Should().Be("usuario@teste.com");
            categoryInDb.Description.Should().Be("Categoria de gastos");



        }
    }
}
