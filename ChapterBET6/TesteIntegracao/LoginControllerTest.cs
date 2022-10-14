using ChapterBET6.Controllers;
using ChapterBET6.Interfaces;
using ChapterBET6.Models;
using ChapterBET6.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.IdentityModel.Tokens.Jwt;

namespace TesteIntegracao
{
    public class LoginControllerTest
    {
        [Fact]
        public void LoginController_Retornar_Usuario_Invalido()
        {
            //arrange
            var RepositoryEspelhado = new Mock<IUsuarioRepository>();

            //usamos a expressão lambda para acessar os métodos do repositório original
            //usar o It.IsAny para dar as strings que o método exige
            //como é um repositório fake é preciso programara o que ele vai retornar
            RepositoryEspelhado.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            var controller = new LoginController(RepositoryEspelhado.Object);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "batata@email.com";
            dadosUsuario.senha = "batata";
            //act
            var resultado = controller.Login(dadosUsuario);

            //assert
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]

        public void LoginController_Retornar_Token()
        {
            //arrange

            Usuario usuarioRetornado = new Usuario();
            usuarioRetornado.Email = "email@email.com";
            usuarioRetornado.Senha = "1234";
            usuarioRetornado.Tipo = "0";
            usuarioRetornado.Id = 1;

            var repositoryEspelhado = new Mock<IUsuarioRepository>();

            repositoryEspelhado.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioRetornado);

                        
            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.email = "batata@email.com";
            dadosUsuario.senha = "batata";

            var controller = new LoginController(repositoryEspelhado.Object);
                       
            string issuerValido = "chapter.webapi";

            //act
            OkObjectResult resultado = (OkObjectResult).controller.Login(dadosUsuario);

            string tokenString = resultado.Value.ToString().Split(' ')[3];

            var jwtHandler = new JwtSecurityTokenHandler();
            var tokenJwt = jwtHandler.ReadJwtToken(tokenString);

            //assert
            Assert.Equal(issuerValido, tokenJwt.Issuer);
        }
    }
}