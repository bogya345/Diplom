using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebBRS.Models;
using WebBRS.Controllers;
using WebBRS.DAL;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebBRS_testingNetCore
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestGetPersons()
		{
			//List<Person> persons = new List<Person>();
   //         var mockRepo = new Mock<IBrainstormSessionRepository>();
   //         mockRepo.Setup(repo => repo.ListAsync())
   //             .ReturnsAsync(GetTestSessions());
   //         var controller = new PersonController(mockRepo.Object);
   //         controller.ModelState.AddModelError("SessionName", "Required");
   //         var newSession = new HomeController.NewSessionModel();

   //         // Act
   //         var result = await controller.Index(newSession);

   //         // Assert
   //         var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
   //         Assert.IsType<SerializableError>(badRequestResult.Value);
        }
	}
}
