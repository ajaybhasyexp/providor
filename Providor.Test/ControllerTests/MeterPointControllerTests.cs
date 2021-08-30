using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Providor.Business.Exceptions;
using Providor.Business.Services;
using Providor.Controllers;
using Providor.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Providor.Test.ControllerTests
{
    public class MeterPointControllerTests
    {
        private Mock<IMeterPointService> serviceMock = new Mock<IMeterPointService>();

        private MeterPointController controller;

        private Fixture fixture;

        [SetUp]
        public void Setup()
        {
            controller = new MeterPointController(serviceMock.Object);
            fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Test]
        public void EmptyMeterPointList204Status()
        {
            // Setup 
            serviceMock.Setup(p => p.Get()).Throws(new EmptyResultException());

            //Act & Assert
            var result = controller.Get();
            var noContentResult = result as NoContentResult;
            Assert.IsNotNull(noContentResult);
        }

        [Test]
        public void NonEmptyMeterPointList()
        {
            //Arrange
            var meterPointList = fixture.CreateMany<MeterPoint>(10);

            //Setup
            serviceMock.Setup(p => p.Get()).Returns(meterPointList);

            //Act
            var result = controller.Get();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var models = okObjectResult.Value as IEnumerable<MeterPoint>;
            Assert.IsNotNull(models);
            Assert.AreEqual(models.Count(), meterPointList.Count());
        }

        [Test]
        public void UnknownException500Status()
        {
            //Setup
            serviceMock.Setup(p => p.Get()).Throws(new Exception());

            //Act
            var result = controller.Get();

            //Assert
            var errorResult = result as StatusCodeResult;
            Assert.IsNotNull(errorResult);
            Assert.AreEqual(errorResult.StatusCode, (int)HttpStatusCode.InternalServerError);
        }

    }
}
