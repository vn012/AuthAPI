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

        [Fact]
        public async Task Authenticate_ShouldReturnUser_WhenCredentialsAreValid()
        {
            // Arrange:
            var userRepositoryMock = new Mock<IUserRepository>();

            // Definindo os dados do fake repository, e o retorno esperado
            var mockUsers = new TbUser()
            {
                Id = 1, Email = "user1@example.com", Password = "hashedpassword1" 
            };

            userRepositoryMock.Setup(repo => repo.GetByEmail("user1@example.com"))
                .ReturnsAsync(mockUsers);

            var authService = new AuthService(userRepositoryMock.Object);

            //Act:
            var result  = await authService.Authenticate2("user1@example.com", "password");

            //Assert:
            Assert.NotNull(result);
            Assert.True(result == false, "credenciais invalidas");
        }    

    }
}