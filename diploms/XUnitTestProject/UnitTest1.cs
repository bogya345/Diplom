using System;
using Xunit;
using WebBRS.Models;
using WebBRS.Controllers;
using WebBRS.Models;
using WebBRS.DAL;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace XUnitTestProject
{
	public class UnitTest1
	{
		private List<BrainstormSession> GetTestSessions()
		{
			var sessions = new List<BrainstormSession>();
			sessions.Add(new BrainstormSession()
			{
				DateCreated = new DateTime(2016, 7, 2),
				Id = 1,
				Name = "Test One"
			});
			sessions.Add(new BrainstormSession()
			{
				DateCreated = new DateTime(2016, 7, 1),
				Id = 2,
				Name = "Test Two"
			});
			return sessions;
		}
		[Fact]
		public async void Test1()
		{
			Guid guid = new Guid("E8F672BE-F086-E211-B260-0018FE865BEB");
			var person = new Person( 7, "Буракова", "Ольга", "Юрьевна");
			person.Email = "kek@mail.com";
			Assert.NotNull(person.Email);
			var mockRepo = new Mock<IBrainstormSessionRepository>();
			mockRepo.Setup(repo => repo.ListAsync())
				.ReturnsAsync(GetTestSessions());
			var controller = new PersonController(mockRepo.Object);

			// Act
			var result = await controller.Index();

			// Assert
			var viewResult = Assert.IsType<ViewResult>(result);
			var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
				viewResult.ViewData.Model);
			Assert.Equal(2, model.Count());
			////CreateHostBuilder(args).Build().Run();
			//Assert.Throws<InvalidOperationException>(
			//	()=>person.PersonsEmailUpdate("kek")
			//	);
		}

		[Fact]
		public void Test2()
		{
			Guid guid = new Guid("E8F672BE-F086-E211-B260-0018FE865BEB");
			var person = new Person(7, "Буракова", "Ольга", "Юрьевна");
			person.Email = "kek@mail.com";
			//string l = null;
			//CreateHostBuilder(args).Build().Run();
			//Assert.Throws<ArgumentNullException>(
			//	() => person.PersonsEmailUpdate("kek")
			//	); 
			var exception = Record.Exception(() => person.PersonsEmailUpdate());
			//Assert.IsType(typeof(DivideByZeroException), exception);
			Assert.NotNull(person);

		}
		[Fact]
		public async void Test3()
		{

			var mockRepo = new Mock<IBrainstormSessionRepository>();
			mockRepo.Setup(repo => repo.ListAsync())
				.ReturnsAsync(GetTestSessions());
			var controller = new PersonController(mockRepo.Object);

			// Act
			var result =  controller.GetPersons();

			// Assert
			//var viewResult = Assert.IsType<IEnumerable<Person>>(result);
			//var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
			//	viewResult);
			var model = result.ToList();
			Assert.Equal(5446, model.Count());
			////CreateHostBuilder(args).Build().Run();
			//Assert.Throws<InvalidOperationException>(
			//	()=>person.PersonsEmailUpdate("kek")
			//	);
		}

	}
}
