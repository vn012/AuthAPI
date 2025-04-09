using Aplication.Services;
using Moq;
using Xunit;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Aplication.Interfaces;

namespace AplicationTests
{
    public class UserServiceTests
    {
        // Arrange: Criando o mock do repositório
        private readonly Mock<IPasswordHasher> _passwordHasherMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public UserServiceTests()
        {
            _passwordHasherMock = new Mock<IPasswordHasher>();
            _userRepositoryMock = new Mock<IUserRepository>();
        }
        #region POST    

        [Fact]
        public async Task CreateUser_ShouldHashPassword()
        {

            // Arrange
            var email = "user@example.com";
            var rawPassword = "Secure123!";
            var hashedPassword = "hashed_password";
            var user = new TbUser { Email = email, Password = rawPassword };

            // Configura o mock para simular a hash da senha
            _passwordHasherMock
                .Setup(ph => ph.HashPassword(rawPassword))
                .Returns(hashedPassword);
            var userService = new UserService(_userRepositoryMock.Object);

            // Configura o repositório para aceitar qualquer usuário e retornar o usuário simulado
            _userRepositoryMock
                .Setup(repo => repo.Create(It.IsAny<TbUser>()))
                .ReturnsAsync((TbUser u) => u); // Retorna o mesmo objeto salvo

            // Act
            var userRes = await userService.AddUser(user);

            // Assert
            _passwordHasherMock.Verify(ph => ph.HashPassword(rawPassword), Times.Once);
            _userRepositoryMock.Verify(repo => repo.Create(It.Is<TbUser>(u => u.Password == hashedPassword)), Times.Once);

        }

        #endregion

        #region GET
        [Fact]
        public async Task GetAllUsers_ReturnsListOfUsers()
        {
            // Definindo os dados do fake repository
            var mockUsers = new List<TbUser>
            {
                new TbUser { Id = 1, Email = "user1@example.com", Password = "hashedpassword1" },
                new TbUser { Id = 2, Email = "user2@example.com", Password= "hashedpassword2" },
            };

            _userRepositoryMock
                .Setup(repo => repo.GetAll()) 
                .ReturnsAsync(mockUsers);

            // Criando a instância do serviço com o repositório mockado
            var userService = new UserService(_userRepositoryMock.Object);

            // Act:
            var users = await userService.GetAll();

            // Assert: Verificando a lista de usuários de acordo com as regras estabelicidas
            Assert.NotNull(users);
            Assert.True(users.Count() >= 2, "O número de usuários não é maior que 2.");
            Assert.Equal("user1@example.com", users.First().Email); 
        }

        [Fact]
        public async Task GetUserByUsername_ShouldReturnUser_WhenUsernameIsCorrect()
        {

            // Definindo os dados do fake repository e o retorno esperado
            var mockUsers = new TbUser()
            {
                Id = 1, 
                Email = "user1@example.com", 
                Password = "hashedpassword1",
                Username = "username",
            };

            var username = "username";

            _userRepositoryMock
                .Setup(repo => repo.GetByUsername(username)) 
                .ReturnsAsync(mockUsers);

            // Criando a instância do serviço com o repositório mockado
            var userService = new UserService(_userRepositoryMock.Object);

            // Act:
            var user = await userService.GetByUser(username);

            // Assert: Verificando a lista de usuários de acordo com as regras estabelicidas
            Assert.NotNull(user);
            Assert.Equal(username, user.Username);

        }
        #endregion
    }
}
