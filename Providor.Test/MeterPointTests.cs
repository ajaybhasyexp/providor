using AutoFixture;
using Moq;
using NUnit.Framework;
using Providor.Business.Exceptions;
using Providor.Business.Services;
using Providor.Data.DataServices;
using Providor.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Providor.Test
{
    public class MeterPointTests
    {
        private Mock<IMeterPointDataService> dataServiceMock = new Mock<IMeterPointDataService>();

        private MeterPointService businessService;

        private Fixture fixture;

        [SetUp]
        public void Setup()
        {
            businessService = new MeterPointService(dataServiceMock.Object);
            fixture = new Fixture();
            fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => fixture.Behaviors.Remove(b));
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Test]
        public void EmptyMeterListThrowsException()
        {
            // Setup 
            dataServiceMock.Setup(p => p.Get()).Returns(new List<MeterPoint>());

            //Act & Assert
            Assert.Throws<EmptyResultException>(() => businessService.Get());
        }

        [Test]
        public void NonEmptyMeterList()
        {
            //Arrange
            var meterPointList = fixture.CreateMany<MeterPoint>(10);

            //Setup
            dataServiceMock.Setup(p => p.Get()).Returns(meterPointList);

            //Act
            var result = businessService.Get();

            //Assert
            Assert.AreEqual(result.Count(), meterPointList.Count());
            dataServiceMock.Verify(prop => prop.Get());
        }
    }
}
