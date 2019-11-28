using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIMEDECON;
using SIMEDECON.Controllers;

namespace SIMEDECON.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void ViewAdministrador()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.ViewAdministrador() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ViewMedico()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.ViewMedico() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

    }
}
