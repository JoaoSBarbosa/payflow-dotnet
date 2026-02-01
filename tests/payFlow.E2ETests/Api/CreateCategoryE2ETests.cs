using FluentAssertions;
using payFlow.Application.Categories.DTOs.Requests;
using payFlow.Application.Categories.DTOs.Response;
using payFlow.E2ETests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace payFlow.E2ETests.Api
{
    public class CreateCategoryE2ETests: IClassFixture<PayFlowApiFactory>
    {
        private readonly HttpClient _httpClient;

        public CreateCategoryE2ETests(PayFlowApiFactory factory)
        {
            _httpClient = factory.CreateClient();
        }
        [Fact]
        public async Task POST_Category_Should_Create_Category()
        {
            var request = new CreateCategory("Alimentação", "Categoria de gastos", "usuario@teste.com");


            var response = await _httpClient.PostAsJsonAsync("/v1/categories", request);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var body = await response.Content.ReadFromJsonAsync<CategoryResponse>();
            body!.Title.Should().Be("Alimentação");

        }
    }
}
