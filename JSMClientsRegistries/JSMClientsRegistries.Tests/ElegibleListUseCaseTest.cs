using AutoMapper;
using JSMClientsRegistries.Application.Models.Requests;
using JSMClientsRegistries.Core.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace JSMClientsRegistries.Tests
{
    [TestClass]
    public class ElegibleListUseCaseTest
    {
        [TestMethod]

        public void ExecuteAsync_IfRequestIsNull_ReturnBadRequestResult()
        {
            //Arrange: fake objects
            //Mock<IMapper> mapper = new Mock<IMapper>();

            //var ElegibleListObj = new ElegibleListRequest();

            //Mock<ElegibleListRequest> elegibleListRequest = new Mock<ElegibleListRequest>();


            //Act: execute with fake objects
            //var resp = elegibleListRequest.ExecuteAsync(null).Result;

            //Assert: verify if right response
            //Assert.IsTrue(resp.GetType() == typeof(BadRequestResult));
        }
    }
}
