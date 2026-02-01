using payFlow.Core.Models;
using payFlow.Tests.Commons;

namespace payFlow.UnitTests.Entities.Categories.Fixtures
{
    public class CategoryTestFixture : BaseFixture
    {

        public string GetValidName()
        {
            var name = string.Empty;

            while (name.Length < 3) name = Faker.Commerce.Categories(1)[0];
            return name.Length > 255 ? name[..255] : name;
        }

        public string GetValidDescription()
        {
            var description = string.Empty;
            while (description.Length < 3) description = Faker.Commerce.ProductDescription();
            return description.Length > 255 ? description[..255] : description;
        }

        public string GetValidUserId() => Faker.Internet.Email();

        public Category GetValidCategory() => new(GetValidName(), GetValidUserId(), GetValidDescription());

      
    }
}
