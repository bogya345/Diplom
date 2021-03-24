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
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebBRS.Models.Auth;

using System.Net.Http;

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
			var person = new Person(7, "Буракова", "Ольга", "Юрьевна");
			person.Email = "kek@mail.com";
			Assert.NotNull(person.Email);
			var mockRepo = new Mock<IBrainstormSessionRepository>();
			mockRepo.Setup(repo => repo.ListAsync())
				.ReturnsAsync(GetTestSessions());
			var controller = new PersonController(mockRepo.Object);

			//Act
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
			var exception = Record.Exception(() => person.PersonsEmailUpdate());
			Assert.NotNull(person);

		}
		[Fact]
		public async void Test3()
		{

			var mockRepo = new Mock<IBrainstormSessionRepository>();
			mockRepo.Setup(repo => repo.ListAsync())
				.ReturnsAsync(GetTestSessions());
			var controller = new PersonController(mockRepo.Object);
			var result = controller.GetPersons();
			var model = result.ToList();
			Assert.Equal(54406, model.Count());
		}
		[Fact]
		public async void TestCreate()
		{

			var mockRepo = new Mock<IBrainstormSessionRepository>();
			mockRepo.Setup(repo => repo.ListAsync())
				.ReturnsAsync(GetTestSessions());
			var controller = new PersonController(mockRepo.Object);
			Guid guid = new Guid("E8F672BE-F086-E211-B260-0018FE865BEB");
			var person = new Person(7, "Буракова", "Ольга", "Юрьевна");
			person.Email = "kek@mail.com";
			var result = controller.Create(person);
			var model = result;
			var json = JsonConvert.SerializeObject(result.Value);
			Assert.Equal("\"Create Successful.\"", json) ;
		}
		[Fact]
		public async void TestAccount()
		{

			var mockRepo = new Mock<IBrainstormSessionRepository>();
			mockRepo.Setup(repo => repo.ListAsync())
				.ReturnsAsync(GetTestSessions());
			var controller = new AccountController(mockRepo.Object);
			var result = controller.Token("admin", "1234");
			var json = JsonConvert.SerializeObject(result.Value);
			Assert.Equal("{\"username\":\"admin\",\"access_role_id\":\"1\"}", json);
		}
	}
}
