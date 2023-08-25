using System.Net;
using API.Controllers;
using API.DTO;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tests.Mocks;

namespace Tests
{
    public class UsuariosControllerTests
    {
        [Fact]
        public async Task WhenGettingAll_ThenAllReturn()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = AutoMapper.GetMapper();
            var controller = new UsuariosController(repositoryWrapperMock.Object, mapper);

            var result = (await controller.GetAll(new CancellationTokenSource().Token)).Result as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<List<Usuario>>(result.Value);
            Assert.NotNull(result.Value as List<Usuario>);
            Assert.NotEmpty((List<Usuario>)result.Value);
        }

        [Fact]
        public async Task GivenExistingId_WhenGettingById_ThenReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = AutoMapper.GetMapper();
            var controller = new UsuariosController(repositoryWrapperMock.Object, mapper);
            var id = 1;

            var result = (await controller.GetById(id, new CancellationTokenSource().Token)).Result as ObjectResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<Usuario>(result.Value);
            Assert.NotNull(result.Value as Usuario);
            Assert.Equal(((Usuario)result.Value).Id, id);
        }

        [Fact]
        public async Task GivenNonExistingId_WhenGettingById_ThenNotFoundReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = AutoMapper.GetMapper();
            var controller = new UsuariosController(repositoryWrapperMock.Object, mapper);
            var id = 10;

            var result = (await controller.GetById(id, new CancellationTokenSource().Token)).Result as StatusCodeResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public async Task GivenValidRequest_WhenCreating_ThenCreatedReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = AutoMapper.GetMapper();
            var controller = new UsuariosController(repositoryWrapperMock.Object, mapper);
            var usuario = new UsuarioDTO { Nome = "Teste" };

            var result = (await controller.Create(usuario, new CancellationTokenSource().Token)).Result as ObjectResult;
            Assert.NotNull(result);
            Assert.IsAssignableFrom<CreatedAtRouteResult>(result);
            Assert.Equal((int)HttpStatusCode.Created, result!.StatusCode);
            Assert.Equal("UsuarioById", (result as CreatedAtRouteResult)!.RouteName);
        }

        [Fact]
        public async Task GivenNonExistingId_WhenUpdating_ThenNotFoundReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = AutoMapper.GetMapper();
            var controller = new UsuariosController(repositoryWrapperMock.Object, mapper);
            var id = 10;

            var result = (await controller.Update(id, new UsuarioDTO(), new CancellationTokenSource().Token)) as StatusCodeResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public async Task GivenExistingId_WhenUpdating_ThenReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = AutoMapper.GetMapper();
            var controller = new UsuariosController(repositoryWrapperMock.Object, mapper);
            var id = 1;

            var result = (await controller.Update(id, new UsuarioDTO(), new CancellationTokenSource().Token)) as StatusCodeResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);
            Assert.IsAssignableFrom<NoContentResult>(result);
        }

        [Fact]
        public async Task GivenNonExistingId_WhenDeleting_ThenNotFoundReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = AutoMapper.GetMapper();
            var controller = new UsuariosController(repositoryWrapperMock.Object, mapper);
            var id = 10;

            var result = (await controller.Delete(id, new CancellationTokenSource().Token)) as StatusCodeResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }

        [Fact]
        public async Task GivenExistingId_WhenDeleting_ThenReturns()
        {
            var repositoryWrapperMock = MockIRepositoryWrapper.GetMock();
            var mapper = AutoMapper.GetMapper();
            var controller = new UsuariosController(repositoryWrapperMock.Object, mapper);
            var id = 1;

            var result = (await controller.Delete(id, new CancellationTokenSource().Token)) as StatusCodeResult;
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);
            Assert.IsAssignableFrom<NoContentResult>(result);
        }
    }
}