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
    class AuthServiceTest
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
        public void GenerateJWT_ValidInput_Returnstoken()
        {
            var mock = new Mock<IAuthRepo>();
            mock.Setup(p => p.GenerateJWT()).Returns(token_not_null);
            var res = new AuthService(mock.Object);
            var data = res.GetJsonWebToken();
            Assert.AreEqual(token_not_null, data);
        }
        [Test]
        public void GenerateJWT_correctInput_ReturnsNull()
        {
            var mock = new Mock<IAuthRepo>();
            mock.Setup(p => p.GenerateJWT()).Returns(token_null);
            var res = new AuthService(mock.Object);
            var data = res.GetJsonWebToken();
            Assert.AreEqual(null, data);
        }
    }
}
