using Moq;
using NUnit.Framework;
using Providor.Business.Exceptions;
using Providor.Business.Services;
using Providor.Data.DataServices;
using Providor.Data.Models;
using System.Collections.Generic;
using AutoFixture;
using System.Linq;

namespace Providor.Test
{
    public class MeterTests
    {
        private Mock<IMeterDataService> dataServiceMock = new Mock<IMeterDataService>();

        private MeterService businessService;

        private Fixture fixture;

        [SetUp]
        public void Setup()
        {
            businessService = new MeterService(dataServiceMock.Object);
            fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Test]
        public void EmptyMeterListThrowsException()
        {
            // Setup 
            dataServiceMock.Setup(p => p.GetAll()).Returns(new List<Meter>());

            //Act & Assert
            Assert.Throws<EmptyResultException>(() => businessService.Get());
        }

        [Test]
        public void NonEmptyMeterList()
        {
            //Arrange
            var meterList = fixture.CreateMany<Meter>(10);

            //Setup
            dataServiceMock.Setup(p => p.GetAll()).Returns(meterList);

            //Act
            var result = businessService.Get();

            //Assert
            Assert.AreEqual(result.Count(), meterList.Count());
            dataServiceMock.Verify(prop => prop.GetAll());
        }
    }
}