using System.Threading.Tasks;
using OceanStar.Argus.Models.TokenAuth;
using OceanStar.Argus.Web.Controllers;
using Shouldly;
using Xunit;

namespace OceanStar.Argus.Web.Tests.Controllers
{
    public class HomeController_Tests: ArgusWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}