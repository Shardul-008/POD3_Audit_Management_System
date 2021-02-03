using NUnit.Framework;
using System;
using Moq;
using AuthorizationService.Repository;
using AuthorizationService.Providers;
using AuthorizationService.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
namespace AuthorizationTesting
{
    public class Tests
    {
        public string token_not_null;
        public string token_null;
        [SetUp]
        public void Setup()
        {
            token_not_null = "xhagssbmfbdmsdjfbkalalasknasncjafh";
            token_null = null;

        }

       
        [Test]
        public void GetJsonWebToken_HasValidData_ReturnsToken()
        {
            var mock = new Mock<IAuthService>();
            mock.Setup(p => p.GetJsonWebToken()).Returns(token_not_null);
            var res = new TokenController(mock.Object);
            var data = res.GenerateJSONWebToken() as OkObjectResult;
            Assert.AreEqual(200, data.StatusCode);
        }
        [Test]
        public void GetJsonWebToken_HasInvalidData_ReturnsNull()
        {
            var mock = new Mock<IAuthService>();
            mock.Setup(p => p.GetJsonWebToken()).Returns(token_null);
            var res = new TokenController(mock.Object);
            var data = res.GenerateJSONWebToken() as BadRequestObjectResult;
            Assert.AreEqual(400, data.StatusCode);
        }

    }
}