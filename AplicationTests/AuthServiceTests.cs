using Moq;
using Xunit;
using Infra.Repositories;
using Domain.Interfaces;
using Domain.Entities;
using Aplication.Services;

namespace AplicationTests

{
    public class AuthServiceTests
    {
        //[Fact]
        //public void Authenticate_ShouldReturnUser_WhenCredentialsAreValid()
        //{

        //    var mockRepository = new Mock<IUserRepository>();
        //    // Arrange (Configuração do teste)
        //    mockRepository.Setup(repo => repo.GetByEmail("user@example.com"))
        //            .ReturnsAsync(new TbUser { Id = 1, Email = "user@example.com", Password = "hashedpassword" });


        //    var authService = new UserService(mockRepository.Object);

        //    // Act (Execução da ação que será testada)
        //    //var result = authService.authService("user@example.com", "password123");

        //    // Assert (Verificação do resultado esperado)
        //    Assert.NotNull(result);
        //    Assert.Equal("user@example.com", result.Email);
        //}
    }


}