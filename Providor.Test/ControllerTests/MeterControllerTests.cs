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
    public class MeterControllerTests
    {
        private Mock<IMeterService> serviceMock = new Mock<IMeterService>();

        private MeterController controller;

        private Fixture fixture;

        [SetUp]
        public void Setup()
        {
            controller = new MeterController(serviceMock.Object);
            fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Test]
        public void EmptyMeterList204Status()
        {
            // Setup 
            serviceMock.Setup(p => p.Get()).Throws(new EmptyResultException());

            //Act & Assert
            var result = controller.Get();
            var noContentResult = result as NoContentResult;
            Assert.IsNotNull(noContentResult);
        }

        [Test]
        public void NonEmptyMeterList()
        {
            //Arrange
            var meterList = fixture.CreateMany<Meter>(10);

            //Setup
            serviceMock.Setup(p => p.Get()).Returns(meterList);

            //Act
            var result = controller.Get();

            //Assert
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            var models = okObjectResult.Value as IEnumerable<Meter>;
            Assert.IsNotNull(models);
            Assert.AreEqual(models.Count(), meterList.Count());
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
