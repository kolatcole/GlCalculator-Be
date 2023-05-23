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
    public class SimpleCalculatorTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SimpleCalculator_AddTwoNumbers_ReturnsAccurateResultOfAddition()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange

                mock.Mock<ISimpleCalculator>()
                    .Setup(x => x.Add(2, 5))
                    .Returns((7));

                // Act

                var calculator = mock.Create<SimpleCalculator>();
                var actual = calculator.Add(2, 5);
                var expected = 7;

                // Assert

                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        [Test]
        public void SimpleCalculator_SubtractANumberFromAnother_ReturnsAccurateResultOfSubtraction()
        {
            using (var mock = AutoMock.GetLoose())
            {
                // Arrange

                mock.Mock<ISimpleCalculator>()
                    .Setup(x => x.Subtract(-2, 5))
                    .Returns((-7));

                // Act

                var calculator = mock.Create<SimpleCalculator>();
                var actual = calculator.Subtract(-2, 5);
                var expected = -7;

                // Assert

                Assert.That(actual, Is.EqualTo(expected));
            }
        }
    }
}
