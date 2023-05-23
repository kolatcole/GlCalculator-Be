using Autofac.Extras.Moq;
using CalculatorLibrary;
using GlCalculator.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest
{
    [TestFixture]
    public class CalculatorControllerTest
    {
       // private readonly Ca

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void CalculatorController_AddTwoNumbers_ReturnsAccurateResultOfAddition()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange

                mock.Mock<ISimpleCalculator>()
                    .Setup(x => x.Add(2,5))
                    .Returns((7));

                // Act

                var calculatorController = mock.Create<CalculatorController>();
                var actual = calculatorController.Get(2, 5,"add");
                var expected = 7;

                // Assert

                var actualContent = (int)(actual as OkObjectResult).Value;

                Assert.IsInstanceOf<OkObjectResult>(actual);
                Assert.That(actualContent, Is.EqualTo(expected));
            }
        }

        [Test]
        public void CalculatorController_SubtractANumberFromAnother_ReturnsAccurateResultOfSubtraction()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange

                mock.Mock<ISimpleCalculator>()
                    .Setup(x => x.Subtract(-2, 5))
                    .Returns((-7));

                // Act

                var calculatorController = mock.Create<CalculatorController>();
                var actual = calculatorController.Get(-2, 5, "subtract");
                var expected = -7;

                // Assert

                var actualContent = (int)(actual as OkObjectResult).Value;

                Assert.IsInstanceOf<OkObjectResult>(actual);
                Assert.That(actualContent, Is.EqualTo(expected));
            }
        }

        [Test]
        public void CalculatorController_PassAnInvalidOperator_ReturnsNotFound()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange

                // Act

                var calculatorController = mock.Create<CalculatorController>();
                var actual = calculatorController.Get(-2, 5, "/");

                // Assert

                Assert.IsInstanceOf<NotFoundObjectResult>(actual);
            }
        }
    }
}
