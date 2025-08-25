using NUnit.Framework;
using Moq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using JenkinsRazorPage.Controllers;
using JenkinsRazorPage.Models;
using System.Diagnostics;

namespace JenkinsRazorPage.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTests
    {
        private Mock<ILogger<HomeController>> _mockLogger;
        private HomeController _controller;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<HomeController>>();
            _controller = new HomeController(_mockLogger.Object);
        }
        [TearDown]
        public void Teardown()
        {
            _controller.Dispose();
        }

        [Test]
        public void Index_Returns_ViewResult()
        {
            // Act
            var result = _controller.Index();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Privacy_Returns_ViewResult()
        {
            // Act
            var result = _controller.Privacy();

            // Assert
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void Error_Returns_ViewResult_With_ErrorViewModel()
        {
            // Arrange
            var activity = new Activity("TestActivity");
            activity.Start();
            Activity.Current = activity;

            // Act
            var result = _controller.Error() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ErrorViewModel>(result.Model);

            var model = result.Model as ErrorViewModel;
            Assert.IsNotNull(model?.RequestId);
            Assert.IsTrue(model.ShowRequestId);
        }
    }
}
