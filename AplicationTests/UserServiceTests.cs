using Aplication.Services;
using Moq;
using Xunit;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;

namespace Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetAllUsers_ReturnsListOfUsers()
        {
            // Arrange: Criando o mock do repositório
            var userRepositoryMock = new Mock<IUserRepository>();

            // Definindo o retorno esperado do método GetAll
            var mockUsers = new List<TbUser>
            {
                new TbUser { Id = 1, Email = "user1@example.com", Password = "hashedpassword1" },
                new TbUser { Id = 2, Email = "user2@example.com", Password= "hashedpassword2" },
            };

            userRepositoryMock
                .Setup(repo => repo.GetAll()) // Nome do método desejado
                .ReturnsAsync(mockUsers);

            // Criando a instância do serviço com o repositório mockado
            var userService = new UserService(userRepositoryMock.Object);

            // Act:
            var users = await userService.GetAll();

            // Assert: Verificando a lista de usuários de acordo com as regras estabelicidas
            Assert.NotNull(users);
            Assert.True(users.Count() > 2, "O número de usuários não é maior que 2.");
            Assert.Equal("user1@example.com", users.First().Email); 
        }
    }
}
